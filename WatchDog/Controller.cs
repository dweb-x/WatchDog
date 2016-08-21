using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace WatchDog
{
    class Controller
    {
        private static Controller ctrl;
        private Process process;
        private int _time = 7200; //default of 2 hours in seconds

        private Controller()
        {
            process = new Process();
            process.StartInfo.FileName = "psshutdown.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
        }

        public static Controller Instance
        {
            get
            {
                if (ctrl == null)
                {
                    ctrl = new Controller();
                }

                return ctrl;
            }
        }

        public bool IsActive { get; set; }

        public int Time
        {
            set { _time = value; }
        }


        public void Set()
        {
            process.StartInfo.Arguments = "-d -t " + _time;
            process.Start();
            IsActive = true;
        }

        public void Cancel()
        {
            if (IsActive)
            {
                process.StartInfo.Arguments = "-a";
                process.Start();
                IsActive = false;
            }
        }
    }
}
