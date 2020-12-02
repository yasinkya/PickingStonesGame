using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace PickingTheStones
{

    public class CreateGame
    {
        private static MainPage mn = new MainPage();
        private Image mStn = mn.pbstn.BackgroundImage;
        private Image gStn = mn.pbgstn.BackgroundImage;
        private Image wall = mn.pbwall.BackgroundImage;

        const int startPoint = 5;
        const int pbSize = 75;
        private int dama;

        PictureBox[] stones = new PictureBox[3];
        PictureBox[,] pb;
        Label lbl;

        public CreateGame(int dama)
        {
            this.dama = dama;
            this.pb = new PictureBox[dama, dama];
            //MessageBox.Show("Welcome, For play game; \n\n1- Click to Main Stone and chose anywhere, Where will be the main stone. " +
            //    "\n2. Than insert green stones"+
            //    "\n3. If you want insert the wall block"+
            //    "\n4. Click to start button");
        }

        public void insertCompanents(MainPage main)
        {
            //insert dama as pictureboxes
            for (int y = 0; y < dama; y++)
            {
                for (int x = 0; x < dama; x++)
                {
                    pb[y, x] = new PictureBox();
                    SetColor_pb(0, y, x);
                    Enabled_pb(false, y, x);
                    pb[y, x].Size = new Size(pbSize, pbSize);
                    pb[y, x].Location = new Point(startPoint + pbSize * x, 5 + pbSize * y);
                    pb[y, x].Click += new EventHandler(this.Click_pb);
                    pb[y, x].Name = "pb" + x.ToString() + y.ToString();
                    pb[y, x].BackgroundImageLayout = ImageLayout.Stretch;
                    main.Controls.Add(pb[y, x]);
                }
            }

            //insert stones pictureboxes
            for (int i = 0; i < 3; i++)
            {

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
                    stones[i].Click += new EventHandler(this.Click_MainStone);

                    lbl.Text = "Ana Taş";
                    lbl.Location = new Point(stones[i].Location.X - stones[i].Height * 21 / 20, stones[i].Location.Y + stones[i].Height / (5 / 2));
                }
                else if (i == 1)
                {
                    stones[i].BackgroundImage = gStn;
                    stones[i].Location = new Point(this.pb[0, dama - 1].Location.X + 250, this.pb[0, dama - 1].Location.Y + 120);
                    stones[i].Click += new EventHandler(this.Click_PickStone);
                    lbl.Text = "Toplanacak Taş";
                    lbl.Location = new Point(stones[i].Location.X - stones[i].Height * 25 / 20, stones[i].Location.Y + stones[i].Height / (5 / 2));
                }
                else
                {
                    stones[i].BackgroundImage = wall;
                    stones[i].Location = new Point(this.pb[0, dama - 1].Location.X + 250, this.pb[0, dama - 1].Location.Y + 240);
                    stones[i].Click += new EventHandler(this.Click_Wall);
                    lbl.Text = "Duvar";
                    lbl.Location = new Point(stones[i].Location.X - stones[i].Height * 13 / 20, stones[i].Location.Y + stones[i].Height / 3);
                }

                main.Controls.Add(stones[i]);
                main.Controls.Add(lbl);

            }

            //add start button
            Button btnStart = new Button();
            btnStart.BackColor = Color.White;
            btnStart.Text = "Start Game";
            btnStart.Font = new Font("Seris", 10, FontStyle.Regular);
            btnStart.AutoSize = true;
            btnStart.Location = new Point(stones[2].Location.X - 50, stones[2].Location.Y + 150);
            btnStart.Click += new EventHandler(this.btnStart_Click);
            main.Controls.Add(btnStart);
        }

        internal void SetColor_pb(int clr)  // for all : clr= 0 -> set color black-white clr!=0 -> set color green-darkgreen
        {
            for (int x = 0; x < dama; x++)
            {
                for (int y = 0; y < dama; y++)
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
            }
        }
       
        internal void SetColor_pb(int clr, int x, int y)  //for selected picturebox :  clr= 0 -> set color black-white clr!=0 -> set color green-darkgreen
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
        
        internal void Enabled_pb(bool make) //  for all make true or false 
        {
            for (int x = 0; x < dama; x++)
            {
                for (int y = 0; y < dama; y++)
                {
                    this.pb[x, y].Enabled = make;
                }
            }
        }

        internal void Enabled_pb(bool make, int x,int y)  //  for selected pbx make true or false
        {
            this.pb[x, y].Enabled = make;
        }


        private PictureBox clickedPb;
        bool mainstone;
        bool pickStone;
        string mainIn;
        LinkedList<string> pickStoneList= new LinkedList<string>();
        int nm = 0;
        private void Click_pb(Object sender, EventArgs e)
        {
            clickedPb = sender as PictureBox;
            if (!mainstone)
            {
                clickedPb.BackgroundImage = mStn;
                SetColor_pb(0);
                Enabled_pb(false);
                mainIn = clickedPb.Name;
                mainstone = true;
                MessageBox.Show(mainIn);
            }
            if (nm != 15&&pickStone)
            {
                nm++;
                pickStone = false;
                clickedPb.BackgroundImage = gStn;
                SetColor_pb(0);
                Enabled_pb(false);
                pickStoneList.AddLast(clickedPb.Name);

            }
            
        }
        
        private void Click_MainStone(object sender, EventArgs e)
        {
            clickedPb = sender as PictureBox;
            clickedPb.Enabled = false;
           // MessageBox.Show("Insert The Main Stone");
            SetColor_pb(1);
            Enabled_pb(true);
        }

        private void Click_PickStone(object sender, EventArgs e)
        {
            clickedPb = sender as PictureBox;
            if (nm != 15&&mainstone)
            {
                //MessageBox.Show("Insert The Picking Stone");
                SetColor_pb(1);
                Enabled_pb(true);
                pickStone = true;
            }
            else
            {
                MessageBox.Show("Max Stone 15 or Firstly add Main Stone");
                clickedPb.Enabled = false;
            }
        }

        private void Click_Wall(object sender, EventArgs e)
        {
            MessageBox.Show("Insert The wall");
            SetColor_pb(1);
            Enabled_pb(true);
        }

        internal void btnStart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

    }
}
