using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;



namespace PickingTheStones
{

    public class PictureBoxes
    {
        private static MainPage mn= new MainPage();
        private Image mStn =mn.pbstn.BackgroundImage;
        private Image gStn = mn.pbgstn.BackgroundImage;
        private Image wall = mn.pbwall.BackgroundImage;

        const int startPoint = 5;
        const int pbSize = 75;
        private int dama;

        PictureBox[,] pb;
        Label lbl;

        public PictureBoxes(int dama)
        {
            this.dama = dama;
            this.pb = new PictureBox[dama,dama];
        }
        public void insertPB(MainPage main)
        {
            
            for(int i = 0; i < dama; i ++)
            {
                for(int j =0; j < dama; j++)
                {
                    pb[i, j] = new PictureBox();
                    SetColor_pb(0, i, j);
                    pb[i, j].Size = new Size(pbSize, pbSize);
                    pb[i, j].Location = new Point(startPoint + pbSize * j, 5 + pbSize * i);
                    pb[i, j].Click += new EventHandler(this.Click_pb);
                    main.Controls.Add(pb[i, j]);

                }
            }

            PictureBox[] stones = new PictureBox[3];
            for (int i = 0; i < 3; i ++){

                stones[i] = new PictureBox();
                stones[i].BackColor = Color.Transparent;
                stones[i].Size = new Size(100, 100);
                stones[i].BackgroundImageLayout = ImageLayout.Stretch;

                lbl = new Label();
                lbl.Font = new Font("Arial", 10, FontStyle.Bold);
                lbl.AutoSize = true;
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = Color.Black;

                if (i == 0)
                {
                    stones[i].BackgroundImage = mStn;
                    stones[i].Location = new Point(this.pb[0, dama - 1].Location.X + 250, this.pb[0, dama - 1].Location.Y);

                    lbl.Text = "Ana Taş";
                    lbl.Location = new Point(stones[i].Location.X -stones[i].Height*21/20, stones[i].Location.Y +stones[i].Height /( 5/2));
                }
                else if (i == 1)
                {
                    stones[i].BackgroundImage = gStn;
                    stones[i].Location = new Point(this.pb[0, dama - 1].Location.X + 250, this.pb[0, dama - 1].Location.Y+120);

                    lbl.Text = "Toplanacak Taş";
                    lbl.Location = new Point(stones[i].Location.X - stones[i].Height * 25 / 20, stones[i].Location.Y + stones[i].Height /(5/2));
                }
                else
                {
                    stones[i].BackgroundImage = wall;
                    stones[i].Location = new Point(this.pb[0, dama - 1].Location.X + 250, this.pb[0, dama - 1].Location.Y+240);
                    lbl.Text = "Duvar";
                    lbl.Location = new Point(stones[i].Location.X - stones[i].Height * 13 / 20, stones[i].Location.Y + stones[i].Height / 3);
                }

                main.Controls.Add(stones[i]);
                main.Controls.Add(lbl);

            }
        }

        internal void SetColor_pb(int clr, int x,int y)  // clr= 0 -> set color black-white clr!=0 -> set color green-darkgreen
        {
            
            if ((x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1))
            {
                //black     //darkgreen
                if (clr == 0)
                    this.pb[x, y].BackColor = Color.Black;
                else
                    this.pb[x, y].BackColor = Color.DarkGreen;

            }
            else if ((y % 2 == 1 && x % 2 == 0) || (y % 2 == 0 && x % 2 == 1))
            {
                //white smoke
                if (clr == 0)
                    this.pb[x, y].BackColor = Color.WhiteSmoke;
                else
                    this.pb[x, y].BackColor = Color.Green;
            }

        }


        private void Click_pb (Object sender, EventArgs e)
        {
            PictureBox pb =sender as PictureBox;
            pb.BackColor = Color.Red;
            
        }
        private void Click_MainStone(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            MessageBox.Show("Insert The Main Stone");
        }
        
    }
}
