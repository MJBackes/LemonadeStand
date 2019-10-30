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
        private Random rng;
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
            UserInterface.PrintGetNumberOfWeeksText();
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
            UserInterface.DisplayRules();
            Console.ReadLine();
        }
        public void RunGame()
        {
            displayRules();
            SetUp();
            MainGame();
            foreach (Player player in players)
            {
                UserInterface.PrintPlayersEndOfGameText(player);
                Console.ReadLine();
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
            int playerNumber = 1;
            do
            {
                UserInterface.PrintInstanciatePlayerText();
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        players.Add(new HumanPlayer());
                        playerNumber++;
                        break;
                    case "2":
                        players.Add(new AIPlayer(playerNumber, rng));
                        playerNumber++;
                        break;
                    case "3":
                        areAllPlayerssetUp = true;
                        break;
                    default:
                        break;
                }
            }while(!areAllPlayerssetUp);
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
        private void StartOfDay(Player player)
        {
            bool isDoneSettingUp;
            UserInterface.PrintTodaysInfo(player,weekIndex, dayIndex, todaysForecast);
            Console.ReadLine();
            do
            {
                Console.Clear();
                isDoneSettingUp = player.SetUpForTheDay(store,todaysForecast);
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
            UserInterface.PrintDisplayTodaysInfoText(player, currentDay.weather);
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
            UserInterface.PrintPlayersResourcesLostAtEndOfDay(player);
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
    }
}
