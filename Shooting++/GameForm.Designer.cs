namespace Shooting__
{
    partial class GameForm
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
            this.OSGPanel = new System.Windows.Forms.Panel();
            this.codeText = new System.Windows.Forms.RichTextBox();
            this.title = new System.Windows.Forms.Label();
            this.missionNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OSGPanel
            // 
            this.OSGPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.OSGPanel.Location = new System.Drawing.Point(600, 150);
            this.OSGPanel.Name = "OSGPanel";
            this.OSGPanel.Size = new System.Drawing.Size(800, 600);
            this.OSGPanel.TabIndex = 0;
            // 
            // codeText
            // 
            this.codeText.DetectUrls = false;
            this.codeText.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.codeText.Location = new System.Drawing.Point(40, 150);
            this.codeText.Name = "codeText";
            this.codeText.Size = new System.Drawing.Size(520, 600);
            this.codeText.TabIndex = 1;
            this.codeText.Text = "";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Algerian", 24F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(600, 10);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(249, 35);
            this.title.TabIndex = 2;
            this.title.Text = "Mission Name:";
            // 
            // missionNote
            // 
            this.missionNote.AutoSize = true;
            this.missionNote.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missionNote.Location = new System.Drawing.Point(40, 50);
            this.missionNote.MaximumSize = new System.Drawing.Size(1360, 90);
            this.missionNote.Name = "missionNote";
            this.missionNote.Size = new System.Drawing.Size(142, 21);
            this.missionNote.TabIndex = 3;
            this.missionNote.Text = "Mission Note: ";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 861);
            this.Controls.Add(this.missionNote);
            this.Controls.Add(this.title);
            this.Controls.Add(this.codeText);
            this.Controls.Add(this.OSGPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel OSGPanel;
        private System.Windows.Forms.RichTextBox codeText;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label missionNote;
    }
}