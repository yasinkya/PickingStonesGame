using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Drawing;

namespace PickingTheStones
{


    class StartGame
    {
        MainPage forEnding;
        private PictureBox[,] pbx;
        PictureBox newSelect;
        private LinkedList<string> topla, duvar;
        Label lbl_Distance;
        private string whereMainStn;
        private string selectedPbxName;
        bool picked;
        int dama;
        int puanForWin;
        int puan = 0;

        public StartGame(PictureBox[,] pbx, LinkedList<string> topla, LinkedList<string> duvar, string whereMainStn, int dama,MainPage forEndingGame)
        {
            this.dama = dama;
            this.pbx = pbx;
            this.topla = topla;
            this.puanForWin = topla.Count();
            this.duvar = duvar;
            this.whereMainStn = whereMainStn;
            this.forEnding = forEndingGame;
            this.makeAccessible_PickingStones(true);
            this.SetClickFor_allPbx();
            this.SetDistance();
            
        }

        public void Control(string pbxName)
        {
            topla.Remove(pbxName_toPbx(pbxName).Name);
            selectedPbxName = pbxName_toPbx(pbxName).Name;
            if (CalculateDistance(pbxName_toPbx(pbxName)) <= 1)
            {
                makeAccessible(true, pbxArrayIndex(whereMainStn) / 10, pbxArrayIndex(whereMainStn) % 10);
                picked = true;
            }
        }

        private PictureBox pbxName_toPbx(string name) // get picturbox from selected pbx' name
        {
            int Y = Convert.ToInt32(name.Substring(2, 1));
            int X = Convert.ToInt32(name.Substring(3));
            return pbx[Y, X];
        }

        private int pbxArrayIndex(string name) // get indexes of selected picturbox from its name 
        {
            int Y = Convert.ToInt32(name.Substring(2, 1));
            int X = Convert.ToInt32(name.Substring(3));
            return Y * 10 + X;
        }

        private void makeAccessible_PickingStones(bool make) // picking stones' picturebox enabled 
        {
            foreach (string pbxname in topla)
            {
                //int pbxId = pbxName_toPbx(pbxname);
                pbxName_toPbx(pbxname).Enabled = make;
                pbxName_toPbx(pbxname).Click += new EventHandler(ClickSelectnewP);
            }
        }

        private void makeAccessible(bool make, int y, int x) // change pbx enabled for just one  
        {
            pbx[y, x].Enabled = make;
        }

        private void makeAccessible(bool make) // for all pbx enabled = ? 
        {
            for (int y = 0; y < dama; y++)
            {
                for (int x = 0; x < dama; x++)
                {
                    pbx[y, x].Enabled = make;
                }
            }
        }

        private bool isEmpty(int y, int x) // control pbx[y,x]'s background image is null ? 
        {
            return pbx[y, x].BackgroundImage == null;
        }

        private void changeColor(Color clr, int y, int x) // change color for just one 
        {
            pbx[y, x].BackColor = clr;
        }

        internal void changeColor_All()  // for all : set color black-white 
        {
            for (int y = 0; y < dama; y++)
            {
                for (int x = 0; x < dama; x++)
                {
                    if ((y % 2 == 0 && x % 2 == 0) || (y % 2 == 1 && x % 2 == 1))
                    {
                        this.pbx[y, x].BackColor = Color.Black;
                    }
                    else if ((x % 2 == 1 && y % 2 == 0) || (x % 2 == 0 && y % 2 == 1))
                    {
                        this.pbx[y, x].BackColor = Color.WhiteSmoke;
                    }

                }
            }
        }

        private void ClickSelectnewP(object sender, EventArgs e) // for change picking stone's location
        {
            newSelect = sender as PictureBox;
            if (newSelect.BackgroundImage != null && picked)
            {
                SetDistance(pbxName_toPbx(selectedPbxName), false);
                pbxName_toPbx(selectedPbxName).BackgroundImage = null;
                topla.Remove(selectedPbxName);
                picked = false;
                changeColor_All();
                makeAccessible(false);
                makeAccessible_PickingStones(true);

                puan++;
                if (puan == puanForWin)
                {
                    MessageBox.Show("You Won!!");
                    forEnding.Close();
                }
            }
            else if (newSelect.BackgroundImage == null)
            {
                
                //move image to new selectedPicturebox and remove the previous
                SetDistance(pbxName_toPbx(selectedPbxName), false);
                newSelect.BackgroundImage = pbxName_toPbx(selectedPbxName).BackgroundImage;
                pbxName_toPbx(selectedPbxName).BackgroundImage = null;
                changeColor_All();
                makeAccessible(false);

                // add the new selected picturebox as picking stone
                topla.AddLast(newSelect.Name);
                SetDistance(newSelect, true);
                makeAccessible_PickingStones(true);
                
            }
            else
            {
                makeAccessible(false);
                newSelect.BackColor = Color.Yellow;
                Control(newSelect.Name);
                Directingto(pbxArrayIndex(newSelect.Name) / 10, pbxArrayIndex(newSelect.Name) % 10);
               
            }

        }

        private void SetClickFor_allPbx() // set click event 
        {
            for (int y = 0; y < dama; y++)
            {
                for (int x = 0; x < dama; x++)
                {
                    pbx[y, x].Click += new EventHandler(ClickSelectnewP);
                }
            }
        }

        private void Directingto(int controlY, int controlX) // when clicked a picking stone, we get this pbx' index 
                                                             // for show lines which way it can go
        {
            int mainY = pbxArrayIndex(whereMainStn) / 10;
            int mainX = pbxArrayIndex(whereMainStn) % 10;

            if (controlY != 0 && controlX != 0)
            {
                if (controlX > mainX && (isEmpty(controlY, controlX - 1) || CalculateDistance(pbx[controlY, controlX]) == 1))
                {
                    makeAccessible(true, controlY, controlX - 1);
                    changeColor(Color.Green, controlY, controlX - 1);
                }
                if (controlX < mainX && (isEmpty(controlY, controlX + 1) || CalculateDistance(pbx[controlY, controlX]) == 1))
                {
                    makeAccessible(true, controlY, controlX + 1);
                    changeColor(Color.Green, controlY, controlX + 1);
                }
                if (controlY < mainY && (isEmpty(controlY + 1, controlX) || CalculateDistance(pbx[controlY, controlX]) == 1))
                {
                    makeAccessible(true, controlY + 1, controlX);
                    changeColor(Color.Green, controlY + 1, controlX);
                }
                if (controlY > mainY && (isEmpty(controlY - 1, controlX) || CalculateDistance(pbx[controlY, controlX]) == 1))
                {
                    makeAccessible(true, controlY - 1, controlX);
                    changeColor(Color.Green, controlY - 1, controlX);
                }
            }
            else if (controlY == 0 && controlX != 0)
            {
                if (controlX > mainX && isEmpty(controlY, controlX - 1))
                {
                    makeAccessible(true, controlY, controlX - 1);
                    changeColor(Color.Green, controlY, controlX - 1);
                }
                if (controlX < mainX && isEmpty(controlY, controlX + 1))
                {
                    makeAccessible(true, controlY, controlX + 1);
                    changeColor(Color.Green, controlY, controlX + 1);
                }
                if (controlY < mainY && isEmpty(controlY + 1, controlX))
                {
                    makeAccessible(true, controlY + 1, controlX);
                    changeColor(Color.Green, controlY + 1, controlX);
                }
            }
            else if (controlY != 0 && controlX == 0)
            {
                if (controlX < mainX && isEmpty(controlY, controlX + 1))
                {
                    makeAccessible(true, controlY, controlX + 1);
                    changeColor(Color.Green, controlY, controlX + 1);
                }
                if (controlY < mainY && isEmpty(controlY + 1, controlX))
                {
                    makeAccessible(true, controlY + 1, controlX);
                    changeColor(Color.Green, controlY + 1, controlX);
                }
                if (controlY > mainY && isEmpty(controlY - 1, controlX))
                {
                    makeAccessible(true, controlY - 1, controlX);
                    changeColor(Color.Green, controlY - 1, controlX);
                }
            }
            else
            {
                if (controlX < mainX && isEmpty(controlY, controlX + 1))
                {
                    makeAccessible(true, controlY, controlX + 1);
                    changeColor(Color.Green, controlY, controlX + 1);
                }
                if (controlY < mainY && isEmpty(controlY + 1, controlX))
                {
                    makeAccessible(true, controlY + 1, controlX);
                    changeColor(Color.Green, controlY + 1, controlX);
                }
            }
            if (CalculateDistance(pbx[controlY, controlX]) == 1)
            {

            }
        }

        private void SetDistance() // set distance for all picking stones in start
        {
            foreach (string pbName in topla)
            {
                pbxName_toPbx(pbName).Controls.Add(CreateDistanceLabel(pbxName_toPbx(pbName)));
            }
        }

        private void SetDistance(PictureBox pbForDist, bool set) // set distance for just one 
        {
            if (set)
            {
                pbForDist.Controls.Add(CreateDistanceLabel(pbForDist));
            }
            else
                pbForDist.Controls.Remove(lbl_Distance);

        }

        private Label CreateDistanceLabel(PictureBox pbx) // create distance's label 
        {
            lbl_Distance = new Label();
            lbl_Distance.Parent = pbx;
            lbl_Distance.Text = CalculateDistance(pbx).ToString();
            lbl_Distance.BackColor = Color.Transparent;
            lbl_Distance.Enabled = false;
            lbl_Distance.ForeColor = Color.FromKnownColor(KnownColor.Red);
            lbl_Distance.Font = new Font("Arial", 20, FontStyle.Bold);
            lbl_Distance.Location = new Point(25, 25);

            return lbl_Distance;
        }

        private int CalculateDistance(PictureBox stone)
        {
            int y = pbxArrayIndex(stone.Name) / 10;
            int x = pbxArrayIndex(stone.Name) % 10;
            int mainY = pbxArrayIndex(whereMainStn) / 10;
            int mainX = pbxArrayIndex(whereMainStn) % 10;



            return Math.Abs(mainY - y) + Math.Abs(mainX - x);
        }






    }
}
