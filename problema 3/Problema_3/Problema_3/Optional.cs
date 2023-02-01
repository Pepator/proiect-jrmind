using problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_3
{
    public class Optional : IPattern
    {
        private IPattern pattern;
        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return new Match(true, pattern.Match(text).RemainingText());
        }
    }
}
