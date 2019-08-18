using System.Windows.Forms;

namespace Shooting__
{
    public static class UiManager
    {
        public static Form mainForm { get; set; }
        public static Form currentForm { get; set; }

        public static void Init(Form form)
        {
            mainForm = form;
            currentForm = form;
        }

        public static void CloseForm()
        {
            currentForm.Close();
        }

        public static void CreateMissionForm()
        {
            mainForm.Hide();
            MissionForm missions = new MissionForm();
            missions.Show();
            currentForm = missions;
        }

        public static void CreateGameForm(MissionDatabase.Data data)
        {
            currentForm.Close();
            GameForm game = new GameForm(data);
            game.ShowDialog();
            currentForm = game;
        }
    }
}