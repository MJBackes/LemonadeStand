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
            Console.WriteLine("Enter your name:");
            return Console.ReadLine();
        }
        public override bool SetUpForTheDay(Store store)
        {
            string input;
            Console.WriteLine("1.Purchase Ingredients.");
            Console.WriteLine("2.Change Recipe.");
            Console.WriteLine("3.Finish today's setup.");
            Console.WriteLine("Enter 1 to go to the store, 2 to change your recipe, or 3 to finish setting up for the day.");
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
