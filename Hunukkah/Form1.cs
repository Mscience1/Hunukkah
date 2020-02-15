using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

/*
 The number of lit candles changes according to the date (The code only works if used in hanukkah

*/
namespace Hunukkah
{
    public partial class Form1 : Form
    {
        SoundPlayer s = new SoundPlayer(Hunukkah.Properties.Resources.מחזמר_שירי_חנוכה);
        public Form1()
        {
            InitializeComponent();
        }

        public Label[] labelz = new Label[9];        

        private void Form1_Load(object sender, EventArgs e)
        {
            s.Play();
            label5.Visible = true; //Shamash 
            bool b = true;
            bool b2 = false;
            //set labels, we did not use a loop because we could not be bothered to use label hash or id, loopy was used to avoid aliasing             
            /*
            labelz[0] = loopy(label1);
            labelz[1] = loopy(label2);
            labelz[2] = loopy(label3);
            labelz[3] = loopy(label4);
            labelz[4] = loopy(label5);
            labelz[5] = loopy(label6);
            labelz[6] = loopy(label7);
            labelz[7] = loopy(label8);
            labelz[8] = loopy(label9);
            */
            labelz[0] = (label1);
            labelz[1] = (label2);
            labelz[2] = (label3);
            labelz[3] = (label4);
            labelz[4] = (label5);
            labelz[5] = (label6);
            labelz[6] = (label7);
            labelz[7] = (label8);
            labelz[8] = (label9);
            ////Debug smallBoi(label1, true, 430, 35, 0); //row +10, column +12     
            ////Debug to check for aliasing smallBoi(label1, false, 430, 35, 0); //row +10, column +12
            lightCand(date.MaxDate, labelz, ifHanukkah(date.MinDate, date.MaxDate));


        }

        //input array of labels and get array of label locations
        private Point[] initLoc(Label[] l)
        {

            Point[] p = new Point[l.Length];

            for (int i = 0; i < l.Length; i++)
            {
                p[i] = l[i].Location;
            }

            return p;
        } 

        //Change label size
        private void smallBoi(Label label, bool small, int row, int column, int s)
        {         

            if (small == true)
            {
                label.Font = new Font("Serif", 24, FontStyle.Bold);
                label.Location = new Point(row, column);
            }

            else
            {
               label.Font = new Font("Serif", 36, FontStyle.Bold);
               label.Location = initLoc(labelz)[s];
            }

        }

        //label copy constructor thanks a lot microsoft for not making one!!!!, caused us great trouble with aliasing: Give me my money now!!!!!!!!!!!!!! 
        private Label loopy(Label ja)
        {
            Label lool = new Label();
            lool.BorderStyle = ja.BorderStyle;
            lool.ImageList = ja.ImageList;
            lool.ImageIndex = ja.ImageIndex;
            lool.ImageAlign = ja.ImageAlign;
            lool.Location = ja.Location;
            lool.UseMnemonic = ja.UseMnemonic;
            lool.Text = ja.Text;
            lool.Size = ja.Size;

            return lool;
        }

        ///Method to Set rules for Hanukkah week using real dates in 2019
        private bool ifHanukkah(DateTime start, DateTime stop)
        {
            if(start < DateTime.Today && DateTime.Today < stop)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //Method to check how many candles should be lit
        private int lightNum(DateTime stop,bool hannu)
        {
            int num = 0;

            if (hannu)
            {
                num = 9-(stop.Day - DateTime.Today.Day); //Difference between the day today and final day of hanukkah
            }

            return num;
        }        
        
        //Method to "Light" the candles (Make them visible)
        private void lightCand(DateTime stop, Label[] lab, bool hannu)
        {
            for (int j = 0; j < lightNum(stop, hannu); j++)
            {
                lab[j].Visible = true;
            }
        }        

        private void Timer1_Tick(object sender, EventArgs e)
        {         
            foreach (Label l in labelz)
            {
                if (l.Visible)
                {
                    l.Visible = false;
                    l.Visible = true;
                }                
            }           
        }     

        // change the date of Hanukkah
        private void Button1_Click(object sender, EventArgs e)
        {
            labelz[0].Visible = true; labelz[1].Visible = false; labelz[2].Visible = false; labelz[3].Visible = false;
            labelz[5].Visible = false;  labelz[6].Visible = false; labelz[7].Visible = false; labelz[8].Visible = false;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            labelz[0].Visible = true; labelz[1].Visible = true; labelz[2].Visible = false; labelz[3].Visible = false;
            labelz[5].Visible = false; labelz[6].Visible = false; labelz[7].Visible = false; labelz[8].Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            labelz[0].Visible = true; labelz[1].Visible = true; labelz[2].Visible = true; labelz[3].Visible = false;
            labelz[5].Visible = false; labelz[6].Visible = false; labelz[7].Visible = false; labelz[8].Visible = false;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            labelz[0].Visible = true; labelz[1].Visible = true; labelz[2].Visible = true; labelz[3].Visible = true;
            labelz[5].Visible = false; labelz[6].Visible = false; labelz[7].Visible = false; labelz[8].Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            labelz[0].Visible = true; labelz[1].Visible = true; labelz[2].Visible = true; labelz[3].Visible = true;
            labelz[5].Visible = true; labelz[6].Visible = false; labelz[7].Visible = false; labelz[8].Visible = false;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            labelz[0].Visible = true; labelz[1].Visible = true; labelz[2].Visible = true; labelz[3].Visible = true;
            labelz[5].Visible = true; labelz[6].Visible = true; labelz[7].Visible = false; labelz[8].Visible = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            labelz[0].Visible = true; labelz[1].Visible = true; labelz[2].Visible = true; labelz[3].Visible = true;
            labelz[5].Visible = true; labelz[6].Visible = true; labelz[7].Visible = true; labelz[8].Visible = false;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            labelz[0].Visible = true; labelz[1].Visible = true; labelz[2].Visible = true; labelz[3].Visible = true;
            labelz[5].Visible = true; labelz[6].Visible = true; labelz[7].Visible = true; labelz[8].Visible = true;
        }
        
        // restart the app
        private void Button9_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
