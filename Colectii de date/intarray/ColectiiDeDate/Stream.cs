using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using System.Reflection.PortableExecutable;

namespace ColectiiDeDate
{
    public class StreamClass : IStream
    {
        public void Write(Stream stream, string text)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Close();
        }

        public string Read(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            reader.Close(); 
            return text;
        }
    }
}
