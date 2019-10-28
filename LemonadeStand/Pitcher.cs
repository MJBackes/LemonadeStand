using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Pitcher
    {

        //MembVars
        public int CupsLeftInPitcher;
        public int PitcherSize;
        public bool isEmpty;
        //Contr
        public Pitcher()
        {
            PitcherSize = 10;
            CupsLeftInPitcher = 0;
            isEmpty = true;
        }
        //MembMeth
        public void Refill()
        {
            CupsLeftInPitcher = PitcherSize;
            isEmpty = false;
        }
        public void CheckIfEmpty()
        {
            if(CupsLeftInPitcher == 0)
            {
                isEmpty = true;
            }
        }
    }
}
