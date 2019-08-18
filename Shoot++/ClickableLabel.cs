using System;
using System.Windows.Forms;

namespace Shoot
{
    public class ClickableLabel : System.Windows.Forms.Label
    {
        public ClickableLabel()
        {
            this.MouseHover += new EventHandler(HoverMouse);
            this.MouseLeave += new EventHandler(LeaveMouse);
            this.MouseMove += new MouseEventHandler(MoveMouse);
        }

        private void HoverMouse(object sender, EventArgs e)
        {
            this.ForeColor = System.Drawing.Color.Red;
            Cursor.Current = Cursors.Hand;
        }

        private void LeaveMouse(object sender, EventArgs e)
        {
            this.ForeColor = System.Drawing.Color.Black;
            Cursor.Current = Cursors.Default;
        }

        private void MoveMouse(object sender, MouseEventArgs e)
        {
            this.ForeColor = System.Drawing.Color.Red;
            Cursor.Current = Cursors.Hand;
        }
    }
}