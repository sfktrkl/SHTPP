using System;
using System.Windows.Forms;

namespace Shoot
{
    public static class UiManager
    {
        private static Form mainForm { get; set; }
        private static Form currentForm { get; set; }
        private static HelpForm helpForm { get; set; }
        public static DebugForm debugForm { get; set; }

        public static Form Init()
        {
            mainForm = new LoginForm();
            mainForm.Show();
            currentForm = mainForm;
            helpForm = null;
            debugForm = null;
            return mainForm;
        }

        public static void ClosingGameForm(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        public static void CloseGameForm()
        {
            currentForm.FormClosing -= new FormClosingEventHandler(ClosingGameForm);
            currentForm.Close();
            if (helpForm != null)
                helpForm.Close();
            if (debugForm != null)
                debugForm.Close();
            CreateMissionForm();
        }

        public static void CloseLoginForm()
        {
            mainForm.Close();
        }

        public static void CloseMissionForm(object sender, FormClosingEventArgs e)
        {
            mainForm.Close();
        }

        public static void CloseHelpForm()
        {
            if (helpForm != null)
                helpForm.Close();
            helpForm = null;
        }

        public static void CloseDebugForm()
        {
            if (debugForm != null)
                debugForm.Close();
            debugForm = null;
        }

        public static void CreateMissionForm()
        {
            mainForm.Hide();
            currentForm = new MissionForm();
            currentForm.Show();
            currentForm.FormClosing += new FormClosingEventHandler(CloseMissionForm);
        }

        public static void CreateGameForm(Mission mission)
        {
            currentForm.FormClosing -= new FormClosingEventHandler(CloseMissionForm);
            currentForm.Close();
            currentForm = new GameForm(mission);
            currentForm.Show();
            currentForm.FormClosing += new FormClosingEventHandler(ClosingGameForm);
        }

        public static void CreateHelpForm()
        {
            CloseHelpForm();
            helpForm = new HelpForm();
            helpForm.Show();
        }

        public static void CreateDebugForm(string[] debugOutputs)
        {
            CloseDebugForm();
            debugForm = new DebugForm(debugOutputs);
            debugForm.Show();
        }
    }
}