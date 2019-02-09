using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        public static void Y(int[] a, int[] b, int n, int[] c)// создаю функцию с 3 массивами и 1 интовым значением
        {
            Array.Copy(a, b, (n));// присваиваю все элементы из массива а в массив б
            c = a.Concat(b).ToArray();// объединяю массив а и б в массив с
            Array.Sort(c);// сортирую массив

            for (int i = 0; i < (2 * n); i++)
            {
                Console.Write(c[i] + " "); вывожу массив
            }
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); // создала интовую переменную, перевожу стринг на инт и считываю
            int[] a = new int[n]; // создаю массив из инт
            string[] s = new string[256]; // создаю массив из стрингов
            int[] b = new int[n]; // массив из инт
            s = Console.ReadLine().Split(); // считывю стринг и разделяю через проблелы через функцию сплит
            int[] c = new int[2 * n]; // создаю массив из инт, размер которого в 2 раза больше чем предыдущего

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(s[i]);// перевожу все элементы в интовое значение
            }

            Y(a, b, n, c);// вызываю функцию

            Console.ReadKey();// чтобы терминал не закрывался
        }
    }
}
