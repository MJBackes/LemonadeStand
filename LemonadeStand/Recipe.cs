using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe
    {
        //MembVars
        public int NumLemons;
        public int CupsSugar;
        public int NumIceCubes;
        public double PricePerCup;
        //Contr
        public Recipe()
        {
            NumLemons = 5;
            NumIceCubes = 5;
            CupsSugar = 5;
            PricePerCup = .25;
        }
        //MembMeth
        public void PrintRecipe()
        {
            Console.WriteLine($"Lemons per Pitcher: {NumLemons}");
            Console.WriteLine($"Cups of Sugar per Pitcher: {CupsSugar}");
            Console.WriteLine($"Number of Ice Cubes per Cup: {NumIceCubes}");
            Console.WriteLine($"Price per Cup: {PricePerCup}");
        }
        public void ChangeLemons()
        {
            bool isValidInput;
            Console.Clear();
            Console.WriteLine($"Current Lemons per Pitcher: {NumLemons}");
            Console.WriteLine("Enter the new amount of Lemons per Pitcher:");
            do
            {
                isValidInput = int.TryParse(Console.ReadLine(), out NumLemons);
            } while (!isValidInput || NumLemons < 1);
        }
        public void ChangeIce()
        {
            bool isValidInput;
            Console.Clear();
            Console.WriteLine($"Current Ice Cubes per Cup: {NumIceCubes}");
            Console.WriteLine("Enter the new amount of Ice Cubes per Cup:");
            do
            {
                isValidInput = int.TryParse(Console.ReadLine(), out NumIceCubes);
            } while (!isValidInput || NumIceCubes < 0);
        }
        public void ChangeSugar()
        {
            bool isValidInput;
            Console.Clear();
            Console.WriteLine($"Current Cups of Sugar per Pitcher: {CupsSugar}");
            Console.WriteLine("Enter the new amount of Cups of Sugar per Pitcher:");
            do
            {
                isValidInput = int.TryParse(Console.ReadLine(), out CupsSugar);
            } while (!isValidInput || CupsSugar < 0);
        }
        public void ChangePrice()
        {
            bool isValidInput;
            Console.Clear();
            Console.WriteLine($"Current Price of a Cup of Lemonade: {PricePerCup}");
            Console.WriteLine("Enter the new Price per Cup:");
            do
            {
                isValidInput = double.TryParse(Console.ReadLine(), out PricePerCup);
            } while (!isValidInput || PricePerCup < 0);
            PricePerCup -= (PricePerCup % .01);
        }
    }
}
