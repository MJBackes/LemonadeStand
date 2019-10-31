using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class IdealLemonade
    {
        private double preferredNumberOfIceCubes;
        private double preferredNumberOfLemons;
        private double preferredNumberOfCupsOfSugar;
        private double preferredPrice;
        public double PreferredNumberOfIceCubes { get => preferredNumberOfIceCubes; set => preferredNumberOfIceCubes = value; }
        public double PreferredNumberOfLemons { get => preferredNumberOfLemons; set => preferredNumberOfLemons = value; }
        public double PreferredNumberOfCupsOfSugar { get => preferredNumberOfCupsOfSugar; set => preferredNumberOfCupsOfSugar = value; }
        public double PreferredPrice { get => preferredPrice; set => preferredPrice = value; }
        public IdealLemonade(double iceNum,double lemonNum,double sugarNum,double price)
        {
            preferredNumberOfCupsOfSugar = sugarNum;
            preferredNumberOfIceCubes = iceNum;
            preferredNumberOfLemons = lemonNum;
            preferredPrice = price;
        }
        public IdealLemonade()
        {

        }
    }
}
