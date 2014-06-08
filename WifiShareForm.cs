using IcsManagerLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WifiShare
{
    public partial class WifiShareForm : Form
    {
        internal class NicItem
        {
            private string Guid, Description, Name;
            public NicItem(
                string Guid, 
                string Description,
                string Name)
            {
                this.Guid = Guid;
                this.Description = Description;
                this.Name = Name;
            }

            public override string ToString()
            {
                return this.Name;
            }
        }

        public WifiShareForm()
        {
            InitializeComponent();
        }

        private void WifiShareForm_Load(object sender, EventArgs e)
        {
            Text = Consts.STR_TOOL_NAME;
            LoadSettings();
            PopulateNetworkList(Properties.Settings.Default.SourceNetwork);
        }

        private void LoadSettings()
        {
            // Password
            string s = Properties.Settings.Default.Wpa2Password;
            if (string.IsNullOrEmpty(s))
                s = "lallouslab" + (Environment.TickCount & 0xffff).ToString();

            txtPassword.Text = s;

            // ApName
            s = Properties.Settings.Default.ApName;
            if (string.IsNullOrEmpty(s))
                s = "WifiShareTool";

            txtApName.Text = s;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Wpa2Password = txtPassword.Text;
            Properties.Settings.Default.ApName = txtApName.Text;
            Properties.Settings.Default.SourceNetwork = cbSourceNetworks.Text;

            Properties.Settings.Default.Save();
        }

        private bool PopulateNetworkList(string SelStr = null)
        {
            try
            {
                cbSourceNetworks.BeginUpdate();

                int idx = -1;
                foreach (var nic in IcsManager.GetAllIPv4Interfaces())
                {
                    if (    nic.OperationalStatus != OperationalStatus.Up
                         || HasHostedNetworkAttrs(nic) )
                    {
                        continue;
                    }

                    string name = nic.Name;
                    if (    !string.IsNullOrEmpty(SelStr) 
                          && name.Equals(SelStr, StringComparison.CurrentCulture))
                    {
                        idx = cbSourceNetworks.Items.Count;
                        SelStr = null;
                    }

                    cbSourceNetworks.Items.Add(new NicItem(
                            Name: name,
                            Guid: nic.Id,
                            Description: nic.Description
                        ));
                }
                cbSourceNetworks.EndUpdate();
                
                if (idx == -1)
                    idx = 0;

                if (cbSourceNetworks.Items.Count > 0)
                    cbSourceNetworks.SelectedIndex = idx;
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string FindHostedNetworkId()
        {
            foreach (var nic in IcsManager.GetAllIPv4Interfaces())
            {
                if (    nic.OperationalStatus == OperationalStatus.Up
                     && HasHostedNetworkAttrs(nic))
                {
                    return nic.Id;
                }
            }
            return null;
        }

        private bool HasHostedNetworkAttrs(NetworkInterface nic)
        {
            return nic.Name.IndexOf('*') != -1
                     && nic.Description.IndexOf("Hosted") != -1;
        }

        static bool EnableInternetSharing(
            string SrcNetName, 
            string HostedNetName, 
            bool bForce)
        {
            string err = null;

            try
            {
                do
                {
                    var SrcNet = IcsManager.FindConnectionByIdOrName(SrcNetName);
                    if (SrcNet == null)
                    {
                        err = "Connection not found: " + SrcNetName;
                        break;
                    }

                    var HostedNet = IcsManager.FindConnectionByIdOrName(HostedNetName);
                    if (HostedNet == null)
                    {
                        err = "Could not find network " + HostedNetName;
                        break;
                    }

                    IcsManager.ShareConnection(
                        SrcNet,
                        HostedNet);
                } while (false);
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            if (!string.IsNullOrEmpty(err))
            {
                MessageBox.Show(err, "Error");
                return false;
            }
            return true;
        }

        static void DisableInternetSharing()
        {
            try
            {
                var currentShare = IcsManager.GetCurrentlySharedConnections();
                if (!currentShare.Exists)
                    return;

                IcsManager.ShareConnection(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnRefreshNetworks_Click(object sender, EventArgs e)
        {
            PopulateNetworkList();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MsgBoxForm.Show(
                "About",
                Consts.STR_TOOL_NAME + "\r\n"+
                "  by Elias Bachaalany <lallousz-x86@yahoo.com>\r\n"+
                "  Twitter: @lallouslab\r\n"+
                "\r\n"+
                "Please visit:\r\n" +
                "  @ http://lallousx86.wordpress.com/\r\n" +
                "\r\n"+
                "Powered by: ICSManager Library\r\n"+
                "  @ https://github.com/utapyngo/icsmanager\r\n" +
                "\r\n"+
                "Hosted networks doc:\r\n"+
                "  @ http://msdn.microsoft.com/en-us/library/windows/desktop/dd815243(v=vs.85).aspx\r\n",
                1);
        }

        private void btnStartSharing_Click(object sender, EventArgs e)
        {
            string ApName;
            if (!uiValidateApName(out ApName))
                return;

            string Pass;
            if (!uiValidateApPassword(out Pass))
                return;

            // Stop previous hosted network
            ToolHelper.StopAp();

            // Start hosted network
            string output;
            if (!ToolHelper.StartAp(ApName, Pass, out output))
            {
                MessageBox.Show("Failed to start hosted network!");
                return;
            }

            string HostedId = FindHostedNetworkId();
            if (string.IsNullOrEmpty(HostedId))
            {
                MessageBox.Show(
                    "Could not find the hosted network virtual network interface!",
                    "Something went wrong!");
                return;
            }

            bool bOk = EnableInternetSharing(
                cbSourceNetworks.Text,
                HostedId,
                true);

            if (bOk)
            {
                MessageBox.Show("Congratulations! The connection is successfully shared!", "Info");
                return;
            }
        }

        private bool uiValidateApPassword(out string Pass)
        {
            Pass = txtPassword.Text;
            if (Pass.Length < 8 || Pass.Length > 63)
            {
                MessageBox.Show("Password should be between 8 and 63 characters!");
                return false;
            }
            
            var re = new Regex("^[0-9a-zA-Z!@#$%^*+_()]+$");
            if (!re.IsMatch(Pass))
            {
                MessageBox.Show("Password contains invalid characters!");
                return false;
            }

            return true;
        }

        private bool uiValidateApName(out string ApName)
        {
            ApName = txtApName.Text;
            if (ApName.Length < 5 || ApName.Length > 15)
            {
                MessageBox.Show("Please enter access point name between 5 and 15!");
                txtApName.Focus();
                return false;
            }

            var ApPattern = new Regex("^[0-9a-zA-z]+$");
            if (!ApPattern.IsMatch(ApName))
            {
                MessageBox.Show("Access point name has invalid characters!");
                txtApName.Focus();
                return false;
            }
            return true;
        }

        private void btnStopSharing_Click(object sender, EventArgs e)
        {
            // Stop connection sharing
            DisableInternetSharing();

            // Stop hosted network
            ToolHelper.StopAp();

            MessageBox.Show("Stopped sharing!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!ToolHelper.HostedApSupported())
                MessageBox.Show("Hosted network is not supported!");
            else
                System.Diagnostics.Process.Start(Consts.STR_WEB_LALLOUSLAB);
        }

        private void WifiShareForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            string s = " >> " + (ToolHelper.HostedApSupported() ? "Sharing supported" : "Sharing not supported") + " << \r\n\r\n";

            s += ToolHelper.Show().Trim();

            MsgBoxForm.Show("Info", s);
        }

    }
}
