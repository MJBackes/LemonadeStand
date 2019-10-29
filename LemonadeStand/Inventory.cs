using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        //MembVars
        public int LemonStock;
        public int SugarStock;
        public int IceStock;
        public int CupStock;
        //Contr
        public Inventory()
        {
            LemonStock = 0;
            SugarStock = 0;
            IceStock = 0;
            CupStock = 0;
        }
        //MembMeth
        public void PrintInventory()
        {
            Console.WriteLine($"Lemons: {LemonStock}");
            Console.WriteLine($"Cups of Sugar: {SugarStock}");
            Console.WriteLine($"Ice Cubes: {IceStock}");
            Console.WriteLine($"Cups: {CupStock}");
        }
        public void MeltIceAtEndOfDay()
        {
            IceStock = 0;
        }
        public void SpoilLemons(Random rng)
        {
            double coinFlip = rng.Next(0, 1);
            if(coinFlip > .5)
            {
                int lemonsSpoiled = rng.Next(1, 9);
                LemonStock -= lemonsSpoiled;
            }
        }
    }
}
