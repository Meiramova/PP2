﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        class Student
        {
            public string name;
            public string id;
            public int year = 0;

            public Student(string name, string id)
            {
                this.name = name;
                this.id = id;
            }

            public void Print()
            {
                Console.WriteLine("Name of student is " + name);
                Console.WriteLine("Student's id " + id);
            }
            
            public void Print2()
            {
                year++;
                Console.WriteLine("Student's increased year is " + year);
            }
        }
        static void Main(string[] args)
        {
            Student n1 = new Student("Ziya", "18BD113336");
            n1.Print();
            n1.Print2();
            Console.ReadKey();
        } 
    }
}
