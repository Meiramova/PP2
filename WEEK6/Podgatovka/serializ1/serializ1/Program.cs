using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace serializ1
{
    public class ComplexNum
    {
        public string real;
        public string imag;
        
        public ComplexNum()
        {

        }

        public ComplexNum(string real, string imag)
        {
            this.real = real;
            this.imag = imag;
        }

        public override string ToString()
        {
            return "the real aprt is " + real + " " + "the imag part is " + imag;
        }

        
    }
    class Program
    {
        public static string real;
        public static string imag;
        public static void GetParts(string complex)
        {
            int i = 0;
            while (complex[i] != '+')
            {
                if (complex[i] >= '0' && complex[i] <= '9')
                {
                    real+= complex[i];
                }
                i++;
            }
            while(complex[i] != 'i')
            {
                if (complex[i] >= '0' && complex[i] <= '9')
                {
                    imag+= complex[i];
                }
                i++;
            }
        }

        public static void SR(ComplexNum cn, string Name)
        {
            FileStream fs = new FileStream(Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sr = new XmlSerializer(typeof(ComplexNum));
            sr.Serialize(fs, cn);
            fs.Close();
        }

        public static void DR(ComplexNum cn, string Name)
        {
            FileStream fs = new FileStream(Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer dr = new XmlSerializer(typeof(ComplexNum));
            cn = dr.Deserialize(fs) as ComplexNum;
            Console.WriteLine(cn);
            fs.Close();
        }
        static void Main(string[] args)
        {
            string complex = Console.ReadLine();
            string Name = Console.ReadLine();

            GetParts(complex);

            ComplexNum cn = new ComplexNum(real, imag);
            SR(cn, Name);
            DR(cn, Name);
        }
    }
}
