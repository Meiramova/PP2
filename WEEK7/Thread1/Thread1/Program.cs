using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Thread1
{
    class Program
    {
        public class MyThread
        {
            Thread thread;

           // public MyThread( string name, int num) { }

            public MyThread(string name, int num)
            {
                thread = new Thread(this.func);
                thread.Name = name;
                thread.Start(num);
            }

            public void func(object num)
            {
                for(int i = 0; i < (int)num; i++)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " is " + i);
                    Thread.Sleep(100);
                }
                Console.WriteLine(Thread.CurrentThread.Name + "ends");
            }
        }
        static void Main(string[] args)
        {
            MyThread t1 = new MyThread("Th1", 6);
            MyThread t2 = new MyThread("Th2", 5);
            MyThread t3 = new MyThread("Th3", 1);

            Console.ReadKey();
        }

        
    }
}
