using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        class Student // создаю класс
        {
            public string name;// задаю ему свои переменные
            public string id;
            public int year = 0;

            public Student(string name, string id)
            {
                this.name = name; // создаю конструктор
                this.id = id;
            }

            public void Print()
            {
                Console.WriteLine("Name of student is " + name); // создаю функцию для вывода
                Console.WriteLine("Student's id " + id);
            }

            public void Print2()
            {
                ++year; // создала инкремент(увеличивается)
                Console.WriteLine("Student's increased year is " + year); // функция вывода 2 
            }
        }
        static void Main(string[] args)
        {
            string s = Console.ReadLine(); // считываю строку
            string[] str = s.Split(); // разделяю его на пробелы
            Student n1 = new Student(str[0], str[1]); // первые 2 элемента и есть имя и id
            n1.year = int.Parse(str[2]); // перевожу со стринга на инт через функцию парс
            n1.Print();// вызываю функцию вывода
            n1.Print2();//вызываю функцию вывода 2
            Console.ReadKey();// чтобы терминал не закрывался
        }
    }
}
