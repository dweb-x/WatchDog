using System;
using System.Timers;
using System.Windows.Forms;

namespace WatchDog
{
    public partial class MainUI : Form
    {
        private readonly Controller ctrl;
        private DateTime offTime;
        private System.Timers.Timer timer;

        public MainUI()
        {
            InitializeComponent();
            ctrl = Controller.Instance;
            timer = new System.Timers.Timer {Interval = 100};
            timer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {       
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(Countdown));
            }
        }

        /// <summary>
        /// Called from timer every second. Displays time until shutdown via the timePicker ctrl.
        /// </summary>
        private void Countdown()
        {
            var interval = offTime.Subtract(DateTime.Now);
            timePicker.Value = new DateTime(
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, interval.Hours, interval.Minutes, interval.Seconds
                );
        }

        /// <summary>
        /// Toggles between set/reset.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (ctrl.IsActive)
            {
                ctrl.Cancel();
                Reset();
            }
            else
            {          
                offTime = timePicker.Value;
                var interval = offTime.Subtract(DateTime.Now);

                //Set the sleep time before starting.
                ctrl.Time = (int)interval.TotalMilliseconds;
                ctrl.Start();
                   
                Set();
            }      
        }

        private void Reset()
        {
            buttonStart.Text = "Activate";
            timePicker.Value = DateTime.Now;
            timePicker.Enabled = true;
            timer.Stop();
        }

        private void Set()
        {
            buttonStart.Text = "Cancel";
            timePicker.Enabled = false;
            timer.Start();
        }

        private void timePicker_ValueChanged(object sender, EventArgs e)
        {
            //prevent time values from the past
            var interval = (timePicker.Value).Subtract(DateTime.Now);
            if (interval.TotalSeconds < 0)
            {
                timePicker.Value = timePicker.Value.AddDays(1);
            }
        }
    }
}
