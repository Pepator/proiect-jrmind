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
        public void StreamWrite_ShouldWriteInMemoryStreamAsync()
        {
            string myText = "Hello World!";
            MemoryStream memoryStream = new MemoryStream();
            StreamClass.Write(memoryStream, myText);
            memoryStream = new MemoryStream(memoryStream.ToArray());
            memoryStream.Seek(0, SeekOrigin.Begin);

            string textFromStream = StreamClass.Read(memoryStream);

            Assert.Equal("Hello World!", textFromStream);
        }
    }
}