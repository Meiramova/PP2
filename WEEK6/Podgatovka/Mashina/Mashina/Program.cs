using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Mashina
{
    class Program
    {
        public static List<body> bb = new List<body>();
        public static List<body> wall = new List<body>();
        public static bool ok;
        public static ConsoleKeyInfo kd = new ConsoleKeyInfo();

        public static void RideCar()
        {
            StreamReader sr = new StreamReader("Mashina.txt");
            string[] rows = sr.ReadToEnd().Split('\n');
            
            for( int i = 0; i < rows.Length; i++)
            {
                for ( int j = 0; j < rows[i].Length; j++)
                {
                    if(bb != null && rows[i][j] == '*' )
                        bb.Add(new body(j, i));
                }
            }
                
        }
        public static void ReadWall()
        {
            StreamReader sr = new StreamReader("wall.txt");
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (wall != null && rows[i][j] == '*')
                        wall.Add(new body(j, i));

            for (int i = wall.Count; i > 0; i--)
            {
                Console.Write('*');
            }
        }


        public static void Direction (ConsoleKeyInfo kd)
        {
            if(kd.Key == ConsoleKey.LeftArrow)
            {
                ok = false;
                    
            }
            else if( kd.Key == ConsoleKey.RightArrow)
            {
                ok = true;
            }
        }

        public static void Draw()
        {
            while (true)
            {
                Console.Clear();
                for(int i = bb.Count - 1; i > 0; i--)
                {
                    if (ok)
                    {
                        bb[i].x++;
                    }
                    else if (!ok)
                    {
                        bb[i].x--;
                    }
                    Console.SetCursorPosition(bb[i].x, bb[i].y);
                    Console.Write('*');
                }
                Thread.Sleep(300);
            }
            
               
        }
        static void Main(string[] args) 
        {
            Console.CursorVisible = false;
            RideCar();
            ReadWall();
            Thread thread = new Thread(Draw);
            thread.Start();

           
            while (true)
            {
                kd = Console.ReadKey();
                Direction(kd);
            }
        }
    }
}
