using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4
{
     static class Fight
    {
        public static HighLander fightWinner(HighLander hl1, HighLander hl2)
        {
            Console.WriteLine("{0} and {1} meet in the x: {2} y:{3}", hl1.getName(), hl2.getName(), hl1.getX(), hl1.getY()); ;
            if (hl1.getPowerLevel() < hl2.getPowerLevel())
            {
                return hl2;
            }
            else
            {
                return hl1;
            }
            
        }
    }
}
