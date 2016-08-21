using System;
using System.Windows.Forms;

namespace WatchDog
{
    public partial class MainUI : Form
    {
        private Controller ctrl;
        private int _wTime;

        public MainUI()
        {
            InitializeComponent();
            ctrl = Controller.Instance;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (ctrl.IsActive)
            {
                ctrl.Cancel();
                buttonStart.Text = "Activate";
                label1.Text = "";
                timePicker.Value = DateTime.Now;
            }
            else
            {          
                DateTime offTime = timePicker.Value;
                TimeSpan interval = offTime.Subtract(DateTime.Now);

                ctrl.Time = (int)interval.TotalMilliseconds;
                ctrl.Set();
                Console.WriteLine("interval: " + interval.TotalMilliseconds + "ms");
                

                buttonStart.Text = "Cancel";
                label1.Text = "Computer sleeping in " + (int)interval.TotalMinutes;
            }
            
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
