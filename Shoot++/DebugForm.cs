using System;
using System.Windows.Forms;

namespace Shoot
{
    public partial class DebugForm : Form
    {
        private string[] debugOutputs;

        public DebugForm(string[] debugOutputs)
        {
            InitializeComponent();
            this.debugInfo.RefreshText();
            this.debugOutputs = debugOutputs;
            RefreshDebugText();
        }

        public void GetDebugOutputs(string[] debugOutputs)
        {
            this.debugOutputs = debugOutputs;
            RefreshDebugText();
        }

        private void RefreshDebugText()
        {
            this.debugText.Clear();
            if (debugOutputs == null) return;
            foreach (string line in debugOutputs)
            {
                if (GameForm.isDebugShoot == false)
                {
                    if (line.Substring(0, 7) != "SHOOT: ")
                        this.debugText.Text += line.Substring(7, line.Length - 7) + Environment.NewLine;
                }
                else
                    this.debugText.Text += line + Environment.NewLine;
            }
        }

        private void quit_Click(object sender, EventArgs e)
        {
            UiManager.CloseDebugForm();
        }

        private void debugInfo_Click(object sender, EventArgs e)
        {
            GameForm.isDebugShoot = !GameForm.isDebugShoot;
            this.debugInfo.RefreshText();
            RefreshDebugText();
        }
    }
}
