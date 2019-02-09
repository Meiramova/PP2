using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_3
{
    class Program
    {
        public static void Ex1(int level)
        {
            for (int i = 0; i < level; i++)
            {
                Console.Write("       ");
            }

        }

        public static void Ex2(DirectoryInfo der, int level)
        {

            foreach (FileInfo file in der.GetFiles())
            {
                Ex1(level);
                Console.WriteLine(file.Name);

            }

            foreach (DirectoryInfo diru in der.GetDirectories())
            {
                Ex1(level);
                Console.WriteLine(diru.Name);
                Ex2(diru, level + 1);
            }

        }

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("C:/Users/Зия/Desktop/study");
            Ex2(dir, 0);
            Console.ReadKey();
        }
    }
}
