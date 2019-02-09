using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_4
{
    class Program
    {
        public static void f1()//метод чтобы создавать, кпировать и удалять файл
        {
            StreamWriter xaxa = new StreamWriter("C:/Users/Зия/Desktop/C#/uf.txt");//создаю файл
            xaxa.WriteLine("Privet iz proshlogo");
            xaxa.Close();
            // есть другой способ создаать файл сразу заполнив его, через File.WriteAllText("C:/Users/Зия/Desktop/C#/uf.txt", "Privet iz proshlogo")
            File.Copy("C:/Users/Зия/Desktop/C#/uf.txt", "C:/Users/Зия/Desktop/study/uf.txt");// копируем файл
            File.Delete("C:/Users/Зия/Desktop/C#/uf.txt");// удаляем файл
        }

        public static void f2()// етод чтобы создать и переместить файл
        {
            Directory.CreateDirectory("C:/Users/Зия/Desktop/C#/XDXD");//создаем директорий
            Directory.Move("C:/Users/Зия/Desktop/C#/XDXD", "C:/Users/Зия/Desktop/study/XDXD");// перемещаем директорий
            //Directory.Delete("C:/Users/Зия/Desktop/C#/XDXD"); но мы не сможем его использовать после перемещения

        }
        static void Main(string[] args)
        { //вызываем методы
            f1();
            f2();
            Console.ReadKey();
        }
    }
}
