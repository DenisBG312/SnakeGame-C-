using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char FoodSymbol = '$';
        private const int FoodPoints = 2;
        public FoodDollar(Wall wall) : base(wall, FoodSymbol, FoodPoints)
        {

        }
    }
}
