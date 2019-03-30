using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace Anuar
{
    public class Shop
    {
        public string name;
        public string kupil;

        [XmlIgnore]
        public static string[] pro = { "pech", "sok", "kolbasa", "kofe" };


            public Shop()
        {

        }

        public static void Vyvod()
        {
            for (int i = 0; i < pro.Length; i++)
            {
                Console.WriteLine(pro[i]);
            }
        }

    }
    class Program
    {

        public static void SR(Shop shop)
        {
            FileStream fs = new FileStream(shop.name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sr = new XmlSerializer(typeof(Shop));
            sr.Serialize(fs, shop);
            fs.Close();
        }
        public static void DR(Shop shop)
        {
            FileStream fs = new FileStream(shop.name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer dr = new XmlSerializer(typeof(Shop));
            shop = dr.Deserialize(fs) as Shop;
            Console.WriteLine(shop);
            fs.Close();
        }
        static void Main(string[] args)
        {

            Shop shop = new Shop();
            Console.WriteLine("Hello! What is your name?");
            shop.name = Console.ReadLine();
            Console.Clear();
            Shop.Vyvod();
            int x = 0, y = 0;
            Console.SetCursorPosition(x, y);
            int indx = 0;
            ConsoleKeyInfo cf = new ConsoleKeyInfo();
            while (true)
            {
                cf = Console.ReadKey();

                if(cf.Key == ConsoleKey.Enter)
                {
                    shop.kupil = Shop.pro[indx]; 
                    SR(shop);
                    break;
                }
                if(cf.Key == ConsoleKey.DownArrow)
                {
                    indx++;
                    y++;
                    if(y > 3)
                    {
                        y = 0;
                        indx = 0;
                    }

                }
                if(cf.Key == ConsoleKey.UpArrow)
                {
                    indx--;
                    y--;
                    if(y < 0)
                    {
                        y = 3;
                        indx = 3;
                    }
                }
                Console.SetCursorPosition(x, y);
            }
            Console.Clear();
            DR(shop);
        }
    }
}
