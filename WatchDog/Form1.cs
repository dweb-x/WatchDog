using System;
using System.Windows.Forms;

namespace WatchDog
{
    public partial class MainUI : Form
    {
        private Controller ctrl;

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
            }
            else
            {
                ctrl.Set();
                buttonStart.Text = "Cancel";
            }
            
        }
    }
}
