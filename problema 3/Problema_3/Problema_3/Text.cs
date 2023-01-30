using problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_3
{
    public class Text : IPattern
    {
        private string prefix;
        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            string pref = prefix[0..prefix.Length];

            if (string.IsNullOrEmpty(text) || !text.Contains(pref))
            {
                return new Match(false, text);
            }

            return new Match(true, text[prefix.Length..]);
        }
    }
}
