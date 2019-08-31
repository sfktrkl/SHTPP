using System;
using System.Windows.Forms;

namespace Shoot
{
    public class ClickableLabel : Label
    {
        public ClickableLabel()
        {
            this.MouseHover += new EventHandler(HoverMouse);
            this.MouseLeave += new EventHandler(LeaveMouse);
            this.MouseMove += new MouseEventHandler(MoveMouse);
        }

        virtual protected void HoverMouse(object sender, EventArgs e)
        {
            this.ForeColor = System.Drawing.Color.Red;
            Cursor.Current = Cursors.Hand;
        }

        virtual protected void LeaveMouse(object sender, EventArgs e)
        {
            this.ForeColor = System.Drawing.Color.Black;
            Cursor.Current = Cursors.Default;
        }

        virtual protected void MoveMouse(object sender, MouseEventArgs e)
        {
            this.ForeColor = System.Drawing.Color.Red;
            Cursor.Current = Cursors.Hand;
        }
    }

    public class MissionLabel : ClickableLabel
    {
        public MissionLabel() : base()
        {
            this.MouseClick += new MouseEventHandler(ClickMouse);
        }

        virtual public void ClickMouse(object sender, MouseEventArgs e)
        {
            UiManager.CreateGameForm(new Mission(this.Tag.ToString()));
        }
    }

    public class DebugLabel : ClickableLabel
    {
        public DebugLabel() : base()
        {
            RefreshColor();
        }

        public void RefreshColor()
        {
            if (GameForm.isDebugShoot)
            {
                this.ForeColor = System.Drawing.Color.Green;
                this.Text = "DEBUG SHOOT = ON";
            }
            else
            {
                this.ForeColor = System.Drawing.Color.Red;
                this.Text = "DEBUG SHOOT = OFF";
            }
            Cursor.Current = Cursors.Default;
        }

        override protected void HoverMouse(object sender, EventArgs e)
        {
            this.ForeColor = System.Drawing.Color.Blue;
            Cursor.Current = Cursors.Hand;
        }

        override protected void LeaveMouse(object sender, EventArgs e)
        {
            RefreshColor();
        }

        override protected void MoveMouse(object sender, MouseEventArgs e)
        {
            this.ForeColor = System.Drawing.Color.Blue;
            Cursor.Current = Cursors.Hand;
        }

    }
}