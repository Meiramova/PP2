using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Masha
{
    class Program
    {
        public static int g = 0, r = 0;
        public static int gy = 0, ry = 1;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Thread th1 = new Thread(Green);
            Thread th2 = new Thread(Red);
            th1.Start();
            th2.Start();
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if(keyInfo.Key == ConsoleKey.Spacebar)
                {
                    th1.Abort();
                    th2.Abort();
                }
            }
        }

        public static void Green()
        {
            while (true)
            {
                if(g == 10)
                {
                    gy += 2;
                    g = 0;
                }
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(g++, gy);
                Console.Write("))))");
                Thread.Sleep(500);
            }
        }

        public static void Red()
        {
            while (true)
            {
                if(r == 10)
                {
                    ry += 2;
                    r = 0;
                }
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(r++, ry);
                Console.Write("))))");
                Thread.Sleep(225);
            }
        }
    }
}
