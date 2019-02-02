using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        public static void Y(int[] a, int[] b, int n, int[] c)
        {
            Array.Copy(a, b, (n));
            c = a.Concat(b).ToArray();
            Array.Sort(c);

            for (int i = 0; i < (2 * n); i++)
            {
                Console.Write(c[i] + " ");
            }
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            string[] s = new string[256];
            int[] b = new int[n];
            s = Console.ReadLine().Split();
            int[] c = new int[2 * n];

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(s[i]);
            }

            Y(a, b, n, c);

            Console.ReadKey();
        }
    }
}
