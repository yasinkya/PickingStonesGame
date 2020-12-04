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
        private PictureBox[,] pbx;
        PictureBox newSelect;
        private LinkedList<string> topla, duvar;
        private string whereMainStn;
        private string changePbxName;
        int dama;

        public StartGame(PictureBox[,] pbx, LinkedList<string> topla, LinkedList<string> duvar, string whereMainStn, int dama)
        {
            this.dama = dama;
            this.pbx = pbx;
            this.topla = topla;
            this.duvar = duvar;
            this.whereMainStn = whereMainStn;
            this.makeAccessible(true);
        }

        public void Control(string pbxName)
        {
            int pbxId = stringToInt_pbxName(pbxName);
            int controlY = pbxId / 10;
            int controlX = pbxId % 10;
            topla.Remove(pbx[controlY, controlX].Name);
            changePbxName = pbx[controlY, controlX].Name;
        }

        private int stringToInt_pbxName(string name)
        {
            int Y = Convert.ToInt32(name.Substring(2, 1));
            int X = Convert.ToInt32(name.Substring(3));
            return Y * 10 + X;
        }

        private void makeAccessible(bool make)
        {
            foreach (string pbxname in topla)
            {
                int pbxId = stringToInt_pbxName(pbxname);
                pbx[pbxId / 10, pbxId % 10].Enabled = make;
                pbx[pbxId / 10, pbxId % 10].Click += new EventHandler(ClickSelectnewP);
            }
        }

        private void makeAccessible(bool make, int y, int x)
        {
            pbx[y, x].Enabled = make;
            pbx[y, x].Click += new EventHandler(ClickSelectnewP);
        }

        private bool isEmpty(int y, int x)
        {
            return pbx[y, x].BackgroundImage == null;
        }

        private void changeColor(Color clr, int y, int x)
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

        private void ClickSelectnewP(object sender, EventArgs e)
        {
            newSelect = sender as PictureBox;
            if (newSelect.BackgroundImage == null)
            {
                newSelect.BackgroundImage = pbx[stringToInt_pbxName(changePbxName) / 10, stringToInt_pbxName(changePbxName) % 10].BackgroundImage;
                pbx[stringToInt_pbxName(changePbxName) / 10, stringToInt_pbxName(changePbxName) % 10].BackgroundImage = null;
                changeColor_All();
            }
            else
            {
                newSelect.BackColor = Color.Yellow;
                Control(newSelect.Name);
                Directingto(stringToInt_pbxName(newSelect.Name) / 10, stringToInt_pbxName(newSelect.Name) % 10);
            }

        }

        private void Directingto(int controlY, int controlX)
        {
            if (controlY != 0 && controlX != 0)
            {
                if (controlX > 0 && isEmpty(controlY, controlX - 1))
                {
                    makeAccessible(true, controlY, controlX - 1);
                    changeColor(Color.Green, controlY, controlX - 1);
                }
                if (controlX < dama - 1 && isEmpty(controlY, controlX + 1))
                {
                    makeAccessible(true, controlY, controlX + 1);
                    changeColor(Color.Green, controlY, controlX + 1);
                }
                if (controlY < dama - 1 && isEmpty(controlY + 1, controlX))
                {
                    makeAccessible(true, controlY + 1, controlX);
                    changeColor(Color.Green, controlY + 1, controlX);
                }
                if (controlY > 0 && isEmpty(controlY - 1, controlX))
                {
                    makeAccessible(true, controlY - 1, controlX);
                    changeColor(Color.Green, controlY - 1, controlX);
                }
            }
            else if (controlY == 0 && controlX != 0)
            {
                if (controlX > 0 && isEmpty(controlY, controlX - 1))
                {
                    makeAccessible(true, controlY, controlX - 1);
                    changeColor(Color.Green, controlY, controlX - 1);
                }
                if (controlX < dama - 1 && isEmpty(controlY, controlX + 1))
                {
                    makeAccessible(true, controlY, controlX + 1);
                    changeColor(Color.Green, controlY, controlX + 1);
                }
                if (controlY < dama - 1 && isEmpty(controlY + 1, controlX))
                {
                    makeAccessible(true, controlY + 1, controlX);
                    changeColor(Color.Green, controlY + 1, controlX);
                }
            }
            else if (controlY != 0 && controlX == 0)
            {
                if (controlX < dama - 1 && isEmpty(controlY, controlX + 1))
                {
                    makeAccessible(true, controlY, controlX + 1);
                    changeColor(Color.Green, controlY, controlX + 1);
                }
                if (controlY < dama - 1 && isEmpty(controlY + 1, controlX))
                {
                    makeAccessible(true, controlY + 1, controlX);
                    changeColor(Color.Green, controlY + 1, controlX);
                }
                if (controlY > 0 && isEmpty(controlY - 1, controlX))
                {
                    makeAccessible(true, controlY - 1, controlX);
                    changeColor(Color.Green, controlY - 1, controlX);
                }
            }
            else
            {
                if (controlX < dama - 1 && isEmpty(controlY, controlX + 1))
                {
                    makeAccessible(true, controlY, controlX + 1);
                    changeColor(Color.Green, controlY, controlX + 1);
                }
                if (controlY < dama - 1 && isEmpty(controlY + 1, controlX))
                {
                    makeAccessible(true, controlY + 1, controlX);
                    changeColor(Color.Green, controlY + 1, controlX);
                }
            }
        }

        //Label lblPB = new Label();
        //lblPB.Parent = pb[i, j];
        //lblPB.Text = "deneme";
        //lblPB.BackColor = Color.Transparent;
        //lblPB.Enabled = false;
        //lblPB.ForeColor = Color.Red;
        //lblPB.Location = new Point(17, 30);
        //pb[i, j].Controls.Add(lblPB);




        //    string tasix = Interaction.InputBox("nereye", "tasi");
        //    string tasiy = Interaction.InputBox("nereye", "tasi");
        //    int anaX = Convert.ToInt32(this.whereMainStn.Substring(2, 1));
        //    int anaY = Convert.ToInt32(this.whereMainStn.Substring(3));

        //    this.pbx[Convert.ToInt32(tasiy), Convert.ToInt32(tasix)].BackgroundImage = this.pbx[ anaY, anaX].BackgroundImage;
        //    this.pbx[0, 9].BackgroundImage = null;



    }
}
