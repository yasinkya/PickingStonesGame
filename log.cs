using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PickingTheStones
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public Client client;
        public Server server;

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

        private void btnMultiple_Click(object sender, EventArgs e)
        {
            if (cbxDama.SelectedIndex == -1 || cbxDif.SelectedIndex == -1)
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


                DialogResult yesno= MessageBox.Show("Create a Game ?", "Multiplayer", MessageBoxButtons.YesNo);
                if (yesno == DialogResult.Yes)
                {
                    this.Close();
                    server = new Server();
                    MessageBox.Show("Waiting other player");
                    // server.SocketDinle();
                }
                else
                {
                    string Ip = Interaction.InputBox("IP: ", "ENTER THE IP OF SERVER", "192.168.43.164", 
                        (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                        (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

                    this.Close();
                    client = new Client(Ip);

                }


                //MainPage main = new MainPage(Convert.ToInt32(cbxDama.SelectedItem), diff);
                //main.ShowDialog();
                //this.Close();


            }
        }
    }
}
