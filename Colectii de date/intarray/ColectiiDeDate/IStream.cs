using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public interface IStream
    {
        public void Write(Stream stream, string text);

        public string Read(Stream stream);
    }
}
