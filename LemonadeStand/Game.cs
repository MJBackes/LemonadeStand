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
            SetUp();
            MainGame();
            foreach (Player player in players)
            {
                EndOfGameText(player);
            }
        }
        private void SetUp()
        {
            InstanciatePlayers();
            instanciateWeeks();
        }
        private void InstanciatePlayers()
        {
            bool areAllPlayerssetUp = false;
            string input;
            do
            {
                Console.Clear();
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
        private void PrintTodaysForecast()
        {
            Console.WriteLine("Today's Forecast:");
            Console.WriteLine($"    Temperature: {todaysForecast.Temperature}");
            Console.WriteLine($"    Conditions: {todaysForecast.Conditions}");
            Console.WriteLine($"    Confidence: {todaysForecast.ProbablilityOfAccurateForecast}%");

        }
        private void PrintAccurateForecast()
        {
            Console.WriteLine($"Temperature: {currentDay.weather.Temperature}");
            Console.WriteLine($"Conditions: {currentDay.weather.Conditions}");
        }
        private void GetTodaysForecast()
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
        private void PrintTodaysDate()
        {
            Console.WriteLine("Week: " + (weekIndex + 1) + " - Day: " + (dayIndex + 1));
        }
        private void StartOfDay(Player player)
        {
            bool isDoneSettingUp;
            do
            {
                Console.Clear();
                Console.WriteLine(player.Name);
                PrintTodaysDate();
                PrintTodaysForecast();
                isDoneSettingUp = player.SetUpForTheDay(store);
            } while (!isDoneSettingUp);
        }
        private void OpenForBusiness(Player player)
        {
            
            foreach(Customer customer in currentDay.Customers)
            {
                if (customer.WillIPurchase(player.recipe))
                {
                    player.CustomerSale();
                }
            }
        }
        private void DisplayTodaysInfo(Player player)
        {
            Console.Clear();
            Console.WriteLine(player.Name);
            Console.Write("Today's actual weather:");
            PrintAccurateForecast();
            Console.WriteLine($"Number of cups sold today: {player.CupsSoldToday}");
            Console.WriteLine($"Today's profit: {player.wallet.DailyProfit}");
            Console.WriteLine($"Total profit so far: {player.wallet.TotalProfit}");
            player.PrintResources();
            Console.ReadLine();
        }
        private void ChangeToNextDay()
        {
            dayIndex++;
            if(dayIndex == 7)
            {
                dayIndex = 0;
                weekIndex++;
            }
        }
        private void UpdatePlayerStats(Player player)
        {
            player.wallet.UpdateDailyProfit();
            player.wallet.UpdateTotalProfit();
            player.UpdateTotalCupsSold();
        }
        private void EndOfDayCleanUp(Player player)
        {
            player.inventory.MeltIceAtEndOfDay();
            player.inventory.SpoilLemons(rng);
            PrintResourcesLostAtEndOfDay(player);
            player.inventory.ResetDailyVariables();
            player.pitcher.EmptyPitcherAtEndOfDay();
            player.ResetCupsSoldToday();
        }
        private void PrintResourcesLostAtEndOfDay(Player player)
        {
            Console.WriteLine($"Number of Ice Cubes that melted at the end of the Day: {player.inventory.IceCubesMeltedToday}");
            Console.WriteLine($"Number of Lemons that spoiled today: {player.inventory.LemonsSpoiledToday}");
            Console.ReadLine();
        }
        private void MainGame()
        {
            while (weekIndex < NumberOfWeeks)
            {
                GetTodaysForecast();
                foreach (Player player in players)
                {
                    StartOfDay(player);
                }
                foreach (Player player in players)
                {
                    OpenForBusiness(player);
                    UpdatePlayerStats(player);
                }
                foreach (Player player in players)
                {
                    DisplayTodaysInfo(player);
                    EndOfDayCleanUp(player);
                }
                ChangeToNextDay();
            }

        }
        private void EndOfGameText(Player player)
        {
            Console.Clear();
            Console.WriteLine($"{player.Name}'s Final Statistics:");
            Console.WriteLine($"Total Profit: {player.wallet.TotalProfit}");
            Console.WriteLine($"Total Cups Sold: {player.TotalCupsSold}");
        }
    }
}
