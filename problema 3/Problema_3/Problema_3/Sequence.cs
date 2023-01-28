using problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_3
{
    public class Sequence : IPattern
    {
        private IPattern[] patterns;
        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string newText = text;

            foreach (var pattern in patterns)
            {
                IMatch newIMatch = pattern.Match(newText);

                if (!newIMatch.Succes())
                {
                    return new Match(false, text);
                }
                else
                {
                    newText = newIMatch.RemainingText();
                }
            }

            return new Match(true, newText);
        }
    }
}
