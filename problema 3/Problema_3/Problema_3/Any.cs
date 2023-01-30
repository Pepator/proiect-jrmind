using problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_3
{
    public class Any : IPattern
    {
        private string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text) || !accepted.Contains(text[0]))
            {
                return new Match(false, text);
            }

            return new Match(true, text[1..]);
        }
    }
}
