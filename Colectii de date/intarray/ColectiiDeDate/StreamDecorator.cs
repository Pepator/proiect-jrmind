using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class StreamDecorator : IStream
    {
        private IStream _stream;

        public StreamDecorator(IStream stream) 
        {
            _stream = stream;
        }
 
        public virtual void Write(Stream stream, string text)
        {
            _stream.Write(stream, text);
        }
        public virtual string Read(Stream stream)
        {
           return _stream.Read(stream);
        }
    }
}
