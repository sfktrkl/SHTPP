using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shooting__
{
    public static class UiManager
    {
        public static Form mainForm { get; set; }

        public static void CloseForm()
        {
            mainForm.Close();
        }

        public static void CreateMissionForm()
        {
            mainForm.Hide();
            MissionForm missions = new MissionForm();
            missions.ShowDialog();
            mainForm.Close();
            mainForm = missions;
        }

        public static void CreateGameForm()
        {

        }
    }
}
