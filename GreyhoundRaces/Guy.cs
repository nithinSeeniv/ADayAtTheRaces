using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyhoundRaces
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;

        

        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " has " + Cash + "€";
            // MyLabel.Text = Name + "'s bet has a value of " + MyBet.Amount + " on Dog#" + MyBet.Dog;
            MyLabel.Text = MyBet.GetDescription();
        }

        public void ClearBet()
        {
            //MyBet.Amount = 0;
            PlaceBet(0, 0);

        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {


            //MyBet.Amount = BetAmount;

            if (BetAmount <= Cash)
            {

                MyBet = new Bet() { Amount = BetAmount, Bettor = this, Dog = DogToWin }; //CREATES A NEW OBJECT HERE!!!!
                UpdateLabels();
                return true;
            }
            else
            {
                MyLabel.Text = "Not enough cash available!";
                UpdateLabels();
                return false;

            }
            
        }

        public void Collect(int Winner)
        {
            //MyBet.PayOut(Winner);
            Cash += MyBet.PayOut(Winner);
            //ClearBet();
            UpdateLabels();
        }
    }
}
