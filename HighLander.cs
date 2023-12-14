using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App4
{
    public class HighLander
    {

        public int id;
        public string name;
        public int powerLevel;
        public string type;
        public int X;
        public int Y;
        public int numberOfMove;

            public HighLander(int id, string name, int powerLevel, string type, int X, int Y)
            {
                this.id = id;
                this.name = name;
                this.powerLevel = powerLevel;
                this.type = type;
                this.X = X;
                this.Y = Y;
            }


        public void setX(int x) { this.X = x; }
            public void setY(int y) { this.Y = y; }
            public void setNumberOfMove(int number) { this.numberOfMove = number; }

            public void setPowerLevel(int powerLevel) { this.powerLevel = powerLevel; }
            public void setType(string type) { this.type = type; }
            public void setName(string name) { this.name = name; }

            public int getX() { return this.X; }
            public int getY() { return this.Y; }
            public int getNumberOfMove() { return this.numberOfMove; }
            public string getType() { return this.type; }
            public string getName() { return this.name; }
            public int getPowerLevel() { return this.powerLevel; }


        }
    
}
