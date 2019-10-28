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
            //Player player = new HumanPlayer();
            //Store store = new Store();
            //player.ChangeRecipe();
            //player.recipe.PrintRecipe();
            Game game = new Game();
            game.RunGame();
            Console.ReadLine();
        }
    }
}
