using problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_3
{
    public class Many : IPattern
    {
        private IPattern pattern;
        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            string newText = text;
            IMatch newIMatch = pattern.Match(text);

            while (newIMatch.Success())
            {
                newText = newIMatch.RemainingText();
                newIMatch = pattern.Match(newText);
            }

            return new Match(true, newText);
        }
    }
}
