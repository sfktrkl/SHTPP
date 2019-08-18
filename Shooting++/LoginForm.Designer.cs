namespace Shooting__
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Start = new System.Windows.Forms.Button();
            this.idLabel = new System.Windows.Forms.Label();
            this.pwLabel = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.pwBox = new System.Windows.Forms.TextBox();
            this.quit = new Shooting__.ClickableLabel();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Algerian", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.Location = new System.Drawing.Point(162, 191);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(168, 67);
            this.Start.TabIndex = 0;
            this.Start.Text = "Go!!";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.start_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Algerian", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.Location = new System.Drawing.Point(51, 91);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(53, 35);
            this.idLabel.TabIndex = 1;
            this.idLabel.Text = "ID:";
            // 
            // pwLabel
            // 
            this.pwLabel.AutoSize = true;
            this.pwLabel.Font = new System.Drawing.Font("Algerian", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwLabel.Location = new System.Drawing.Point(36, 140);
            this.pwLabel.Name = "pwLabel";
            this.pwLabel.Size = new System.Drawing.Size(68, 35);
            this.pwLabel.TabIndex = 2;
            this.pwLabel.Text = "PW:";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Algerian", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(136, 21);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(231, 54);
            this.title.TabIndex = 3;
            this.title.Text = "SHOOT++";
            // 
            // idBox
            // 
            this.idBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.idBox.Font = new System.Drawing.Font("Algerian", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idBox.Location = new System.Drawing.Point(110, 90);
            this.idBox.MaximumSize = new System.Drawing.Size(200, 36);
            this.idBox.MinimumSize = new System.Drawing.Size(300, 36);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(300, 36);
            this.idBox.TabIndex = 4;
            // 
            // pwBox
            // 
            this.pwBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.pwBox.Font = new System.Drawing.Font("Algerian", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwBox.Location = new System.Drawing.Point(110, 139);
            this.pwBox.MaximumSize = new System.Drawing.Size(200, 36);
            this.pwBox.MinimumSize = new System.Drawing.Size(300, 36);
            this.pwBox.Name = "pwBox";
            this.pwBox.PasswordChar = '*';
            this.pwBox.Size = new System.Drawing.Size(300, 36);
            this.pwBox.TabIndex = 5;
            // 
            // quit
            // 
            this.quit.AutoSize = true;
            this.quit.Font = new System.Drawing.Font("Algerian", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quit.Location = new System.Drawing.Point(436, 255);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(37, 35);
            this.quit.TabIndex = 6;
            this.quit.Text = "Q";
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.Start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(484, 299);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.pwBox);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.title);
            this.Controls.Add(this.pwLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shoot++ Login Screen";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label pwLabel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.TextBox pwBox;
        private ClickableLabel quit;
    }
}

