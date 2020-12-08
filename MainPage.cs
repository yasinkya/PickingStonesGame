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
        private int diff;
        private int s_c;  // 0= server, 1= client, 2= normal

        public MainPage(int dama , int diff,int s_c=2)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            this.dama = dama;
            this.diff = diff;
            this.s_c = s_c;
        }
        public CreateGame pbxs;
        
        private void MainPage_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.SkyBlue;
            this.Size = new Size(300 + 75 * dama, 50 + 75 * dama);
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            
            pbxs = new CreateGame(dama,diff , this,this.s_c);
            pbxs.insertCompanents(this);
        }
    }
}
