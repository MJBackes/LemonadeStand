using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    static class UserInterface
    {
        //MembVars

        //Const

        //MembMeth
        /// ///Private Methods
        private static void PrintTodaysForecast(Weather todaysForecast)
        {
            WriteFullLine("Today's Forecast:");
            WriteFullLine($"    Temperature: {todaysForecast.Temperature}");
            WriteFullLine($"    Conditions: {todaysForecast.Conditions}");
            WriteFullLine($"    Confidence: {todaysForecast.ProbablilityOfAccurateForecast}%");
        }
        private static void PrintTodaysDate(int weekIndex, int dayIndex)
        {
            WriteFullLine("Week: " + (weekIndex + 1) + " - Day: " + (dayIndex + 1));
        }
        private static void PrintAccurateForecast(Weather weather)
        {
            WriteFullLine("Today's actual weather:");
            WriteFullLine($"Temperature: {weather.Temperature}");
            WriteFullLine($"Conditions: {weather.Conditions}");
        }
        private static void PrintPlayersEndOfDayInfo(Player player,Day day)
        {
            WriteFullLine($"Number of sales today: {player.CupsSoldToday}");
            WriteFullLine($"Out of {day.Customers.Count} possible sales.");
            if (player.wallet.DailyProfit >= 0)
            {
                WriteFullLine($"Today's profit: {player.wallet.DailyProfit}");
            }
            else
            {
                WriteFullLine($"Today's Loss: {player.wallet.DailyProfit}");
            }
            if (player.wallet.TotalProfit >= 0)
            {
                WriteFullLine($"Total profit so far: {player.wallet.TotalProfit}");
            }
            else
            {
                WriteFullLine($"Total Loss so far: {player.wallet.TotalProfit}");
            }
        }
        private static void PrintInventory(Inventory inv)
        {
            WriteFullLine($"Lemons: {inv.LemonStock}");
            WriteFullLine($"Cups of Sugar: {inv.SugarStock}");
            WriteFullLine($"Ice Cubes: {inv.IceStock}");
            WriteFullLine($"Cups: {inv.CupStock}");
        }
        private static void PrintWallet(Wallet wallet)
        {
            WriteFullLine($"Wallet: {wallet.Money}");
        }
        private static void PrintPlayerResources(Player player)
        {
            PrintInventory(player.inventory);
            PrintWallet(player.wallet);
        }
        private static void WriteFullLine(string input)
        {
            int maxLength = Console.WindowWidth - 1;
            string output = input.PadRight(maxLength);
            Console.WriteLine(output);
        }
        private static void FillGrassBlock(int rowsOfText)
        {
            for(int i = rowsOfText; i < 13; i++)
            {
                WriteFullLine(" ");
            }
        }
        private static void PrintRecipeContents(Recipe recipe)
        {
            WriteFullLine($"Lemons per Pitcher: {recipe.NumLemons}");
            WriteFullLine($"Cups of Sugar per Pitcher: {recipe.CupsSugar}");
            WriteFullLine($"Number of Ice Cubes per Cup: {recipe.NumIceCubes}");
            WriteFullLine($"Price per Cup: {recipe.PricePerCup}");
        }
        private static string ConvertDoubleToPercent(double dub)
        {
            dub *= 100;
            return Math.Round(dub) + "%";
        }
        //////////////Background Methods
        public static void PrintBackgroundFirstHalf()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < 9; i++)
            {
                WriteFullLine("      ");
            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void PrintBackgroundSecondHalf()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                if (i == 4)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                WriteFullLine("                                  ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// /////////Public Methods
        public static void PrintGetNameText()
        {
            PrintBackgroundFirstHalf();
            WriteFullLine("Enter your name:");
            FillGrassBlock(1);
            PrintBackgroundSecondHalf();
        }
        public static void PrintTodaysInfo(Player player,int weekIndex, int dayIndex, Weather todaysForecast)
        {
            PrintBackgroundFirstHalf();
            WriteFullLine(player.Name);
            PrintTodaysDate(weekIndex, dayIndex);
            PrintTodaysForecast(todaysForecast);
            FillGrassBlock(6);
            PrintBackgroundSecondHalf();
        }
        public static void PrintSetUpForTheDayText(Weather todaysForecast)
        {
            PrintBackgroundFirstHalf();
            PrintTodaysForecast(todaysForecast);
            WriteFullLine("1.Purchase Ingredients.");
            WriteFullLine("2.Change Recipe.");
            WriteFullLine("3.Go Bankrupt.");
            WriteFullLine("4.Finish today's setup.");
            WriteFullLine("Enter 1 to go to the store, 2 to change your recipe, or 3 to finish setting up for the day.");
            FillGrassBlock(9);
            PrintBackgroundSecondHalf();
        }
        public static void PrintDisplayTodaysInfoText(Player player,Day day)
        {
            PrintBackgroundFirstHalf();
            WriteFullLine(player.Name);
            PrintAccurateForecast(day.weather);
            PrintPlayersEndOfDayInfo(player,day);
            PrintPlayerResources(player);
            PrintBackgroundSecondHalf();
        }
        public static void PrintGetItemToSellText(Player player)
        {
            PrintBackgroundFirstHalf();
            //Console.Clear();
            PrintPlayerResources(player);
            WriteFullLine("1.Buy Lemons.");
            WriteFullLine("2.Buy Ice Cubes.");
            WriteFullLine("3.Buy Cups of Sugar.");
            WriteFullLine("4.Buy Cups");
            WriteFullLine("5.Return.");
            WriteFullLine("Enter the number coresponding to the purchase you would like to make or" +
                " 5 to return to the previous screen.");
            FillGrassBlock(11);
            PrintBackgroundSecondHalf();
        }
        public static void DisplayRules()
        {
            PrintBackgroundFirstHalf();
            // Console.Clear();
            WriteFullLine("SETUP");
            WriteFullLine(" -Enter your name and choose the number of weeks you would like to play(from 1 to 5).");
            WriteFullLine("MAIN GAME");
            WriteFullLine(" -Each day, you will be able to purchase ingredients and change your lemonade recipe and its cost.");
            WriteFullLine(" -There will be a number of people each day who walk past your stand,");
            WriteFullLine("   their likelyhood to purchase your lemonade is based on several factors, including - but not limited to- :");
            WriteFullLine("       Temperature");
            WriteFullLine("       Weather conditions");
            WriteFullLine("       How much sugar/lemon/ice is in the lemonade");
            WriteFullLine(" -Adjust your recipe and price in accordance with the weather in order to make more money than you");
            WriteFullLine("spend on ingredients.");
            FillGrassBlock(11);
            PrintBackgroundSecondHalf();
        }
        public static void PrintGetNumberOfWeeksText()
        {
            PrintBackgroundFirstHalf();
            WriteFullLine("How many weeks do you want to play(1-5)?");
            FillGrassBlock(1);
            PrintBackgroundSecondHalf();
        }
        public static void PrintInstanciatePlayerText()
        {
            PrintBackgroundFirstHalf();
            WriteFullLine("1.Add another Human player.");
            WriteFullLine("2.Add another AI player.");
            WriteFullLine("3.Finish adding players.");
            FillGrassBlock(3);
            PrintBackgroundSecondHalf();
        }
        public static void PrintPlayersResourcesLostAtEndOfDay(Player player)
        {
            PrintBackgroundFirstHalf();
            WriteFullLine($"Number of Ice Cubes that melted at the end of the Day: {player.inventory.IceCubesMeltedToday}");
            WriteFullLine($"Number of Lemons that spoiled today: {player.inventory.LemonsSpoiledToday}");
            FillGrassBlock(2);
            PrintBackgroundSecondHalf();
        }
        public static void PrintPlayersEndOfGameText(Player player)
        {
            PrintBackgroundFirstHalf();
            WriteFullLine($"{player.Name}'s Final Statistics:");
            if (player.wallet.TotalProfit >= 0)
            {
                WriteFullLine($"Total Profit: {player.wallet.TotalProfit}");
            }
            else
            {
                WriteFullLine($"Total Loss: {player.wallet.TotalProfit}");
            }
            WriteFullLine($"Total Cups Sold: {player.TotalCupsSold}");
            FillGrassBlock(3);
            PrintBackgroundSecondHalf();
        }
        public static void PrintGetPurchaseSizeText(Player player, string itemName, double itemPrice, int smallDiscountThreshold, int largeDiscountThreshold)
        {
            PrintBackgroundFirstHalf();
            PrintPlayerResources(player);
            WriteFullLine($"Price per {itemName}: {itemPrice}");
            WriteFullLine($"10% Discount on purchases of {smallDiscountThreshold} or more.");
            WriteFullLine($"15% Discount on purchases of {largeDiscountThreshold} or more.");
            WriteFullLine("Your Wallet: " + player.wallet.Money);
            WriteFullLine($"How many {itemName}(s) would you like to buy?");
            FillGrassBlock(11);
            PrintBackgroundSecondHalf();
        }
        public static void PrintIfPurchaseTooLarge(Player player)
        {
            PrintBackgroundFirstHalf();
            WriteFullLine($"Store to {player.Name}: Not enough money to purchase that many.");
            FillGrassBlock(1);
            Console.ReadLine();
            PrintBackgroundSecondHalf();
        }
        public static void PrintGetChangeRecipeInputText(Recipe recipe)
        {
            PrintBackgroundFirstHalf();
            PrintRecipeContents(recipe);
            WriteFullLine("1.Change Lemons per Pitcher.");
            WriteFullLine("2.Change Cups of Sugar per Pitcher.");
            WriteFullLine("3.Change Cubes of Ice per Cup.");
            WriteFullLine("4.Change Price per Cup.");
            WriteFullLine("5.Return.");
            WriteFullLine("Enter the number coresponding to the component you would like to change or 5 to return to the previous screen.");
            FillGrassBlock(10);
            PrintBackgroundSecondHalf();
        }
        public static void PrintRecipe(Recipe recipe)
        {
            PrintBackgroundFirstHalf();
            PrintRecipeContents(recipe);
            FillGrassBlock(4);
            PrintBackgroundSecondHalf();
        }
        public static void PrintChangePriceText(double pricePerCup,Recipe recipe)
        {
            PrintBackgroundFirstHalf();
            PrintRecipeContents(recipe);
            WriteFullLine($"Current Price of a Cup of Lemonade: {pricePerCup}");
            WriteFullLine("Enter the new Price per Cup:");
            FillGrassBlock(6);
            PrintBackgroundSecondHalf();
        }
        public static void PrintChangeSugarText(int cupsSugar,Recipe recipe)
        {
            PrintBackgroundFirstHalf();
            PrintRecipeContents(recipe);
            WriteFullLine($"Current Cups of Sugar per Pitcher: {cupsSugar}");
            WriteFullLine("Enter the new amount of Cups of Sugar per Pitcher:");
            FillGrassBlock(6);
            PrintBackgroundSecondHalf();
        }
        public static void PrintChangeIceText(int numIceCubes,Recipe recipe)
        {
            PrintBackgroundFirstHalf();
            PrintRecipeContents(recipe);
            WriteFullLine($"Current Ice Cubes per Cup: {numIceCubes}");
            WriteFullLine("Enter the new amount of Ice Cubes per Cup:");
            FillGrassBlock(6);
            PrintBackgroundSecondHalf();
        }
        public static void PrintChangeLemonsText(int numLemons,Recipe recipe)
        {
            PrintBackgroundFirstHalf();
            PrintRecipeContents(recipe);
            WriteFullLine($"Current Lemons per Pitcher: {numLemons}");
            WriteFullLine("Enter the new amount of Lemons per Pitcher:");
            FillGrassBlock(6);
            PrintBackgroundSecondHalf();
        }
    }
}
