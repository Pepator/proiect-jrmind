using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class StreamClass
    {
        public static void Write(Stream stream, string text)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Close();
        }

        public static string Read(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            reader.Close();
            return text;
        }
    }
}
