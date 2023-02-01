using Problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            this.pattern = new Optional(new OneOrMore(new Sequence(new Optional(separator), element)));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
