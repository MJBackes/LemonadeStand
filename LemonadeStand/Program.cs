using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new HumanPlayer();
            Store store = new Store();
            store.GoToStore(player);
            Console.WriteLine(player.wallet.Money);
            Console.WriteLine(player.inventory.CupStock + "Cups");
            Console.WriteLine(player.inventory.LemonStock + "Lemons");
            Console.WriteLine(player.inventory.SugarStock + "Cups Sugar");
            Console.WriteLine(player.inventory.IceStock + "Ice Cubes");
            Console.ReadLine();
        }
    }
}
