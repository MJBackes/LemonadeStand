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
        //Contr
        public Pitcher()
        {
            PitcherSize = 10;
            CupsLeftInPitcher = 0;
        }
        //MembMeth
        public void Refill()
        {
            CupsLeftInPitcher = PitcherSize;
        }
    }
}
