using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArrayTraveller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<HighLander>[,] grid = new LinkedList<HighLander>[10,10];

            
            Random random = new Random();
            int gridSize = 10;
            int roundMove = 0;
            int exitValue = 1;
            HighLander fightWinner = null;
            int moveActionRandom1;
            int moveActionRandom2;

            int currentX1 = random.Next(0, gridSize); 
            int currentY1 = random.Next(0, gridSize);
            int currentX2 = random.Next(0, gridSize);
            int currentY2 = random.Next(0, gridSize);
            HighLander hl1 = new HighLander(1,"hl1",50,"Good",currentX1,currentY1);
            HighLander hl2 = new HighLander(2, "hl2", 80, "Bad", currentX2, currentY2);
            
            //grid[currentX1, currentY1].AddLast(hl1);
            //grid[currentX2, currentY2].AddLast(hl2);    
            Console.WriteLine("Start point: The X of hl1 is {0},the Y of hl1 is {1}", hl1.getX(),hl1.getY());
            Console.WriteLine("Start point: The X of hl2 is {0},the Y of hl2 is {1}", hl2.getX(), hl2.getY());
            //




            //
            


            while (exitValue == 1) {
                 moveActionRandom1 = Movement.moveActionRandom(hl1.getX(), hl1.getY(), random, gridSize);
                
                 moveActionRandom2= Movement.moveActionRandom(hl2.getX(), hl2.getY(), random, gridSize);

                Movement.moveAction(moveActionRandom1, hl1);
                Movement.moveAction(moveActionRandom2, hl2);

                Console.WriteLine("Move{0}: The X of hl1 is {1},the Y of hl1 is {2}", roundMove,hl1.getX(), hl1.getY());
                Console.WriteLine("Move{0}: The X of hl2 is {1},the Y of hl2 is {2}", roundMove, hl2.getX(), hl2.getY());

                if(hl1.getX() == hl2.getX() && hl1.getY()==hl2.getY()) {
                    fightWinner = Fight.fightWinner(hl1, hl2);
                    exitValue = 0;
                }

                roundMove++;
            }

            Console.WriteLine("Winner is {0}, he is in the location - x:{1} y:{2}", fightWinner.getName(), fightWinner.getX(), fightWinner.getY());

        }

       
    }
}
