using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RaceGame
{
    public class Punter
    {
        public int PunterID { get; set; }
        public string GuyName { get; set; }
        public Bets MyBets { get; set; }
        public int Money { get; set; }
       


        public RadioButton MyRadioButton { get; set; }
        public System.Windows.Forms.Label myLabel { get; set; }
        
        
        
       


        public void UpdateLabels()
        {
           

            if (MyBets == null)
            {
               myLabel.Text= String.Format( "{0} hasn't placed any bets", GuyName);
            }
            else
            {
                myLabel.Text = MyBets.GetDescription();
            }
            MyRadioButton.Text = GuyName + " has " + Money + " bucks";
        }
       
        public void ClearBet()
        {
            MyBets.Amount = 0;
        }

        public bool PlaceBet(int Amount, int animal)
        {

            if (Amount <= Money )
            {
                MyBets = new Bets(Amount, animal, this);
               
                return true;
            }
            
            return false;
        }

        //************ Winning or lossing money ************
        public void Collect(int Winner)
        {
            Money += MyBets.PayOut(Winner);
            
        }
    }

}

