using System.Windows.Forms;

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
        }
    }
}