using System;
namespace RaceGame
{
    public class Bets
    {
        public int Amount { get; set; } //;
        public int animal { get; set; } //;
        public Punter Bettor { get; set; }//;

        public Bets(int Amount, int animal, Punter Bettor)
        {
            this.Amount = Amount;
            this.animal = animal;
            this.Bettor = Bettor;
        }

        public string GetDescription()
        {
            string description = "";

            if (Amount > 0)
            {
                if (Amount >= 1)
                {
                    description = String.Format("{0} bets {1} on Animal : {2}",
                    Bettor.GuyName, Amount, animal);
                }

                if (Amount < 0)
                {
                    description = String.Format("{0} , you require $1 amount to place a bet",
                            Bettor.GuyName);
                }
            }
            if (Amount == 0)
            {

                description = String.Format("{0} has busted",
                    Bettor.GuyName);  //hasn't placed any bets
            }
            return description;
        }

        public int PayOut(int Winner)
        {
            if (animal == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}
