using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Shoot
{
    public partial class MissionForm : Form
    {
        public static List<string> enabledMissions;

        public MissionForm()
        {
            InitializeComponent();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            UiManager.CloseMissionForm(null, null);
        }

        public static void SearchInEnabledMissions(string missionPassed)
        {
            if (!enabledMissions.Contains(missionPassed))
            {
                FileReadWrite.AddToLoginFile(missionPassed);
                enabledMissions.Add(missionPassed);
            }
        }
    }
}