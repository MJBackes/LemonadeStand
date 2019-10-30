using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class HumanPlayer : Player
    {
        //MembVars

        //Contr
        public HumanPlayer()
        {
            Name = SetName();
            wallet = new Wallet();
            inventory = new Inventory();
            pitcher = new Pitcher();
            recipe = new Recipe();
        }
        //MembMeth
        private string SetName()
        {
            UserInterface.PrintGetNameText();
            return Console.ReadLine();
        }
        public override bool SetUpForTheDay(Store store,Weather todaysForecast)
        {
            string input;
            UserInterface.PrintSetUpForTheDayText();
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    store.SellToHumanPlayer(this);
                    break;
                case "2":
                    ChangeRecipe();
                    break;
                case "3":
                    return true;
                default:
                    break;
            }
            return false;
        }
    }
}
