using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        public static bool F1(int n)// созздаю булевую функцию на проверку, передаем ему некое значение n
        {
            if (n == 1) return false; // проверяем если n = 1 или n = 2, то сразу эти числа не будут простыми
            if (n == 0) return false;
            double limit = Math.Sqrt(n); // создаю число, до каторого мы будем пробегаться, это корень из n
            for (int i = 2; i <= limit; ++i)// начинаю цикл с 2, так как на 0 и 1 мы уже сделали проверку
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");
            string s = sr.ReadToEnd();
            string[] st = s.Split();
            int[] a = new int[st.Length];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(st[i]);
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (F1(a[i]))
                {
                    sw.Write(a[i]);
                    sw.WriteLine();

                }
                else
                {
                    continue;
                }
            }
            sr.Close();
            sw.Close();
            Console.ReadKey();

        }
    }
}
