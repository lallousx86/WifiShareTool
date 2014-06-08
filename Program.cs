using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WifiShare
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Version ver = Environment.OSVersion.Version;
            if (!(ver.Major >=6 && ver.Minor >= 1))
            {
                MessageBox.Show("This program requires Windows 7 and above!");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WifiShareForm());
        }
    }
}
