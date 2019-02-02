using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        public static bool F1(int n)// созздаю булевую функцию на проверку, передаем ему некое значение n
        {
            if (n == 1) return false; // проверяем если n = 1 или n = 2, то сразу эти числа не будут простыми
            if (n == 0) return false;
            int limit = Math.Sqrt(n); // создаю число, до каторого мы будем пробегаться, это корень из n
            for (int i = 2; i <= limit; ++i)// начинаю цикл с 2, так как на 0 и 1 мы уже сделали проверку
            {
                if (n % i == 0) return false;
            }
            return true;

        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); // ввожу размерность массива, перевожу со стринга в интовое значение
            int[] a = new int[n]; // создаю массив с размерностью n
            List<int> b = new List<int>();// создаю диннамический массив
            string[] s = new string[256]; //создаю массив из стрингов
            s = Console.ReadLine().Split(); // считываю массив с консоля, разбиваю его через Split()

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(s[i]); // каждый элемент массива стринга перевожу в интовое значение через Parse()
            }

            for (int i = 0; i < n; i++)
            {
                if (F1(a[i]))// вызываю булевую функцию, которая прописана выше
                {
                    b.Add(a[i]);// все те числа, которые прошли проверку добавляються в динамический массив
                }
            }

            Console.WriteLine(b.Count);// выводим размерность этого массива

            for (int j = 0; j < b.Count; j++)
            {
                Console.Write(b[j] + " "); // выводим все элементы этого массива
            }

            Console.ReadKey();// чтобы терминал сразу не закрывался
        }
    }
}
