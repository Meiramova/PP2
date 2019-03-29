using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task1
{
    class Program
    {
        public static int j = 0;
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[3];
            
            for(int i = 0; i < 3; i++)
            {
                j++;
                threads[i] = new Thread(Name);
                threads[i].Name = "Thread " + j;
                threads[i].Start();
            }
            Console.ReadKey();
        }
        public static void Name()
        {
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
            }
        }
    }
}
