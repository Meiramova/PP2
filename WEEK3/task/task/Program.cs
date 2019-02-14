using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1
{
    class FarManager
    {
        public int cursor;
        public int size;
        bool ok;
        public string path;
        DirectoryInfo directory; // null
        FileInfo files = null;
        public FarManager()
        {
            cursor = 0;
            ok = true;
        }

        public FarManager(string path)
        {
            this.path = path;
            cursor = 0;
            this.directory = new DirectoryInfo(path);
            size = directory.GetFileSystemInfos().Length;
            ok = true;
        }


        public void UP()
        {
            cursor--;
            if (cursor < 0)
            {
                cursor = size - 1;
            }
        }

        public void DOWN()
        {
            cursor++;
            if (cursor == size)
            {
                cursor = 0;
            }
        }


        public void Color(FileSystemInfo fs, int i)
        {
            if (i == cursor)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
        }

        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            size = fs.Length;
            for (int i = 0, k = 0; i < fs.Length; i++)
            {
                if (ok == false && fs[i].Name[0] == '.')
                {
                    continue;
                }
                Color(fs[i], k);
                Console.WriteLine(fs[i].Name);
                k++;
            }

        }
        public void Calcsize()
        {
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            size = fs.Length;
            if (!ok)
            {
                for (int i = 0; i < fs.Length; i++)
                {
                    if (fs[i].Name[0] == '.')
                    {
                        size--;
                    }
                }
            }
        }

        public void Init()
        {
            ConsoleKeyInfo conkey = Console.ReadKey();
            while (conkey.Key != ConsoleKey.Escape)
            {
                Calcsize();
                Show();
                conkey = Console.ReadKey();
                if (conkey.Key == ConsoleKey.UpArrow)
                {
                    UP();
                }
                if (conkey.Key == ConsoleKey.DownArrow)
                {
                    DOWN();
                }
                if (conkey.Key == ConsoleKey.RightArrow)
                {
                    ok = false;
                    cursor = 0;
                }
                if (conkey.Key == ConsoleKey.LeftArrow)
                {
                    cursor = 0;
                    ok = true;
                }
                if (conkey.Key == ConsoleKey.Enter)
                {
                    if (files.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        path = files.FullName;
                    }
                }
                if (conkey.Key == ConsoleKey.Backspace)
                {
                    cursor = 0;
                    path = directory.Parent.Name;
                }
            }

        }

        class Program
        {

            static void Main(string[] args)
            {
                string path = "C:/Users/Зия/Desktop/PP2";
                FarManager farManager = new FarManager(path);
                farManager.Init();
            }
        }
    }
}
