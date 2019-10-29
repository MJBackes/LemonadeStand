﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        //MembVars
        public Player player;
        public int NumberOfWeeks;
        public List<Week> weeks;
        Store store;
        private int dayIndex;
        private int weekIndex;
        private Day currentDay;
        private Random rng; //Putting this here doesn't make the most sense from an OOP perspective, but instanciating the Randoms
                           //in the appropriate classes led to them having the same seed and therefore the same output, so I moved
                          // it here in order to pass around the reference to a single Random object.
        //Contr
        public Game()
        {
            rng = new Random();
            store = new Store();
        }
        //MembMeth
        private int getNumberOfWeeks()
        {
            Console.Clear();
            Console.WriteLine("How many weeks do you want to play(1-5)?");
            int input;
            bool isValidInput;
            do
            {
                isValidInput = int.TryParse(Console.ReadLine(), out input);
            } while (!isValidInput);
            return input;
        }
        private void instanciateWeeks()
        {
            NumberOfWeeks = getNumberOfWeeks();
            weeks = new List<Week>();
            for(int i = 0; i < NumberOfWeeks; i++)
            {
                weeks.Add(new Week(i + 1,rng));
            }
            dayIndex = 0;
            weekIndex = 0;
        }
        private void displayRules()
        {
            Console.Clear();
            Console.WriteLine("SETUP");
            Console.WriteLine(" -Enter your name and choose the number of weeks you would like to play(from 1 to 5).");
            Console.WriteLine("MAIN GAME");
            Console.WriteLine(" -Each day, you will be able to purchase ingredients and change your lemonade recipe and its cost.");
            Console.WriteLine(" -There will be a number of people each day who walk past your stand,\n" +
                "   their likelyhood to purchase your lemonade is based on several factors, including - but not limited to- :\n" +
                "       Temperature\n" +
                "       Weather conditions\n" +
                "       How much sugar/lemon/ice is in the lemonade");
            Console.WriteLine(" -Adjust your recipe and price in accordance with the weather in order to make more money than you\n" +
                "spend on ingredients.");

        }
        public void RunGame()
        {
            displayRules();
            setUp();
            mainGame();
            endOfGameText(player);
        }
        private void setUp()
        {
            player = new HumanPlayer();
            instanciateWeeks();
        }
        private void purchaseIngredients(Player player)
        {
            store.SellToPlayer(player);
        }
        private void setRecipe(Player player)
        {
            player.ChangeRecipe();
        }
        private void printTodaysForecast()
        {
            double coinFlip = rng.NextDouble();
            if(coinFlip > .25)
            {
                printAccurateForecast();
            }
            else
            {
                printInaccurateForecast();
            }
        }
        private void printAccurateForecast()
        {
            Console.WriteLine($"Temperature: {currentDay.weather.Temperature}");
            Console.WriteLine($"Conditions: {currentDay.weather.Conditions}");
        }
        private void printInaccurateForecast()
        {
            Weather forecast = new Weather(rng);
            Console.WriteLine($"Temperature: {forecast.Temperature}");
            Console.WriteLine($"Conditions: {forecast.Conditions}");
        }
        private void printTodaysDate()
        {
            Console.WriteLine("Week: " + (weekIndex + 1) + " - Day: " + (dayIndex + 1));
        }
        private void startOfDay(Player player)
        {
            currentDay = weeks[weekIndex].DaysOfTheWeek[dayIndex];
            bool isDoneSettingUp = false;
            string input;
            do
            {
                Console.Clear();
                printTodaysDate();
                printTodaysForecast();
                Console.WriteLine("1.Purchase Ingredients.");
                Console.WriteLine("2.Change Recipe.");
                Console.WriteLine("3.Finish today's setup.");
                Console.WriteLine("Enter 1 to go to the store, 2 to change your recipe, or 3 to finish setting up for the day.");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        purchaseIngredients(player);
                        break;
                    case "2":
                        setRecipe(player);
                        break;
                    case "3":
                        isDoneSettingUp = true;
                        break;
                    default:
                        break;
                }
            } while (!isDoneSettingUp);
        }
        private void openForBusiness(Player player)
        {
            
            foreach(Customer customer in currentDay.Customers)
            {
                if (customer.WillIPurchase(player.recipe))
                {
                    player.CustomerSale();
                }
            }
        }
        private void displayTodaysInfo(Player player)
        {
            Console.Clear();
            Console.Write("Today's actual weather:");
            printAccurateForecast();
            Console.WriteLine($"Number of cups sold today: {player.CupsSoldToday}");
            Console.WriteLine($"Today's profit: {player.DailyProfit}");
            Console.WriteLine($"Total profit so far: {player.TotalProfit}");
            player.PrintResources();
            Console.ReadLine();
        }
        private void changeToNextDay()
        {
            dayIndex++;
            if(dayIndex == 7)
            {
                dayIndex = 0;
                weekIndex++;
            }
        }
        private void updatePlayerStats(Player player)
        {
            player.UpdateDailyProfit();
            player.UpdateTotalProfit();
            player.UpdateTotalCupsSold();
        }
        private void endOfDayCleanUp(Player player)
        {
            player.inventory.MeltIceAtEndOfDay();
            player.inventory.SpoilLemons(rng);
            printResourcesLostAtEndOfDay(player);
            player.inventory.ResetDailyVariables();
            player.pitcher.EmptyPitcherAtEndOfDay();
            player.ResetCupsSoldToday();
        }
        private void printResourcesLostAtEndOfDay(Player player)
        {
            Console.WriteLine($"Number of Ice Cubes that melted at the end of the Day: {player.inventory.IceCubesMeltedToday}");
            Console.WriteLine($"Number of Lemons that spoiled today: {player.inventory.LemonsSpoiledToday}");
            Console.ReadLine();
        }
        private void mainGame()
        {
            while (weekIndex < NumberOfWeeks)
            {
                startOfDay(player);
                openForBusiness(player);
                updatePlayerStats(player);
                displayTodaysInfo(player);
                changeToNextDay();
                endOfDayCleanUp(player);
            }

        }
        private void endOfGameText(Player player)
        {
            Console.Clear();
            Console.WriteLine($"{player.Name}'s Final Statistics:");
            Console.WriteLine($"Total Profit: {player.TotalProfit}");
            Console.WriteLine($"Total Cups Sold: {player.TotalCupsSold}");
        }
    }
}
