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
        private int iceCubesMeltedToday;
        private int lemonsSpoiledToday;
        public int IceCubesMeltedToday
        {
            get => iceCubesMeltedToday;
        }
        public int LemonsSpoiledToday
        {
            get => lemonsSpoiledToday;
        }
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
            iceCubesMeltedToday = IceStock;
            IceStock = 0;
        }
        public void SpoilLemons(Random rng)
        {
            double coinFlip = rng.NextDouble();
            if(coinFlip > .75)
            {
                int lemonsSpoiled = rng.Next(1, LemonStock);
                lemonsSpoiledToday = lemonsSpoiled;
                LemonStock -= lemonsSpoiled;
            }
        }
        public void ResetDailyVariables()
        {
            lemonsSpoiledToday = 0;
            iceCubesMeltedToday = 0;
        }
    }
}
