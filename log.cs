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
    public partial class log : Form
    {
        public log()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void log_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                    (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

            List<Button> buttons = new List<Button>();
            for (int i = 0; i < 10; i++)
            {
                Button newButton = new Button();
                buttons.Add(newButton);
                this.Controls.Add(newButton);
            }
        }

        private void btnSingle_Click(object sender, EventArgs e)
        {
            if(false )//cbxDama.SelectedIndex==-1 || cbxDif.SelectedIndex == -1)
            {
                MessageBox.Show("Please select diff and dama size");
            }
            else
            {
                

            }
            
            

        }
    }
}
