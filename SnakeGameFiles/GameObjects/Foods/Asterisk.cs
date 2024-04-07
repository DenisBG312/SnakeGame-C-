using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.Foods
{
    public class Asterisk : Food
    {
        private const char FoodSymbol = '*';
        private const int FoodPoints = 1;
        public Asterisk(Wall wall) 
            : base(wall, FoodSymbol, FoodPoints)
        {

        }
    }
}
