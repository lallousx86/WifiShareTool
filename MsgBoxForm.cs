using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WifiShare
{
    public partial class MsgBoxForm : Form
    {
        public MsgBoxForm()
        {
            InitializeComponent();
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {
            txtInfo.Width = this.Width;
            txtInfo.Height = picBox.Top - 10 ;

            btnOk.Anchor = btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            txtInfo.Select(0, 0);
        }

        public static DialogResult Show(
            string Title,
            string Message,
            int Buttons = 1)
        {
            var Frm = new MsgBoxForm();
            Frm.Text = Title;
            Frm.txtInfo.Text = Message;

            Frm.btnOk.Visible = ((Buttons & 1) != 0);
            Frm.btnCancel.Visible = ((Buttons & 2) != 0);
            
            return Frm.ShowDialog();
        }

        private void MsgBoxForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == (char)27 || c == (char)13)
                this.Close();
        }
    }
}
