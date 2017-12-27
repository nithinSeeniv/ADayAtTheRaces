using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyhoundRaces
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            if (Amount > 0)
            {
                int Dog1 = Dog + 1;
                string DescriptionIfSuccessful = Bettor.Name + " has placed a bet of " + Amount + "€ on Dog #" + Dog1;
                return DescriptionIfSuccessful;
            }
            else
            {
                string DescriptionIfZero = "Cannot place a zero bet!";
                return DescriptionIfZero;
            }

        }

        public int PayOut(int Dogwinner)
        {
            if (Dogwinner == Dog)
                return Amount;
            else
                return -Amount;
        }
    }
}
