using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace WifiShare
{
    public class ToolHelper
    {
        public const string BATCH_FILE = "Helper.cmd";
        public const int ERROR_CODE = 1981;

        public static int ExecuteCommand(
            string command,
            out string Output,
            out string ErrOut)
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;

            ProcessInfo.RedirectStandardError = true;
            ProcessInfo.RedirectStandardOutput = true;

            Process Process = Process.Start(ProcessInfo);
            Process.WaitForExit();

            Output = Process.StandardOutput.ReadToEnd();
            ErrOut = Process.StandardError.ReadToEnd();

            int ExitCode = Process.ExitCode;
            Process.Close();

            return ExitCode;
        }

        public static bool HostedApSupported()
        {
            string s;
            return ExecuteCommand(
                string.Format("{0} check", BATCH_FILE),
                out s,
                out s) != ERROR_CODE;
        }

        public static bool StartAp(
            string ssid,
            string pass,
            out string output)
        {
            string o, e;
            int ExitCode = ExecuteCommand(
                string.Format("{0} start \"{1}\" \"{2}\"", 
                    BATCH_FILE, ssid, pass),
                out o,
                out e);

            output = o + "\r\n" + e;
            return ExitCode != ERROR_CODE;
        }

        public static void StopAp()
        {
            string o;
            ExecuteCommand(
                BATCH_FILE + " stop", 
                out o, 
                out o);
        }

        public static string Show()
        {
            string o, e;
            ExecuteCommand(BATCH_FILE + " show", out o, out e);
            return o;
        }
    }
}