using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1 
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");//создаю стримридер, считывает с input.txt
            String s = sr.ReadToEnd();// создаем стринг и считываем его до конца
            bool ok = false; // создаем булевую переменную
          
            for ( int i = 0; i < s.Length; i++)// пробегаемся по стрингу
            {
                if (s[i] == s[s.Length - 1 - i])// рекурсивно пробегаемся по элементам массива с начала и с конца одновременно
                {
                    ok = true;
                }
                else

                {
                    ok = false;
                }
            }
            sr.Close();// закрываем потом считывания
            if (ok)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            Console.ReadKey();
        }
    }
}
