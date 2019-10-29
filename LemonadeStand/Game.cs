using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        //MembVars
        public List<Player> players;
        public int NumberOfWeeks;
        public List<Week> weeks;
        Store store;
        private int dayIndex;
        private int weekIndex;
        private Day currentDay;
        private Weather todaysForecast;
        private Random rng; //Putting this here doesn't make the most sense from an OOP perspective, but instanciating the Randoms
                           //in the appropriate classes led to them having the same seed and therefore the same output, so I moved
                          // it here in order to pass around the reference to a single Random object.
        //Contr
        public Game()
        {
            rng = new Random();
            store = new Store();
            players = new List<Player>();
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
            } while (!isValidInput || input > 5 || input < 1);
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
            Console.ReadLine();

        }
        public void RunGame()
        {
            displayRules();
            setUp();
            mainGame();
            foreach (Player player in players)
            {
                endOfGameText(player);
            }
        }
        private void setUp()
        {
            Console.Clear();
            instanciatePlayers();
            instanciateWeeks();
        }
        private void instanciatePlayers()
        {
            bool areAllPlayerssetUp = false;
            string input;
            do
            {
                Console.WriteLine("1.Add another player.");
                Console.WriteLine("2.Finish adding players.");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        players.Add(new HumanPlayer());
                        break;
                    case "2":
                        areAllPlayerssetUp = true;
                        break;
                    default:
                        break;
                }
            }while(!areAllPlayerssetUp);
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
            Console.WriteLine("Today's Forecast:");
            Console.WriteLine($"    Temperature: {todaysForecast.Temperature}");
            Console.WriteLine($"    Conditions: {todaysForecast.Conditions}");
            Console.WriteLine($"    Confidence: {todaysForecast.ProbablilityOfAccurateForecast}%");

        }
        private void printAccurateForecast()
        {
            Console.WriteLine($"Temperature: {currentDay.weather.Temperature}");
            Console.WriteLine($"Conditions: {currentDay.weather.Conditions}");
        }
        private void getTodaysForecast()
        {
            currentDay = weeks[weekIndex].DaysOfTheWeek[dayIndex];
            double coinFlip = rng.NextDouble();
            double ProbablilityOfAccurateForecast = rng.NextDouble();
            if (coinFlip > ProbablilityOfAccurateForecast)
            {
                todaysForecast = currentDay.weather;
            }
            else
            {
                todaysForecast = new Weather(rng);  
            }
            todaysForecast.ProbablilityOfAccurateForecast = ProbablilityOfAccurateForecast;
        }
        private void printTodaysDate()
        {
            Console.WriteLine("Week: " + (weekIndex + 1) + " - Day: " + (dayIndex + 1));
        }
        private void startOfDay(Player player)
        {
            bool isDoneSettingUp = false;
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine(player.Name);
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
            Console.WriteLine(player.Name);
            Console.Write("Today's actual weather:");
            printAccurateForecast();
            Console.WriteLine($"Number of cups sold today: {player.CupsSoldToday}");
            Console.WriteLine($"Today's profit: {player.wallet.DailyProfit}");
            Console.WriteLine($"Total profit so far: {player.wallet.TotalProfit}");
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
            player.wallet.UpdateDailyProfit();
            player.wallet.UpdateTotalProfit();
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
                getTodaysForecast();
                foreach (Player player in players)
                {
                    startOfDay(player);
                }
                foreach (Player player in players)
                {
                    openForBusiness(player);
                    updatePlayerStats(player);
                }
                foreach (Player player in players)
                {
                    displayTodaysInfo(player);
                    endOfDayCleanUp(player);
                }
                changeToNextDay();
            }

        }
        private void endOfGameText(Player player)
        {
            Console.Clear();
            Console.WriteLine($"{player.Name}'s Final Statistics:");
            Console.WriteLine($"Total Profit: {player.wallet.TotalProfit}");
            Console.WriteLine($"Total Cups Sold: {player.TotalCupsSold}");
        }
    }
}
