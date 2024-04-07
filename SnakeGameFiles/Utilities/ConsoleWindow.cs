namespace SimpleSnake.Utilities
{
    using System;
    using System.Text;
    using System.Runtime.InteropServices;

    public static class ConsoleWindow
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOWNORMAL = 1;

        public static void CustomizeConsole()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;

            // Get the current window and buffer sizes
            int currentWidth = Console.WindowWidth;
            int currentHeight = Console.WindowHeight;
            int currentBufferWidth = Console.BufferWidth;
            int currentBufferHeight = Console.BufferHeight;

            // Increase the height and width by a fixed amount
            int newWidth = (int)(currentWidth * 1.1);
            int newHeight = (int)(currentHeight * 1.1);

            // Check if the new window size would exceed the buffer size
            if (newWidth <= currentBufferWidth && newHeight <= currentBufferHeight)
            {
                Console.WindowWidth = newWidth;
                Console.WindowHeight = newHeight;
            }

            // Show the console window with updated size
            ShowWindow(ThisConsole, SW_SHOWNORMAL);
        }
    }
}