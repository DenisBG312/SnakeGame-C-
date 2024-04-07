using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';
        public Wall(int leftX, int topY) : base(leftX, topY)
        {
            InitializeBorders(leftX, topY);
        }

        private void InitializeBorders(int leftX, int topY)
        {
            SetHorizontalLine(0);
            SetHorizontalLine(topY);

            SetVerticalLine(0);
            SetVerticalLine(leftX);
        }

        public void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX <= LeftX; leftX++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }

        public void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY <= TopY; topY++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }

        public bool IsPointOnWall(Point point)
        {
            return point.LeftX == 0 ||
                   point.TopY == 0 ||
                   point.LeftX == LeftX ||
                   point.TopY == TopY;
        }
    }
}
