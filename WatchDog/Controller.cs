using System;
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

        /// <summary>
        /// 
        /// </summary>
        private Controller()
        {
            timer = new System.Timers.Timer();
            timer.Interval = _time;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = false;
        }

        /// <summary>
        /// Timer callback fires on timeout. Sleeps PC and exits application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            PC.Sleep();
            Application.Exit();       
        }

        /// <summary>
        /// Singleton pattern. Returns instance.
        /// </summary>
        public static Controller Instance
        {
            get { return ctrl ?? (ctrl = new Controller()); }
        }

        public bool IsActive { get; set; }

        /// <summary>
        /// Timer interval in ms. Defaults to 1 if value less than 0.
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

        /// <summary>
        /// Start countdown
        /// </summary>
        public void Start()
        {
            timer.Start();
            IsActive = true;
        }

        /// <summary>
        /// Cancel countdown if active
        /// </summary>
        public void Cancel()
        {
            if (IsActive)
            {
                timer.Stop();
                IsActive = false;
            }
        }
    }
}
