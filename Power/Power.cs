using System;
using System.Diagnostics;

namespace Power
{
    public static class Power
    {
        public static void Shutdown()
        {
            Execute(@"C:\Windows\System32\shutdown.exe", "-s");
        }

        public static void Reboot()
        {
            Execute(@"C:\Windows\System32\shutdown.exe", "-r");
        }

        public static void Hibernate()
        {
            Execute(@"C:\Windows\System32\rundll32.exe", "powrprof.dll,SetSuspendState Hibernate");
        }

        public static void Sleep()
        {
            Execute(@"C:\Windows\System32\rundll32.exe", "powrprof.dll,SetSuspendState 0,1,0");
        }

        public static void LogOff()
        {
            Execute(@"C:\Windows\System32\shutdown.exe", "-l");
        }

        private static void Execute(string filename, string args)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = filename,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    Arguments = args
                }
            };
            process.Start();
        }
    }
}
