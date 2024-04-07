using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        public int LeftX { get; set; }
        public int TopY { get; set; }

        public Point(int leftX, int topY)
        {
            LeftX = leftX;
            TopY = topY;
        }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(LeftX, TopY);
            Console.WriteLine(symbol);
        }

        public void Draw(int leftX, int leftY, char symbol)
        {
            Console.SetCursorPosition(leftX, leftY);
            Console.WriteLine(symbol);
        }
    }

    
}
