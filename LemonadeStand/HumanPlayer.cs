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
        
    }
}
