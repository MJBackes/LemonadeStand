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
        public static void PrintGetNumberOfWeeksText()
        {
            Console.Clear();
            Console.WriteLine("How many weeks do you want to play(1-5)?");
        }
        public static void DisplayRules()
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
        public static void PrintInstanciatePlayerText()
        {
            Console.Clear();
            Console.WriteLine("1.Add another Human player.");
            Console.WriteLine("2.Add another AI player.");
            Console.WriteLine("3.Finish adding players.");
        }
        public static void PrintTodaysForecast(Weather todaysForecast)
        {
            Console.WriteLine("Today's Forecast:");
            Console.WriteLine($"    Temperature: {todaysForecast.Temperature}");
            Console.WriteLine($"    Conditions: {todaysForecast.Conditions}");
            Console.WriteLine($"    Confidence: {todaysForecast.ProbablilityOfAccurateForecast}%");
        }
        public static void PrintAccurateForecast(Weather weather)
        {
            Console.Write("Today's actual weather:");
            Console.WriteLine($"Temperature: {weather.Temperature}");
            Console.WriteLine($"Conditions: {weather.Conditions}");
        }
        public static void PrintPlayersEndOfDayInfo(Player player)
        {
            Console.WriteLine($"Number of cups sold today: {player.CupsSoldToday}");
            Console.WriteLine($"Today's profit: {player.wallet.DailyProfit}");
            Console.WriteLine($"Total profit so far: {player.wallet.TotalProfit}");
        }
        public static void PrintPlayersResourcesLostAtEndOfDay(Player player)
        {
            Console.WriteLine($"Number of Ice Cubes that melted at the end of the Day: {player.inventory.IceCubesMeltedToday}");
            Console.WriteLine($"Number of Lemons that spoiled today: {player.inventory.LemonsSpoiledToday}");
        }
        public static void PrintPlayersEndOfGameText(Player player)
        {
            Console.Clear();
            Console.WriteLine($"{player.Name}'s Final Statistics:");
            Console.WriteLine($"Total Profit: {player.wallet.TotalProfit}");
            Console.WriteLine($"Total Cups Sold: {player.TotalCupsSold}");
        }
        public static void PrintGetPurchaseSizeText(Player player,string itemName,double itemPrice,int smallDiscountThreshold,int largeDiscountThreshold)
        {
            Console.WriteLine($"Price per {itemName}: {itemPrice}");
            Console.WriteLine($"10% Discount on purchases of {smallDiscountThreshold} or more.");
            Console.WriteLine($"15% Discount on purchases of {largeDiscountThreshold} or more.");
            Console.WriteLine("Your Wallet: " + player.wallet.Money);
            Console.WriteLine($"How many {itemName}(s) would you like to buy?");
        }
        public static void PrintGetItemToSellText(Player player)
        {
            Console.Clear();
            PrintPlayerResources(player);
            Console.WriteLine("1.Buy Lemons.");
            Console.WriteLine("2.Buy Ice Cubes.");
            Console.WriteLine("3.Buy Cups of Sugar.");
            Console.WriteLine("4.Buy Cups");
            Console.WriteLine("5.Return.");
            Console.WriteLine("Enter the number coresponding to the purchase you would like to make or" +
                " 5 to return to the previous screen.");
        }
        public static void PrintIfPurchaseTooLarge(Player player)
        {
            Console.Clear();
            Console.WriteLine($"Store to {player.Name}: Not enough money to purchase that many.");
            Console.ReadLine();
        }
        public static void PrintGetChangeRecipeInputText()
        {
            Console.WriteLine("1.Change Lemons per Pitcher.");
            Console.WriteLine("2.Change Cups of Sugar per Pitcher.");
            Console.WriteLine("3.Change Cubes of Ice per Cup.");
            Console.WriteLine("4.Change Price per Cup.");
            Console.WriteLine("5.Return.");
            Console.WriteLine("Enter the number coresponding to the component you would like to change or 5 to return to the previous screen.");
        }
        public static void PrintRecipe(Recipe recipe)
        {
            Console.WriteLine($"Lemons per Pitcher: {recipe.NumLemons}");
            Console.WriteLine($"Cups of Sugar per Pitcher: {recipe.CupsSugar}");
            Console.WriteLine($"Number of Ice Cubes per Cup: {recipe.NumIceCubes}");
            Console.WriteLine($"Price per Cup: {recipe.PricePerCup}");
        }
        public static void PrintInventory(Inventory inv)
        {
            Console.WriteLine($"Lemons: {inv.LemonStock}");
            Console.WriteLine($"Cups of Sugar: {inv.SugarStock}");
            Console.WriteLine($"Ice Cubes: {inv.IceStock}");
            Console.WriteLine($"Cups: {inv.CupStock}");
        }
        public static void PrintWallet(Wallet wallet)
        {
            Console.WriteLine($"Wallet: {wallet.Money}");
        }
        public static void PrintPlayerResources(Player player)
        {
            PrintInventory(player.inventory);
            PrintWallet(player.wallet);
        }
        public static void PrintGetNameText()
        {
            Console.WriteLine("Enter your name:");
        }
        public static void PrintSetUpForTheDayText()
        {
            Console.WriteLine("1.Purchase Ingredients.");
            Console.WriteLine("2.Change Recipe.");
            Console.WriteLine("3.Finish today's setup.");
            Console.WriteLine("Enter 1 to go to the store, 2 to change your recipe, or 3 to finish setting up for the day.");
        }
        public static void PrintChangePriceText(double pricePerCup)
        {
            Console.Clear();
            Console.WriteLine($"Current Price of a Cup of Lemonade: {pricePerCup}");
            Console.WriteLine("Enter the new Price per Cup:");
        }
        public static void PrintChangeSugarText(int cupsSugar)
        {
            Console.Clear();
            Console.WriteLine($"Current Cups of Sugar per Pitcher: {cupsSugar}");
            Console.WriteLine("Enter the new amount of Cups of Sugar per Pitcher:");
        }
        public static void PrintChangeIceText(int numIceCubes)
        {
            Console.Clear();
            Console.WriteLine($"Current Ice Cubes per Cup: {numIceCubes}");
            Console.WriteLine("Enter the new amount of Ice Cubes per Cup:");
        }
        public static void PrintChangeLemonsText(int numLemons)
        {
            Console.Clear();
            Console.WriteLine($"Current Lemons per Pitcher: {numLemons}");
            Console.WriteLine("Enter the new amount of Lemons per Pitcher:");
        }
    }
}
