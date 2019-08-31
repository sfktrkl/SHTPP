using System;
using System.Windows.Forms;

namespace Shoot
{
    public partial class MissionForm : Form
    {
        public MissionForm()
        {
            InitializeComponent();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            UiManager.CloseMissionForm(null, null);
        }
    }
}