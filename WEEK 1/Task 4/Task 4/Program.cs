using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());//считываю стринг, перевожу его в интовое значение
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)// создаю двойной массив, чей второй индекс пробегается до первого
                {
                    Console.Write("[*]");// вывожу в этих местах звездочки, получаем прямой треугольник
                }
                Console.WriteLine();// чтобы с новой строки начинал
            }
            Console.ReadKey();// чтобы терминал не закрывался
        }
    }
}
