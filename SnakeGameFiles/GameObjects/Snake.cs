using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSnake.GameObjects.Foods;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char SnakeSymbol = '\u25CF';
        private const char EmptySymbol = ' ';

        private readonly Wall _wall;
        private readonly Queue<Point> _snakeElements;
        private readonly List<Food> _foods;

        private int _nextLeftX;
        private int _nextTopY;
        private int _foodIndex;

        public Snake(Wall wall)
        {
            _wall = wall;
            _snakeElements = new Queue<Point>();
            _foods = new List<Food>();
            _foodIndex = RandomFoodNumber;

            GetFoods();
            CreateFood();
            CreateSnake();
        }

        public int RandomFoodNumber => new Random().Next(0, _foods.Count);

        public int FoodEaten { get; set; }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = _snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = _snakeElements
                .Any(s => s.LeftX == _nextLeftX && 
                          s.TopY == _nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(_nextLeftX, _nextTopY);

            if (_wall.IsPointOnWall(newSnakeHead))
            {
                return false;
            }

            _snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(SnakeSymbol);

            if (_foods[_foodIndex].IsFoodPoint(newSnakeHead))
            {
                Eat(direction, currentSnakeHead);
            }

            Point snakeTail = _snakeElements.Dequeue();
            snakeTail.Draw(EmptySymbol);

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int foodPoints = _foods[_foodIndex].FoodPoints;
            for (int i = 0; i < foodPoints; i++)
            {
                _snakeElements.Enqueue(new Point(_nextLeftX, _nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            FoodEaten += foodPoints;
            CreateFood();
        }

        private void CreateFood()
        {
            _foodIndex = RandomFoodNumber;
            _foods[_foodIndex].SetRandomPosition(_snakeElements);
        }

        private void GetFoods()
        {
            _foods.Add(new Asterisk(_wall));
            _foods.Add(new FoodDollar(_wall));
            _foods.Add(new FoodHash(_wall));
        }
        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                _snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            _nextLeftX = snakeHead.LeftX + direction.LeftX;
            _nextTopY = snakeHead.TopY + direction.TopY;
        }
    }
}
