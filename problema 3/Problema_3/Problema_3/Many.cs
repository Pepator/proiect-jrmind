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

            while (pattern.Match(newText).Succes())
            {
                newText = pattern.Match(newText).RemainingText();
            }

            return new Match(true, newText);

        }
    }
}
