using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Shooting__
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void start_Click(object sender, EventArgs e)
        {
            string id = idBox.Text.ToString();
            string pw = pwBox.Text.ToString();

            if (id.Length < 5)
            {
                MessageBox.Show("ID is too short", "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pw.Length < 5)
            {
                MessageBox.Show("PW is too short", "PW Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var fileReadWrite = new FileReadWrite(id, pw);
            var condition = fileReadWrite.CheckFile();

            if (condition == FileReadWrite.FileCondition.DirectoryNotExist)
            {
                if (MessageBox.Show("Account could not find. " +
                    "\nDo you want to create now?? " +
                    "\nYour ID: " + id + " and your PW: " + pw,
                    "No User Account", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    fileReadWrite.WriteFile(new List<string> { id, pw, "0" });
                }
            }
            else if (condition == FileReadWrite.FileCondition.FileNotExist)
            {
                if (MessageBox.Show("File could not find. Please check your save file. " +
                                    "\nOr Do you want to register?" +
                                    "\nYour ID: " + id + " and your PW: " + pw,
                                    "No User File", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    fileReadWrite.WriteFile(new List<string> { id, pw, "0" });
                }
            }
            else if (condition == FileReadWrite.FileCondition.FileExist)
            {
                List<string> read = fileReadWrite.ReadFile();

                if (HashGenerator.VerifyHash(read[0], id) && HashGenerator.VerifyHash(read[1], pw))
                {
                    MessageBox.Show("Simdilik OKEY!!", "gogoogo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    MessageBox.Show("Your password is wrong!!", "WRONG PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Something gone wrong.", "Unkown Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quit_MouseHover(object sender, EventArgs e)
        {
            this.quit.ForeColor = System.Drawing.Color.Red;
        }

        private void quit_MouseLeave(object sender, EventArgs e)
        {
            this.quit.ForeColor = System.Drawing.Color.Black;
        }
    }
}