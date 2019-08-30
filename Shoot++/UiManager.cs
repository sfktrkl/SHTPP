using System;
using System.Windows.Forms;

namespace Shoot
{
    public static class UiManager
    {
        private static Form mainForm { get; set; }
        private static Form currentForm { get; set; }
        private static Form temporaryForm { get; set; }

        public static Form Init()
        {
            mainForm = new LoginForm();
            mainForm.Show();
            currentForm = mainForm;
            temporaryForm = null;
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
            if (temporaryForm != null)
                temporaryForm.Close();
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
            temporaryForm.Close();
            temporaryForm = null;
        }

        public static void CreateMissionForm()
        {
            mainForm.Hide();
            currentForm = new MissionForm();
            currentForm.Show();
            currentForm.FormClosing += new FormClosingEventHandler(CloseMissionForm);
        }

        public static void CreateGameForm(MissionDatabase.Data mission)
        {
            currentForm.FormClosing -= new FormClosingEventHandler(CloseMissionForm);
            currentForm.Close();
            currentForm = new GameForm(mission);
            currentForm.Show();
            currentForm.FormClosing += new FormClosingEventHandler(ClosingGameForm);
        }

        public static void CreateHelpForm()
        {
            temporaryForm = new HelpForm();
            temporaryForm.Show();
        }
    }
}