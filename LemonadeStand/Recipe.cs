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
        private int numLemons;
        private int cupsSugar;
        private int numIceCubes;
        private double pricePerCup;
        public double PricePerCup
        {
            get => pricePerCup;
        }
        public int NumIceCubes
        {
            get => numIceCubes;
        }
        public int CupsSugar
        {
            get => cupsSugar;
        }
        public int NumLemons
        {
            get => numLemons;
        }
        //Contr
        public Recipe()
        {
            numLemons = 5;
            numIceCubes = 5;
            cupsSugar = 5;
            pricePerCup = .25;
        }
        //MembMeth
        public void ChangeLemons()
        {
            bool isValidInput;
            UserInterface.PrintChangeLemonsText(numLemons,this);
            do
            {
                isValidInput = int.TryParse(Console.ReadLine(), out numLemons);
            } while (!isValidInput || numLemons < 1);
        }
        public void ChangeLemons(int lemons)
        {
            numLemons = lemons;
        }
        public void ChangeIce()
        {
            bool isValidInput;
            UserInterface.PrintChangeIceText(numIceCubes,this);
            do
            {
                isValidInput = int.TryParse(Console.ReadLine(), out numIceCubes);
            } while (!isValidInput || numIceCubes < 0);
        }
        public void ChangeIce(int cubes)
        {
            numIceCubes = cubes;
        }
        public void ChangeSugar()
        {
            bool isValidInput;
            UserInterface.PrintChangeSugarText(cupsSugar,this);
            do
            {
                isValidInput = int.TryParse(Console.ReadLine(), out cupsSugar);
            } while (!isValidInput || cupsSugar < 0);
        }
        public void ChangeSugar(int sugar)
        {
            cupsSugar = sugar;
        }
        public void ChangePrice()
        {
            bool isValidInput;
            UserInterface.PrintChangePriceText(pricePerCup,this);
            do
            {
                isValidInput = double.TryParse(Console.ReadLine(), out pricePerCup);
            } while (!isValidInput || pricePerCup < .01);
            pricePerCup = Math.Round(pricePerCup * 100) / 100;
        }
        public void ChangePrice(double price)
        {
            pricePerCup = price;
        }
    }
}
