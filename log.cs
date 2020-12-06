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

        }

        private void btnSingle_Click(object sender, EventArgs e)
        {
            if(cbxDama.SelectedIndex==-1 || cbxDif.SelectedIndex == -1)
            {
                MessageBox.Show("Please select diff and dama size");
            }
            else
            {
                int diff;
                if (cbxDif.SelectedItem.ToString().ToLower() == "easy")
                    diff = 1;
                else if (cbxDif.SelectedItem.ToString().ToLower() == "middle")
                    diff = 2;
                else
                    diff = 3;

                MainPage main = new MainPage(Convert.ToInt32(cbxDama.SelectedItem),diff);
                main.ShowDialog();
                this.Close();
                

            }
            
            

        }
    }
}
