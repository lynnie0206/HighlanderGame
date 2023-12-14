using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4
{
   static class Movement
    {
        public static void moveAction( int moveActionRandom, HighLander hl)
        {
            if (moveActionRandom == 1)
            {
                Console.WriteLine("{0} moved left-up",hl.getName());
                hl.setX(hl.getX()-1);
                hl.setY(hl.getY()-1);
                hl.setNumberOfMove(hl.getNumberOfMove()+1);
            }
            else if (moveActionRandom == 2)
            {
                Console.WriteLine("{0} moved up", hl.getName());
                hl.setX(hl.getX() - 1);
                hl.setNumberOfMove(hl.getNumberOfMove() + 1);

            }
            else if (moveActionRandom == 3)
            {
                Console.WriteLine("{0} moved right-up", hl.getName());
                hl.setX(hl.getX() - 1);
                hl.setY(hl.getY() + 1);
                hl.setNumberOfMove(hl.getNumberOfMove() + 1);

      
            }
            else if (moveActionRandom == 4)
            {
                Console.WriteLine("{0} moved left", hl.getName());
                hl.setY(hl.getY() - 1);
                hl.setNumberOfMove(hl.getNumberOfMove() + 1);

            }
            else if (moveActionRandom == 5)
            {
                Console.WriteLine("{0} moved right", hl.getName());
                hl.setY(hl.getY() + 1);
                hl.setNumberOfMove(hl.getNumberOfMove() + 1);

            }
            else if (moveActionRandom == 6)
            {
                Console.WriteLine("{0} moved down", hl.getName());
                hl.setX(hl.getX() + 1);
                hl.setNumberOfMove(hl.getNumberOfMove() + 1);

            }
            else if (moveActionRandom == 7)
            {
                Console.WriteLine("{0} moved left-down", hl.getName());
                hl.setX(hl.getX() + 1);
                hl.setY(hl.getY() - 1);
                hl.setNumberOfMove(hl.getNumberOfMove() + 1);


              
            }
            else if (moveActionRandom    == 8)
            {
                Console.WriteLine("{0} moved right-down", hl.getName());
                hl.setX(hl.getX() + 1);
                hl.setY(hl.getY() + 1);
                hl.setNumberOfMove(hl.getNumberOfMove() + 1);

            }
        }
        public static int moveActionRandom(int x, int y, Random random, int gridSize)
        {
            if (x == 0 && y != 0 && y != (gridSize - 1))
            {
                int[] moveExceptUp = { 4, 5, 6, 7, 8 };
                int randmove = random.Next(0, 5);
                return moveExceptUp[randmove];
            }
            else if (x == (gridSize - 1) && y != 0 && y != (gridSize - 1))
            {
                int[] moveExceptDown = { 1, 2, 3, 4, 5 };
                int randmove = random.Next(0, 5);
                return moveExceptDown[randmove];

            }
            else if (y == 0 && x != 0 && x != (gridSize - 1))
            {
                int[] moveExceptLeft = { 2, 3, 5, 6, 8 };
                int randmove = random.Next(0, 5);
                return moveExceptLeft[randmove];
            }
            else if (y == (gridSize - 1) && x != 0 && x != (gridSize - 1))
            {
                int[] moveExceptRight = { 1, 2, 4, 6, 7 };
                int randmove = random.Next(0, 5);
                return moveExceptRight[randmove];
            }
            else if (x == 0 && y == 0)
            {
                int[] moveExceptUpAndLeft = { 5, 6, 8 };
                int randmove = random.Next(0, 3);
                return moveExceptUpAndLeft[randmove];
            }
            else if (x == 0 && y == (gridSize - 1))
            {
                int[] moveExceptUpAndRight = { 4,6,7 };
                int randmove = random.Next(0, 3);
                return moveExceptUpAndRight[randmove];
            }
            else if (x == (gridSize - 1) && y == 0)
            {
                int[] moveExceptDownAndLeft = { 2, 3, 5 };
                int randmove = random.Next(0, 3);
                return moveExceptDownAndLeft[randmove];
            }
            else if (x == (gridSize - 1) && y == (gridSize - 1))
            {
                int[] moveExceptDownAndRight = { 1, 2, 4 };
                int randmove = random.Next(0, 3);
                return moveExceptDownAndRight[randmove];
            }
            else
            {
                int randmove = random.Next(1, 9);
                return randmove;
            }
        }
    }
}
