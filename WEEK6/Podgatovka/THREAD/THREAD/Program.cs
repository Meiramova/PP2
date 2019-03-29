using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adadad
{
    class Chelik
    {
        int x;
        int y;
        public Chelik()
        {
            int x = 0;
            int y = 0;
        }

        public void Move(int dx, int dy)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            x += dx;
            if (x == 40)
                x = 0;
            else if (x < 0)
                x = 39;
            y += dy;
            if (y == 20)
                y = 0;
            else if (y < 0)
                y = 19;
            Console.SetCursorPosition(x, y);
            Console.Write("X");
        }
    }

    class Program
    {
        public static Chelik chelik = new Chelik();
        public static ConsoleKeyInfo key;
        public static int dx, dy = 0;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 20);
            Console.SetBufferSize(40, 20);
            Timer timer = new Timer(150);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            while (true)
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    dx = 0;
                    dy = -1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    dx = 0;
                    dy = 1;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    dx = 1;
                    dy = 0;
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    dx = -1;
                    dy = 0;
                }
            }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            chelik.Move(dx, dy);
        }
    }
}
