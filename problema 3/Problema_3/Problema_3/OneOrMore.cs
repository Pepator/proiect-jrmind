using problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_3
{
    public class OneOrMore : IPattern
    {
        private readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            // aici folosește-te de clasele implementate deja
            // pentru a construi un pattern care să îl folosești în Match
            this.pattern = ...;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
