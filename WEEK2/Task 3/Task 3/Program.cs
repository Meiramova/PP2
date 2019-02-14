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

        public static void Ex2(DirectoryInfo der, int level)// отправляем папку и иновой значение
        {

            foreach (FileInfo file in der.GetFiles())// пробегаемся по файлам которые находятся в папке
            {
                Ex1(level);// запускаем метод с пробелами
                Console.WriteLine(file.Name);// выводим названия файлов

            }

            foreach (DirectoryInfo diru in der.GetDirectories())// пробегаемся по папкам, которые лнаходятся внутри папки
            {
                Ex1(level); // хапускаем метод
                Console.WriteLine(diru.Name);// выписываем названия папок
                Ex2(diru, level + 1);// рекурсивно открываем все папки и вытаскиваем что внутри 
            }

        }

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("C:/Users/Зия/Desktop/study"); // открываем папку и прописываем к ней путь
            Ex2(dir, 0);// вызываем метод
            Console.ReadKey();
        }
    }
}
