using System;
using System.Windows.Forms;

namespace Shoot
{
    public class ColoredLabel : Label
    {
        protected System.Drawing.Color idleColor = System.Drawing.Color.Black;

        public ColoredLabel()
        {
            this.TextChanged += new EventHandler(RefreshColor);
        }

        virtual protected void RefreshColor(object sender, EventArgs e)
        {
            if (this.Tag == null) return;

            if (MissionForm.enabledMissions.Contains(this.Tag.ToString()))
                idleColor = System.Drawing.Color.Green;
            else
                idleColor = System.Drawing.Color.Red;

            this.ForeColor = idleColor;
        }
    }

    public class ClickableLabel : ColoredLabel
    {
        protected System.Drawing.Color hoverColor = System.Drawing.Color.Red;

        public ClickableLabel() : base()
        {
            this.MouseHover += new EventHandler(HoverMouse);
            this.MouseLeave += new EventHandler(LeaveMouse);
            this.MouseMove += new MouseEventHandler(MoveMouse);
        }

        virtual protected void HoverMouse(object sender, EventArgs e)
        {
            this.ForeColor = hoverColor;
            Cursor.Current = Cursors.Hand;
        }

        virtual protected void LeaveMouse(object sender, EventArgs e)
        {
            this.ForeColor = idleColor;
            Cursor.Current = Cursors.Default;
        }

        virtual protected void MoveMouse(object sender, MouseEventArgs e)
        {
            this.ForeColor = hoverColor;
            Cursor.Current = Cursors.Hand;
        }
    }

    public class MissionLabel : ClickableLabel
    {
        public MissionLabel() : base()
        {
            this.MouseClick += new MouseEventHandler(ClickMouse);

            hoverColor = System.Drawing.Color.Blue;
            idleColor = System.Drawing.Color.Red;
        }

        override protected void RefreshColor(object sender, EventArgs e)
        {
            if (MissionForm.enabledMissions.Contains(this.Tag.ToString()))
                idleColor = System.Drawing.Color.Green;
            else
                idleColor = System.Drawing.Color.Red;

            this.ForeColor = idleColor;
        }

        virtual protected void ClickMouse(object sender, MouseEventArgs e)
        {
            UiManager.CreateGameForm(new Mission(this.Tag.ToString()));
        }
    }

    public class DebugLabel : ClickableLabel
    {
        private string text;

        public DebugLabel() : base()
        {
            hoverColor = System.Drawing.Color.Blue;
            idleColor = System.Drawing.Color.Red;
        }

        public void RefreshText()
        {
            if (GameForm.isDebugShoot)
                text = "DEBUG SHOOT = ON";
            else
                text = "DEBUG SHOOT = OFF";

            this.Text = text;
        }

        override protected void RefreshColor(object sender, EventArgs e)
        {
            if (GameForm.isDebugShoot)
                idleColor = System.Drawing.Color.Green;
            else
                idleColor = System.Drawing.Color.Red;

            this.ForeColor = idleColor;
        }

        override protected void LeaveMouse(object sender, EventArgs e)
        {
            this.ForeColor = idleColor;
            this.Text = text;
            Cursor.Current = Cursors.Default;
        }

    }
}