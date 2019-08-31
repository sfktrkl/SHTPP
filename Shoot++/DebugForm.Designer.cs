namespace Shoot
{
    partial class DebugForm
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
            this.debugText = new System.Windows.Forms.RichTextBox();
            this.quit = new Shoot.ClickableLabel();
            this.debugInfo = new Shoot.DebugLabel();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // debugText
            // 
            this.debugText.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugText.Location = new System.Drawing.Point(12, 55);
            this.debugText.Name = "debugText";
            this.debugText.ReadOnly = true;
            this.debugText.Size = new System.Drawing.Size(760, 448);
            this.debugText.TabIndex = 0;
            this.debugText.Text = "";
            // 
            // quit
            // 
            this.quit.AutoSize = true;
            this.quit.Font = new System.Drawing.Font("Algerian", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quit.Location = new System.Drawing.Point(684, 517);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(88, 35);
            this.quit.TabIndex = 9;
            this.quit.Text = "Quit";
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // debugInfo
            // 
            this.debugInfo.AutoSize = true;
            this.debugInfo.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugInfo.ForeColor = System.Drawing.Color.Green;
            this.debugInfo.Location = new System.Drawing.Point(12, 506);
            this.debugInfo.Name = "debugInfo";
            this.debugInfo.Size = new System.Drawing.Size(239, 26);
            this.debugInfo.TabIndex = 10;
            this.debugInfo.Text = "DEBUG SHOOT = ???";
            this.debugInfo.Click += new System.EventHandler(this.debugInfo_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Algerian", 24F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(330, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(121, 35);
            this.title.TabIndex = 11;
            this.title.Text = "Debug";
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.title);
            this.Controls.Add(this.debugInfo);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.debugText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebugForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debug";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox debugText;
        private ClickableLabel quit;
        private DebugLabel debugInfo;
        private System.Windows.Forms.Label title;
    }
}