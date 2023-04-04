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
        public void StreamWrite_ShouldWriteInMemoryStream()
        {
            string myText = "Hello World!";

            MemoryStream memoryStream = new MemoryStream();

            StreamClass.Write(memoryStream, myText);
            memoryStream = new MemoryStream(memoryStream.ToArray());

            memoryStream.Seek(0, SeekOrigin.Begin);
            byte[] bytesFromFile = new byte[myText.Length];
            memoryStream.Read(bytesFromFile, 0, bytesFromFile.Length);
            string textFromFile = Encoding.UTF8.GetString(bytesFromFile);
            Assert.Equal("Hello World!", textFromFile);
        }

        [Fact]
        public void StreamRead_ShouldReadFromMemoryStream()
        {
            string myText = "Hello World!";
            byte[] byteText = Encoding.UTF8.GetBytes(myText);

            MemoryStream memoryStream = new MemoryStream(byteText);

            string textFromFile = StreamClass.Read(memoryStream);
            Assert.Equal("Hello World!", textFromFile);
        }
    }
}
