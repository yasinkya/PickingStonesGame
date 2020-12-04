using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using Microsoft.VisualBasic;

namespace PickingTheStones
{

    public class CreateGame
    {
        private static MainPage main_Page = new MainPage();
        private StartGame start;

        private Image image_RedStn = main_Page.pbstn.BackgroundImage;
        private Image image_GreenStn = main_Page.pbgstn.BackgroundImage;
        private Image image_wall = main_Page.pbwall.BackgroundImage;

        const int startPoint = 5;
        const int pbSize = 75;
        private int dama;

        PictureBox[] stones = new PictureBox[3];
        public PictureBox[,] pbx;   //pbx[y,x]
        Button btnStart = new Button();
        Label lbl;

        public CreateGame(int dama)
        {
            this.dama = dama;
            this.pbx = new PictureBox[dama, dama];
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
                    pbx[y, x] = new PictureBox();
                    SetColor_pb(0, y, x);
                    MakeAccessible_pbx(false, y, x  );
                    pbx[y, x].Size = new Size(pbSize, pbSize);
                    pbx[y, x].Location = new Point(startPoint + pbSize * x, startPoint + pbSize * y);
                    pbx[y, x].Click += new EventHandler(this.Click_pb);
                    pbx[y, x].Name = "pb" + y.ToString() + x.ToString();
                    pbx[y, x].BackgroundImageLayout = ImageLayout.Stretch;
                    main.Controls.Add(pbx[y, x]);
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
                    stones[i].BackgroundImage = image_RedStn;
                    stones[i].Location = new Point(this.pbx[0, dama - 1].Location.X + 250, this.pbx[0, dama - 1].Location.Y);
                    stones[i].Click += new EventHandler(this.Click_MainStone);

                    lbl.Text = "Ana Taş";
                    lbl.Location = new Point(stones[i].Location.X - stones[i].Height * 21 / 20, stones[i].Location.Y + stones[i].Height / (5 / 2));
                }
                else if (i == 1)
                {
                    stones[i].BackgroundImage = image_GreenStn;
                    stones[i].Location = new Point(this.pbx[0, dama - 1].Location.X + 250, this.pbx[0, dama - 1].Location.Y + 120);
                    stones[i].Click += new EventHandler(this.Click_PickStone);
                    lbl.Text = "Toplanacak Taş";
                    lbl.Location = new Point(stones[i].Location.X - stones[i].Height * 25 / 20, stones[i].Location.Y + stones[i].Height / (5 / 2));
                }
                else
                {
                    stones[i].BackgroundImage = image_wall;
                    stones[i].Location = new Point(this.pbx[0, dama - 1].Location.X + 250, this.pbx[0, dama - 1].Location.Y + 240);
                    stones[i].Click += new EventHandler(this.Click_Wall);
                    lbl.Text = "Duvar";
                    lbl.Location = new Point(stones[i].Location.X - stones[i].Height * 13 / 20, stones[i].Location.Y + stones[i].Height / 3);
                }

                main.Controls.Add(stones[i]);
                main.Controls.Add(lbl);

            }

            //add start button
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
            for (int y = 0; y < dama; y++)
            {
                for (int x = 0; x < dama; x++)
                {
                    if ((y % 2 == 0 && x % 2 == 0) || (y % 2 == 1 && x % 2 == 1))
                    {
                        //black     //darkgreen
                        if (clr == 0)
                            this.pbx[y, x].BackColor = Color.Black;
                        else
                            this.pbx[y, x].BackColor = Color.DarkGreen;

                    }
                    else if ((x % 2 == 1 && y % 2 == 0) || (x % 2 == 0 && y % 2 == 1))
                    {
                        //white smoke
                        if (clr == 0)
                            this.pbx[y, x].BackColor = Color.WhiteSmoke;
                        else
                            this.pbx[y, x].BackColor = Color.Green;
                    }

                }
            }
        }
       
        internal void SetColor_pb(int clr, int y, int x)  //for selected picturebox :  clr= 0 -> set color black-white clr!=0 -> set color green-darkgreen
        {

            if ((y % 2 == 0 && x % 2 == 0) || (y % 2 == 1 && x % 2 == 1))
            {
                //black     //darkgreen
                if (clr == 0)
                    this.pbx[y, x].BackColor = Color.Black;
                else
                    this.pbx[y, x].BackColor = Color.DarkGreen;

            }
            else if ((x % 2 == 1 && y % 2 == 0) || (x % 2 == 0 && y % 2 == 1))
            {
                //white smoke
                if (clr == 0)
                    this.pbx[y, x].BackColor = Color.WhiteSmoke;
                else
                    this.pbx[y, x].BackColor = Color.Green;
            }


        }
        
        internal void MakeAccessible_pbx(bool make) //  for all make true or false 
        {
            for (int y = 0; y < dama; y++)
            {
                for (int x = 0; x < dama; x++)
                {
                    this.pbx[y, x].Enabled = make;
                }
            }
        }

        public void MakeAccessible_pbx(bool make, int y,int x)  //  for selected pbx make true or false
        {
            this.pbx[y, x].Enabled = make;
        }

        LinkedList<string> pickStoneList = new LinkedList<string>();
        LinkedList<string> wallsIn = new LinkedList<string>();
        int toplanacakTasSayısı = 0, duvarSayısı = 0;
        private PictureBox clickedPb;
        bool ismainstone;
        bool ispickStone;
        bool iswall;
        string mainIn;
        
        private void Click_pb(Object sender, EventArgs e)
        {
            clickedPb = sender as PictureBox;
            if (!ismainstone)
            {
                clickedPb.BackgroundImage = image_RedStn;
                clickedPb.Enabled = false;
                SetColor_pb(0);
                MakeAccessible_pbx(false);
                mainIn = clickedPb.Name;
                ismainstone = true;
            }
            if (toplanacakTasSayısı != 3 && ispickStone)
            {
                toplanacakTasSayısı++;
                ispickStone = false;
                clickedPb.BackgroundImage = image_GreenStn;
                SetColor_pb(0);
                MakeAccessible_pbx(false);
                pickStoneList.AddLast(clickedPb.Name);

            }
            
            if (iswall && duvarSayısı!=3)
            {
                duvarSayısı++;
                iswall = false;
                clickedPb.BackgroundImage = image_wall;
                SetColor_pb(0);
                MakeAccessible_pbx(false);
                wallsIn.AddLast(clickedPb.Name);
            }
        }
        
        private void Click_MainStone(object sender, EventArgs e)    // Main Stone click 
        {
            clickedPb = sender as PictureBox;
            clickedPb.Enabled = false;
            SetColor_pb(1);
            MakeAccessible_pbx(true);
        }

        private void Click_PickStone(object sender, EventArgs e)    //picking stone click
        {

            if (toplanacakTasSayısı != 3&&ismainstone) //is nain stone inserted
            {
                SetColor_pb(1);
                MakeAccessible_pbx(true);
                ispickStone = true;
            }
            else
            {
                MessageBox.Show("Max Stone 3 or Firstly add Main Stone");
            }
            
        }

        private void Click_Wall(object sender, EventArgs e)
        {
            if(duvarSayısı != 3 && ismainstone)
            {
                SetColor_pb(1);
                MakeAccessible_pbx(true);
                iswall = true;
            }
            else
            {
                MessageBox.Show("All walls already inserted or firstly add main stone ");
            }
            
        }

        internal void btnStart_Click(object sender, EventArgs e)
        {
            foreach(PictureBox pb in stones)
            {
                pb.Enabled = false;
            }
            this.start = new StartGame(this.pbx,pickStoneList,wallsIn,mainIn,this.dama);
            btnStart.Enabled = false;
        }

    }
}
