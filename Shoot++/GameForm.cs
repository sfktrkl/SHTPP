using InterpreterClassLibrary;
using OSGViewClassLibrary;
using System;
using System.Windows.Forms;

namespace Shoot
{
    public partial class GameForm : Form
    {
        private OSGViewClassWrapper viewer = new OSGViewClassWrapper();
        private InterpreterClassWrapper interpreter;
        private int[] solutions;
        private string[] debugOutputs;
        private Mission mission;
        public static bool isDebugShoot = true;

        public GameForm(Mission mission)
        {
            InitializeComponent();

            this.mission = mission;

            RefreshTitle();

            this.missionNote.Text = mission.data.note;

            string content = FileReadWrite.ReadFile(mission.data.name);
            if (content != null)
                this.codeText.Text = content;
            else
                this.codeText.Text = mission.data.code;

            solutions = mission.data.solutions;

            viewer.SetMission(mission.data.number);
            viewer.GiveInputs(mission.data.inputs);

            renderArea.Paint += new PaintEventHandler(Painter);
        }

        private void RefreshTitle()
        {
            this.title.Tag = mission.data.number.ToString();
            if (MissionForm.enabledMissions.Contains(mission.data.number.ToString()))
                this.title.Text = mission.data.name + " - COMPLETED";
            else
                this.title.Text = mission.data.name;

            if (MissionForm.enabledMissions.Contains(mission.data.number.ToString()))
                this.Text = mission.data.name + " - COMPLETED";
            else
                this.Text = mission.data.name;
        }

        private void RefreshMission()
        {
            this.mission.RefreshMission();

            solutions = mission.data.solutions;

            viewer.SetMission(mission.data.number);
            viewer.GiveInputs(mission.data.inputs);
        }

        private void Painter(object sender, PaintEventArgs e)
        {
            // Renders the OSG Viewer into the drawing area
            viewer.Render(renderArea.Handle);
        }

        private void CallInterpreter(string file, int[] inputValues)
        {
            interpreter = new InterpreterClassWrapper(file);
            interpreter.GiveInputs(inputValues);

            //Disabled, since debugInfo button takes over the task.
            //interpreter.SetDebugMode(isDebugShoot);

            interpreter.Execute();
        }

        private void run_Click(object sender, System.EventArgs e)
        {
            RefreshMission();

            string content = this.codeText.Text.ToUpper();
            string file = FileReadWrite.WriteFile(content, mission.data.name);
            CallInterpreter(file, mission.data.inputs);

            int[] outputs = interpreter.TakeOutputs();
            debugOutputs = interpreter.TakeDebugOutputs();

            if (UiManager.debugForm != null)
                UiManager.debugForm.GetDebugOutputs(debugOutputs);

            viewer.GiveOutputs(outputs);

            bool success = true;

            for (int i = 0; i < outputs.Length; i++)
            {
                if (outputs.Length != solutions.Length)
                {
                    success = false;
                    break;
                }
                if (outputs[i] != solutions[i])
                {
                    success = false;
                    break;
                }
            }

            viewer.SetSuccess(success);

            viewer.Refresh();

            if (success)
            {
                MissionForm.SearchInEnabledMissions(mission.data.number.ToString());
                RefreshTitle();
            }
        }

        private void save_Click(object sender, System.EventArgs e)
        {
            string content = this.codeText.Text.ToUpper();
            FileReadWrite.WriteFile(content, mission.data.name);
        }

        private void back_Click(object sender, EventArgs e)
        {
            renderArea.Paint -= Painter;
            viewer.Destroy();
            UiManager.CloseGameForm();
        }

        private void help_Click(object sender, EventArgs e)
        {
            UiManager.CreateHelpForm();
        }

        private void debug_Click(object sender, EventArgs e)
        {
            UiManager.CreateDebugForm(debugOutputs);
        }
    }
}