﻿using System;
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
            Game game = new Game();
            game.RunGame();
            Console.Clear();
            foreach (Customer customer in game.PotentialCustomers)
            {
                foreach (int loyalty in customer.LoyaltyList)
                {
                    Console.WriteLine(loyalty);
                }
            }
            Console.ReadLine();
        }
    }
}
