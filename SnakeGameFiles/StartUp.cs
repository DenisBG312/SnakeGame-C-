using SimpleSnake.Core;
using SimpleSnake.GameObjects;

namespace SimpleSnake
{
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(32, 18);
            Snake snake = new Snake(wall);

            Engine engine = new Engine(wall, snake);
            engine.Run();

            //Point p = new Point(0, 0);
            //p.Draw('@');

            //Wall wall = new Wall(20, 20);
        }
    }
}
