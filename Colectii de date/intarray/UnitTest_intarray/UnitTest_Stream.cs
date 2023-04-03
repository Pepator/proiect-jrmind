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
        public void Stream_ShouldWriteAndReadFromTextFile()
        {
            Stream.Write("Hello World!");
            Stream.Read(@"D:\github\Colectii de date\intarray\ColectiiDeDate\Text.txt");
            string textFromFile = File.ReadAllText(@"D:\github\Colectii de date\intarray\ColectiiDeDate\Text.txt");
            Assert.Equal("Hello World!", textFromFile);
        }
    }
}
