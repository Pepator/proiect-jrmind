using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
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
        public void StreamWriteAndRead_GZipFalseEncryptFalse()
        {
            string myText = "Hello World!";
            MemoryStream memoryStream = new MemoryStream();
            StreamClass streamObj = new StreamClass();
            streamObj.Write(memoryStream, myText);
            memoryStream = new MemoryStream(memoryStream.ToArray());
            memoryStream.Seek(0, SeekOrigin.Begin);

            string textFromStream = streamObj.Read(memoryStream);

            Assert.Equal("Hello World!", textFromStream);
        }

        [Fact]
        public void StreamWriteAndRead_GZipTrueEncryptTrue()
        {
            string myText = "Hello World!";
            MemoryStream memoryStream = new MemoryStream();
            StreamClass streamObj = new StreamClass();
            streamObj.Write(memoryStream, myText, true, true);
            memoryStream = new MemoryStream(memoryStream.ToArray());
            memoryStream.Seek(0, SeekOrigin.Begin);

            string textFromStream = streamObj.Read(memoryStream, true, true);

            Assert.Equal("Hello World!", textFromStream);
        }

        [Fact]
        public void StreamWriteAndRead_GZipFalseEncryptTrue()
        {
            string myText = "Hello World!";
            MemoryStream memoryStream = new MemoryStream();
            StreamClass streamObj = new StreamClass();
            streamObj.Write(memoryStream, myText, true, false);
            memoryStream = new MemoryStream(memoryStream.ToArray());
            memoryStream.Seek(0, SeekOrigin.Begin);

            string textFromStream = streamObj.Read(memoryStream, true, false);

            Assert.Equal("Hello World!", textFromStream);
        }

        [Fact]
        public void StreamWriteAndRead_GZipTrueEncryptFalse()
        {
            string myText = "Hello World!";
            MemoryStream memoryStream = new MemoryStream();
            StreamClass streamObj = new StreamClass();
            streamObj.Write(memoryStream, myText, false, true);
            memoryStream = new MemoryStream(memoryStream.ToArray());
            memoryStream.Seek(0, SeekOrigin.Begin);

            string textFromStream = streamObj.Read(memoryStream, false, true);

            Assert.Equal("Hello World!", textFromStream);
        }
    }
}