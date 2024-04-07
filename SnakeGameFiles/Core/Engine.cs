using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private Wall _wall;
        private Snake _snake;
        private Direction _direction;
        private double _sleepTime;
        private Point[] _pointsOfDirection;
        public Engine(Wall wall, Snake snake)
        {
            _wall = wall;
            _snake = snake;
            _sleepTime = 100;
            _pointsOfDirection = new Point[4];
        }

        public void Run()
        {
            CreateDirections();
            while (true)
            {
                ShowScore();
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = _snake.IsMoving(_pointsOfDirection[(int)_direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                _sleepTime -= 0.1;
                Thread.Sleep((int)_sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = _wall.LeftX + 2;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.WriteLine("Would you like to continue? y/n");

            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("Game Over!");
            Environment.Exit(0);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (_direction != Direction.Right)
                {
                    _direction = Direction.Left;
                }
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (_direction != Direction.Left)
                {
                    _direction = Direction.Right;
                }
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (_direction != Direction.Down)
                {
                    _direction = Direction.Up;
                }
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (_direction != Direction.Up)
                {
                    _direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void CreateDirections()
        {
            _pointsOfDirection[0] = new Point(1, 0);
            _pointsOfDirection[1] = new Point(-1, 0);
            _pointsOfDirection[2] = new Point(0, 1);
            _pointsOfDirection[3] = new Point(0, -1);
        }

        private void ShowScore()
        {
            Console.SetCursorPosition(_wall.LeftX + 1, 0);
            Console.WriteLine($"Points score: {_snake.FoodEaten}");
            Console.CursorVisible = false;
        }
    }
}
