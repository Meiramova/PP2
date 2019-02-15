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
            public DirectoryInfo papki = null;
            public FileSystemInfo faily = null;
            public string path;
            public bool proverka;
            public int cursor;
            public int razmer;

            public FarManager(string path)
            {
                cursor = 0;
                this.path = path;
            }

            public void Cvet(FileSystemInfo massive, int index)
            {

                if (cursor == index)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
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
                papki = new DirectoryInfo(path);
                FileSystemInfo[] faily = papki.GetFileSystemInfos();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                for (int i = 0, k = 0; i < faily.Length; i++)
                {
                    if (faily[i].Name[0] == '.')
                    {
                        continue;
                    }
                    Cvet(faily[i], k);
                    Console.WriteLine(k + 1 + ". " + faily[i].Name);
                    k++;
                }
            }
            public void Calc()
            {
                DirectoryInfo papki = new DirectoryInfo(path);
                FileSystemInfo[] faily = papki.GetFileSystemInfos();
                razmer = faily.Length;
                for (int i = 0; i < faily.Length; i++)
                {
                    if (faily[i].Name[0] == '.')
                    {
                        razmer--;
                    }
                }
            }

            public void vsevyshe()
            {
                cursor--;
                if (cursor < 0)
                {
                    cursor = razmer - 1;
                }
            }

            public void nizhenizhe()
            {
                cursor++;
                if (cursor == razmer)
                {
                    cursor = 0;
                }
            }
            public void nachinaiyopta()
            {
                ConsoleKeyInfo nazhimai;
                proverka = true;
                while (proverka)
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
                        if (faily.GetType() == typeof(DirectoryInfo))
                        {
                            cursor = 0;
                            path = faily.FullName;
                        }
                        else
                        {
                            StreamReader sr = new StreamReader(faily.FullName);
                            Console.WriteLine(sr.ReadToEnd());
                            sr.Close();
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    else if (nazhimai.Key == ConsoleKey.Escape)
                    {
                        if (papki.Parent.FullName != @"C:\")
                        {
                            path = papki.Parent.FullName;
                            cursor = 0;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You can not go out of the Disk");
                            Console.ReadKey();

                        }
                    }
                    else if (nazhimai.Key == ConsoleKey.Backspace)
                    {
                        if (faily.GetType() == typeof(DirectoryInfo))
                        {
                            cursor = 0;
                            Directory.Delete(faily.FullName);
                        }
                        else
                        {
                            cursor = 0;
                            File.Delete(faily.FullName);
                        }
                    }
                    else if (nazhimai.Key == ConsoleKey.Tab)
                    {
                        Console.Clear();
                        string nazovi = Console.ReadLine();
                        Console.Clear();
                        string novoe = Path.Combine(faily.FullName, nazovi);
                        if (faily.GetType() == typeof(DirectoryInfo))
                        {
                            Directory.Move(faily.FullName, novoe);
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
