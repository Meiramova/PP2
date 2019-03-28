using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Taask_1
{
    public class complexNum
    {
        public string imagine;
        public string real;

        public complexNum() { };

        public complexNum(string imagine, string real)
        {
            this.imagine = imagine;
            this.real = real;
        }

        public override string ToString()
        {
            return "Real part is " + real + " the imagine part is " + imagine;
        }
    }
    class Program
    {
        public static string realN;
        public static string imagN;

        public static void Getparts(string complex)
        {
            int i = 0;
            while(complex[i] != '+')
            {
                if (complex[i] >= '0' && complex[i] <= '9')
                {
                    realN += complex[i];
                }
                i++;
            }

            while(complex[i] != 'i'){
                if(complex[i] >= '0' && complex[i]<= '9')
                {
                    imagN += complex[i];
                }
                i++;
            } 
        }

        public static void SR(complexNum cn, string Name)
        {
            FileStream fs = new FileStream(Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(complexNum));
            xs.Serialize(fs, cn);
            fs.Close();
        }

        public static void DR(complexNum cn, string Name)
        {
            FileStream fs = new FileStream(Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer ds = new XmlSerializer(typeof(complexNum));
            cn = ds.Deserialize(fs) as complexNum;
            Console.WriteLine(cn);
            fs.Close();
        }
        static void Main(string[] args)
        {
            string complex = Console.ReadLine();
            string Name = Console.ReadLine();
            Getparts(complex);

            complexNum cn = new complexNum(realN, imagN);

            SR(cn, Name);
            DR(cn, Name);
            Console.ReadKey();
        }
    }
}
