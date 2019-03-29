using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace serializ2
{
    public class Mark
    {
        public int points;
        public string LetterMarks;

        public Mark() { }
        public Mark(int points)
        {
            this.points = points;
            LetterMarks = GetMark();
        }

        public string GetMark()
        {
            if (points > 100 || points < 0)
                return "Error! Does not exist!";
            if (points >= 95 && points <= 100)
                return "Your mark is A c:";
            if (points >= 90 && points < 95)
                return "Your mark is A- c:";
            if (points >= 85 && points < 90)
                return "Your mark is B+ c:";
            if (points >= 80 && points < 85)
                return "Your mark is B c:";
            if (points >= 75 && points < 80)
                return "Your mark is B- c:";
            if (points >= 70 && points < 75)
                return "Your mark is C+ c:";
            if (points >= 65 && points < 70)
                return "Your mark is C c:";
            if (points >= 60 && points < 65)
                return "Your mark is C- c:";
            else
                return "your mark is F";
        }

        public override string ToString()
        {
            return GetMark();
        }
    }
    class Program
    {
        public static void SR(List<Mark> marks, string Name)
        {
            FileStream fs = new FileStream(Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sr = new XmlSerializer(typeof(List<Mark>));
            sr.Serialize(fs, marks);
            fs.Close();

        }

        public static void DR( List<Mark> marks, string Name)
        {
            FileStream fs = new FileStream(Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer dr = new XmlSerializer(typeof(List<Mark>));
            marks = dr.Deserialize(fs) as List<Mark>;
            Console.WriteLine(marks);
            fs.Close();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("how many marks do you want to check?");
            int n = Convert.ToInt32(Console.ReadLine());

            List<Mark> marks = new List<Mark>();

            for(int i = 0; i < n; i++)
            {
                Mark mark = new Mark(int.Parse(Console.ReadLine()));
                marks.Add(mark);
                Console.WriteLine(mark);
            }

            string Name = Console.ReadLine();

            SR(marks, Name);
            DR(marks, Name);
        }
    }
}
