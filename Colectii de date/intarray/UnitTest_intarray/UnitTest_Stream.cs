using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class UnitTest_Stream
    {
        [Fact]
        public void StreamWrite_ShouldWriteinTextFile()
        {
            string myText = "Hello World!";
            string filePath = "Text.txt";

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);

            StreamClass.Write(fs, myText);

            string textFromFile = File.ReadAllText("Text.txt");
            Assert.Equal("Hello World!", textFromFile);
        }

        [Fact]
        public void StreamRead_ShouldWriteAndReadFromTextFile()
        {
            string filePath = "Text.txt";

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);

            string textFromFile = StreamClass.Read(fs);

            Assert.Equal("Hello World!", textFromFile);
        }
    }
}
