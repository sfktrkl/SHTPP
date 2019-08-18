using System;
using System.Windows.Forms;
using InterpreterClassLibrary;

namespace Shooting__
{
    public partial class GameForm : Form
    {
        public GameForm(MissionDatabase.Data data)
        {
            InitializeComponent();
            this.title.Text = data.name;
            this.Text = data.name;
            this.missionNote.Text = data.note;

            string content = FileReadWrite.ReadFile(this.Text.ToString());
            if (content != null)
                this.codeText.Text = content;
            else
                this.codeText.Text = data.code;
        }

        private void CallWrapper (string file)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(file);

            unsafe
            {
                fixed (byte* p = bytes)
                {
                    sbyte* sp = (sbyte*)p;
                    InterpreterClassWrapper wrapper = new InterpreterClassWrapper(sp);
                }
            }
        }

        private void run_Click(object sender, System.EventArgs e)
        {
            string content = this.codeText.Text.ToUpper();
            string file = FileReadWrite.WriteFile(content, this.Text.ToString());
            CallWrapper(file);
        }

        private void save_Click(object sender, System.EventArgs e)
        {
            string content = this.codeText.Text.ToUpper();
            FileReadWrite.WriteFile(content, this.Text.ToString());
        }

        private void back_Click(object sender, EventArgs e)
        {
            UiManager.CloseGameForm();
        }
    }
}