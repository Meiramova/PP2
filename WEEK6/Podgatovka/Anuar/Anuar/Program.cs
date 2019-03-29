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
    class Program
    {
        public class Shop
        {
            public string name;
            List<string> products;

            public Shop()
            {
                
            }

            public static void SR(Shop shop, string name)
            {
                FileStream fs = new FileStream(name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer sr = new XmlSerializer(typeof(Shop));
                sr.Serialize(fs, shop);
                fs.Close();
            }
            public static void DR(string name)
            {
                FileStream fs = new FileStream(name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer dr = new XmlSerializer(typeof(Shop));
                Shop shop = dr.Deserialize(fs) as Shop;
                Console.WriteLine(shop);
                fs.Close();
            }
        }
        static void Main(string[] args)
        {
            
            Shop shop = new Shop();
            shop.name = Console.ReadLine();

            for(int i = 0; i < )
        }
       

    }
}
