using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickingTheStones
{
    
    public partial class MainPage : Form
    {
        private int dama;
        public MainPage()
        {
            InitializeComponent();
            this.dama = 10;
        }
        private CreateGame pbxs;
        private void MainPage_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.SkyBlue;
            this.Size = new Size(300 + 75 * dama, 50 + 75 * dama);
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            
            pbxs = new CreateGame(dama);
            StartGame start = new StartGame();
            pbxs.insertCompanents(this);
        }
    }
}
