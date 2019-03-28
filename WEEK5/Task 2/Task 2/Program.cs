using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task_2
{
    public class Mark
    {
        public int points;
        public string LetterM;

        public Mark() { }

        public Mark(int points, string LetterM)
        {
            this.points = points;
            this.LetterM = LetterM;
        }

        public string GetLetter()
        {
            if(points > 100 || points < 0)
            {
                return "Error! does not exist";
            }
            if(points>= 95 && points<= 100)
            {
                return "your mark is A";
            }
            if (points >= 90 && points < 95)
            {
                return "your mark is A-";
            }
            if (points >= 85 && points < 90)
            {
                return "your mark is B+";
            }
            if (points > 80 && points < 85)
            {
                return "your mark is B";
            }
            if (points >= 75 && points < 80)
            {
                return "your mark is B-";
            }
            if (points >= 70 && points < 75)
            {
                return "your mark is C+";
            }
            if (points >= 65 && points < 70)
            {
                return "your mark is C";
            }
            if (points >= 65 && points < 65)
            {
                return "your mark is C-";
            }
            else
            {
                return "your mark is F";
            }
        }
        public override string ToString()
        {
            return GetLetter();
        }
    }
    class Program
    {
        public static void SR(List<Mark> ms, string name)
        {
            FileStream fs = new FileStream(name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sr = new XmlSerializer(typeof(List<Mark>));
            sr.Serialize(fs, ms);
            fs.Close();
        }
        public static void DR(List<Mark> ms, string name)
        {
            FileStream fs = new FileStream(name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sr = new XmlSerializer(typeof(List<Mark>));
            ms = sr.Deserialize(fs) as List<Mark>;
            fs.Close();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("How many marks do you want?");
            int n = Convert.ToInt32(Console.ReadLine());
            List<Mark> ms = new List<Mark>();

            for (int i = 0; i < n; i++)
            {
                Mark mss = new Mark(int.Parse(Console.ReadLine()));
                ms.Add(mss);
            }
            string name = Console.ReadLine();
            SR(mss, name);
            DR(mss, name);
            Console.ReadKey();
        }
    }
}
