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
            string newText = text;
            IMatch newIMatch = pattern.Match(newText);

            if (!newIMatch.Success())
            {
                return new Match(true, text);
            }
            else
            {
                newText= newIMatch.RemainingText();
            }

            return new Match(true, newText);
        }
    }
}
