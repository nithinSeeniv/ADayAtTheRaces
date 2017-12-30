using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyhoundRaces //This program is a part of Head First C# Exercise #1
{
    public partial class Form1 : Form
    {

        Greyhound[] GreyhoundArray = new Greyhound[4];
        Random MyRandomizer = new Random();
        Guy[] MyGuy = new Guy[3];

        public Form1()
        {
            InitializeComponent();
            GreyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = dogPictureBox2,
                RaceTrackLength = raceTrackPictureBox1.Width - dogPictureBox2.Width,
                Location = 0,
                StartingPosition = dogPictureBox2.Left,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = dogPictureBox3,
                RaceTrackLength = raceTrackPictureBox1.Width - dogPictureBox3.Width,
                Location = 0,
                StartingPosition = dogPictureBox3.Left,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = dogPictureBox4,
                RaceTrackLength = raceTrackPictureBox1.Width - dogPictureBox4.Width,
                Location = 0,
                StartingPosition = dogPictureBox4.Left,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = dogPictureBox5,
                RaceTrackLength = raceTrackPictureBox1.Width - dogPictureBox5.Width,
                Location = 0,
                StartingPosition = dogPictureBox5.Left,
                Randomizer = MyRandomizer
            };

            //Initialize the MyGuy references by defining the instance and running ClearBet. 
            MyGuy[0] = new Guy() { Cash = 50, MyLabel = label1, MyRadioButton = radioButton1, Name = "Joe", MyBet = null };
            MyGuy[0].ClearBet();
            label1.Text = "Not placed a bet yet";
            MyGuy[1] = new Guy() { Cash = 50, MyLabel = label2, MyRadioButton = radioButton2, Name="Bob" , MyBet=null};
            MyGuy[1].ClearBet();
            label2.Text = "Not placed a bet yet";
            MyGuy[2] = new Guy() { Cash = 50, MyLabel = label3, MyRadioButton = radioButton3, Name="Al", MyBet=null};
            MyGuy[2].ClearBet();
            label3.Text = "Not placed a bet yet";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Guyselected = 0; ;
            if (radioButton1.Checked == true)
                Guyselected = 0;
            if (radioButton2.Checked == true)
                Guyselected = 1;
            if (radioButton3.Checked == true)
                Guyselected = 2;
            //MyGuy[Guyselected].MyBet = new Bet() { Amount = (int)numericUpDown1.Value, Bettor = MyGuy[Guyselected], Dog = (int)numericUpDown2.Value-1 };
            MyGuy[Guyselected].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value-1);
            //bool Check = MyGuy[Guyselected].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value - 1);
            MyGuy[Guyselected].UpdateLabels();

            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (GreyhoundArray[i].Run())
                {
                    timer1.Stop();
                    MessageBox.Show("The winner of the race is dog #" + (i+1));
                    for (int j = 0; j < 3; j++)
                    {
                        MyGuy[j].Collect(i);
                        MyGuy[j].UpdateLabels();
                    }
                    for (int k = 0; k < 4; k++)
                    {
                        GreyhoundArray[k].TakeStartingPosition();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }
    }


}
