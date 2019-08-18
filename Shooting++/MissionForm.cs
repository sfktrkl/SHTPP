using System;
using System.Windows.Forms;

namespace Shooting__
{
    public partial class MissionForm : Form
    {
        public MissionForm()
        {
            InitializeComponent();
        }

        private void tutorial1_Click(object sender, EventArgs e)
        {
            Mission mission = new Mission("t1");
            UiManager.CreateGameForm(mission.GetMission());
        }

        private void tutorial2_Click(object sender, EventArgs e)
        {
            Mission mission = new Mission("t2");
            UiManager.CreateGameForm(mission.GetMission());
        }

        private void tutorial3_Click(object sender, EventArgs e)
        {
            Mission mission = new Mission("t3");
            UiManager.CreateGameForm(mission.GetMission());
        }

        private void tutorial4_Click(object sender, EventArgs e)
        {
            Mission mission = new Mission("t4");
            UiManager.CreateGameForm(mission.GetMission());
        }

        private void tutorial5_Click(object sender, EventArgs e)
        {
            Mission mission = new Mission("t5");
            UiManager.CreateGameForm(mission.GetMission());
        }

        private void tutorial6_Click(object sender, EventArgs e)
        {
            Mission mission = new Mission("t6");
            UiManager.CreateGameForm(mission.GetMission());
        }

        private void mission1_Click(object sender, EventArgs e)
        {
            Mission mission = new Mission("m1");
            UiManager.CreateGameForm(mission.GetMission());
        }

        private void mission2_Click(object sender, EventArgs e)
        {
            Mission mission = new Mission("m2");
            UiManager.CreateGameForm(mission.GetMission());
        }
    }
}