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
        public Player player;
        public int NumberOfWeeks;
        public List<Week> weeks;
        Store store;
        //Contr
        public Game()
        {
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
                weeks.Add(new Week(i + 1));
            }
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
            setUp();
        }
        private void setUp()
        {
            player = new HumanPlayer();
            instanciateWeeks();
        }
        private void purchaseIngredients()
        {
            store.SellToPlayer(player);
        }
        private void setRecipe()
        {
            player.ChangeRecipe();
        }
        private void startOfDay()
        {
            bool isDoneSettingUp = false;
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("1.Purchase Ingredients.");
                Console.WriteLine("2.Change Recipe.");
                Console.WriteLine("3.Finish today's setup.");
                Console.WriteLine("Enter 1 to go to the store, 2 to change your recipe, or 3 to finish setting up for the day.");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        purchaseIngredients();
                        break;
                    case "2":
                        setRecipe();
                        break;
                    case "3":
                        isDoneSettingUp = true;
                        break;
                    default:
                        break;
                }
            } while (!isDoneSettingUp);
        }
        private void openForBusiness()
        {

        }
        private void mainGame()
        {
            startOfDay();

        }
    }
}
