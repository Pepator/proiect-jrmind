using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class Stream
    {
        public static void Write(string text)
        {
            StreamWriter writer = new StreamWriter(@"D:\github\Colectii de date\intarray\ColectiiDeDate\Text.txt");
            writer.Write(text);
            writer.Close();
        }

        public static void Read(string path)
        {
            StreamReader reader = new StreamReader(path);
            reader.ReadToEnd();
            reader.Close();
        }
    }
}
