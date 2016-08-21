using System;
using System.Diagnostics;

namespace Power
{
    public static class Power
    {
        public static void Shutdown()
        {
            var process = new Process();
            process.StartInfo.FileName = @"C:\Windows\System32\shutdown.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.Arguments = "-s";
            process.Start();
        }

        public static void Reboot()
        {
            var process = new Process();
            process.StartInfo.FileName = @"C:\Windows\System32\shutdown.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.Arguments = "-r";
            process.Start();
        }

        public static void Hibernate()
        {
            var process = new Process();
            process.StartInfo.FileName = @"C:\Windows\System32\rundll32.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.Arguments = "powrprof.dll,SetSuspendState Hibernate";
            process.Start();
        }

        public static void Sleep()
        {
            var process = new Process();
            process.StartInfo.FileName = @"C:\Windows\System32\rundll32.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.Arguments = "powrprof.dll,SetSuspendState 0,1,0";
            process.Start();
        }

        public static void LogOff()
        {
            var process = new Process();
            process.StartInfo.FileName = @"C:\Windows\System32\shutdown.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.Arguments = "-l";
            process.Start();
        }
    }
}
