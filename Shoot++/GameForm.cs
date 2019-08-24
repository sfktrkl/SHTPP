using System;
using System.Windows.Forms;
using InterpreterClassLibrary;
using OSGViewClassLibrary;

namespace Shoot
{
    public partial class GameForm : Form
    {
        private OSGViewClassWrapper viewer = new OSGViewClassWrapper();
        private InterpreterClassWrapper interpreter;
        private int[] solutions;

        public GameForm(MissionDatabase.Data mission)
        {
            InitializeComponent();
            this.title.Text = mission.name;
            this.Text = mission.name;
            this.missionNote.Text = mission.note;

            string content = FileReadWrite.ReadFile(this.Text.ToString());
            if (content != null)
                this.codeText.Text = content;
            else
                this.codeText.Text = mission.code;

            solutions = mission.solutions;

            viewer.SetMission(mission.number);

            renderArea.Paint += new PaintEventHandler(Painter);
        }

        private void Painter(object sender, PaintEventArgs e)
        {
            // Renders the OSG Viewer into the drawing area
            viewer.Render(renderArea.Handle);
        }

        private void CallInterpreter(string file)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(file);

            unsafe
            {
                fixed (byte* p = bytes)
                {
                    sbyte* sp = (sbyte*)p;
                    interpreter = new InterpreterClassWrapper(sp);
                }
            }
        }

        private void GiveOutputsToViewer(int[] values)
        {
            unsafe
            {
                fixed (int* p = values)
                {
                    viewer.GiveOutputs(p);
                }
            }
        }

        private void run_Click(object sender, System.EventArgs e)
        {
            string content = this.codeText.Text.ToUpper();
            string file = FileReadWrite.WriteFile(content, this.Text.ToString());
            CallInterpreter(file);

            int[] outputs = interpreter.TakeOutputs();

            GiveOutputsToViewer(outputs);

            bool success = true;

            for (int i = 0; i < outputs.Length; i++)
            {
                if (outputs[i] != solutions[i])
                {
                    success = false;
                    break;
                }
            }

            viewer.SetSuccess(success);

            viewer.Refresh();
        }

        private void save_Click(object sender, System.EventArgs e)
        {
            string content = this.codeText.Text.ToUpper();
            FileReadWrite.WriteFile(content, this.Text.ToString());
        }

        private void back_Click(object sender, EventArgs e)
        {
            renderArea.Paint -= Painter;
            viewer.Destroy();
            UiManager.CloseGameForm();
        }
    }
}