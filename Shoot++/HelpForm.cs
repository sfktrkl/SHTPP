using System;
using System.Windows.Forms;

namespace Shoot
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            UiManager.CloseHelpForm();
        }
    }
}