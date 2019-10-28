using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    abstract class Player
    {

        //MembVars
        public string Name;
        public Inventory inventory;
        public Wallet wallet;
        public Pitcher pitcher;
        public Recipe recipe;
        //Contr

        //MembMeth
        public void PrintResources()
        {
            Console.WriteLine($"Lemons: {inventory.LemonStock}");
            Console.WriteLine($"Cups of Sugar: {inventory.SugarStock}");
            Console.WriteLine($"Ice Cubes: {inventory.IceStock}");
            Console.WriteLine($"Cups: {inventory.CupStock}");
            Console.WriteLine($"Wallet: {wallet.Money}");
        }
    }
}
