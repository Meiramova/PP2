using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        public static bool F1(int n)
        {
            if (n == 1) return false;
            if (n == 0) return false;
            var limit = Math.Sqrt(n);
            for (int i = 2; i <= limit; ++i)
            {
                if (n % i == 0) return false;
            }
            return true;

        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            List<int> b = new List<int>();
            List<int> c = new List<int>();
            string[] s = new string[256];
            s = Console.ReadLine().Split();

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(s[i]);
            }

            for (int i = 0; i < n; i++)
            {
                if (F1(a[i]))
                {
                    b.Add(a[i]);
                }
            }

            Console.WriteLine(b.Count);

            for (int j = 0; j < b.Count; j++)
            {
                Console.Write(b[j] + " ");
            }

            Console.ReadKey();
        }
    }
}
