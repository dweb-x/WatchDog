using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using PC = Power.Power;
using System.Timers;



namespace WatchDog
{
    class Controller
    {
        private static Controller ctrl;
        private int _time = 7200000; //default of 2 hours in miliseconds
        private System.Timers.Timer timer;

        private Controller()
        {
            timer = new System.Timers.Timer();
            timer.Interval = _time;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = false;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            MessageBox.Show("Timed out");
            //PC.Sleep();
            Application.Exit();
            
        }

        public static Controller Instance
        {
            get { return ctrl ?? (ctrl = new Controller()); }
        }

        public bool IsActive { get; set; }

        /// <summary>
        /// Timer interval in ms
        /// </summary>
        public int Time
        {
            get { return _time; }
            set
            {
                _time = value;
                timer.Interval = _time > 0 ? _time : 1;
            }
        }

        public void Set()
        {
            Start();
        }

        public void Cancel()
        {
            Stop();
        }

        private void Start()
        {
            timer.Start();
            IsActive = true;
        }

        private void Stop()
        {
            if (IsActive)
            {
                timer.Stop();
                IsActive = false;
            }
        }


        private static int MinsToMs(int minutes)
        {
            return minutes*60*1000;
        }


    }
}
