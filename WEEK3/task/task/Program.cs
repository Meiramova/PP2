using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp4
{
    class Program
    {
        class FarManager
        {
            public DirectoryInfo papki = null;// создаю переменные
            public FileSystemInfo faily = null;
            public string path;
            public bool proverka;
            public int cursor;
            public int razmer;

            public FarManager(string path)//конструктор
            {
                cursor = 0;
                this.path = path;
            }

            public void Cvet(FileSystemInfo massive, int index)
            {
                // меняю цвета
                if (cursor == index)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    faily = massive;
                }
                else if (massive.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }

            }
            public void Pokazhi()
            {
                papki = new DirectoryInfo(path); // папки
                FileSystemInfo[] faily = papki.GetFileSystemInfos();//массив с файлами и папками
                Console.BackgroundColor = ConsoleColor.DarkRed;// перекрашиваю общ фон 
                Console.Clear();// меняю каартинку

                /*for (int i = 0, k = 0; i < faily.Length; i++)
                {
                    if (faily[i].Name[0] == '.')
                    {
                        continue;// скрытые файлы игнорирует
                    }
                    Cvet(faily[i], k);// вызываю функц цвета
                   
                    Console.WriteLine(k + 1 + ". " + faily[i].Name);// выводит названия и счет
                    
                    k++;
                }
                */
                var folders = papki.GetDirectories();
                var file = papki.GetFiles();

                int j = 0;
                foreach(var u in folders)
                {
                    if (u.Name.StartsWith("."))
                    {
                        continue;
                    }
                    Cvet(u, j);
                    j++;
                    Console.WriteLine(j + ". " + u.Name);
                }
                int ups = j;
                foreach(var l in file)
                {
                    if (l.Name.StartsWith("."))
                    {
                        continue;
                    }
                    Cvet(l, ups);
                    ups++;
                    Console.WriteLine(ups + ". " + l.Name);
                }
               
            }
            public void Calc()
            {
                DirectoryInfo papki = new DirectoryInfo(path);// папки
                FileSystemInfo[] faily = papki.GetFileSystemInfos();// массив всего 
                razmer = faily.Length;//размерность присваиваем
                for (int i = 0; i < faily.Length; i++)
                {
                    if (faily[i].Name[0] == '.')
                    {
                        razmer--;// изменяем размерность 
                    }
                }
            }

            public void vsevyshe() //пробегаемся курсором вверх
            {
                cursor--;
                if (cursor < 0)
                {
                    cursor = razmer - 1;
                }
            }

            public void nizhenizhe()//вниз
            {
                cursor++;
                if (cursor == razmer)
                {
                    cursor = 0;
                }
            }
            public void nachinaiyopta()
            {
                ConsoleKeyInfo nazhimai;// подкл кнопку
                proverka = true;// чтобы программа закрывалась при нажатии пробела
                while (proverka)// по кнопкам
                {
                    Calc();
                    Pokazhi();
                    nazhimai = Console.ReadKey();
                    if (nazhimai.Key == ConsoleKey.DownArrow)
                    {
                        nizhenizhe();
                    }
                    else if (nazhimai.Key == ConsoleKey.UpArrow)
                    {
                        vsevyshe();
                    }
                    else if (nazhimai.Key == ConsoleKey.Spacebar)
                    {
                        proverka = false;
                    }
                    else if (nazhimai.Key == ConsoleKey.Enter)
                    {
                        if (faily.GetType() == typeof(DirectoryInfo))//если папка, то при нажатии интер откроется
                        {
                            cursor = 0;
                            path = faily.FullName;
                        }
                        else
                        {
                            StreamReader sr = new StreamReader(faily.FullName);//пусть покажет содержимое если это файл
                            Console.WriteLine(sr.ReadToEnd());
                            sr.Close();
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    else if (nazhimai.Key == ConsoleKey.Escape)
                    {
                        if (papki.Parent.FullName != @"C:\")//пока до канца не дойдет может выходить при искейп
                        {
                            path = papki.Parent.FullName;
                            cursor = 0;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You can not go out of the Disk");//иначе выйдет такое предложение
                            Console.ReadKey();

                        }
                    }
                    else if (nazhimai.Key == ConsoleKey.Backspace)
                    {
                        if (faily.GetType() == typeof(DirectoryInfo))//если папка то удаляем ее и все содержимое
                        {
                            cursor = 0;
                            Directory.Delete(faily.FullName);
                        }
                        else
                        {
                            cursor = 0;
                            File.Delete(faily.FullName);//если папка то удаляем
                        }
                    }
                    else if (nazhimai.Key == ConsoleKey.Tab)//кнопка для переименования папки или файла
                    {
                        Console.Clear();
                        string nazovi = Console.ReadLine();//новое название
                        Console.Clear();
                        string novoe = Path.Combine(papki.FullName, nazovi);//новый путь к переименованному файлу или папки
                        if (faily.GetType() == typeof(DirectoryInfo))
                        {
                            Directory.Move(faily.FullName, novoe);//перенести
                        }
                        else
                        {
                            File.Move(faily.FullName, novoe);
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\Зия\Desktop\study";
            FarManager FarManager = new FarManager(path);
            FarManager.nachinaiyopta();

        }
    }
}
