using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {

        //Instances of SOLID principals:
        //Single Responsibility:
        //I tried to apply this to the whole program and can't really point to one specific spot more than another.
        //Open/Closed:
        //The methods in the Game class were written to be agnostic to the number of players in the game, so when the 
        //game was expanded to allow for multiple players the only functions that really required modification were the
        //MainGame and RunGame functions that call the smaller functions.
        static void Main(string[] args)
        {
            Game game = new Game();
            game.RunGame();
            Console.Clear();
            Console.ReadLine();
        }
    }
}
