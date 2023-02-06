using problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
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
            if (string.IsNullOrEmpty(text) || !text.StartsWith(prefix))
            {
                return new Match(false, text);
            }
            else if (prefix.Length == 0)
            {
                return new Match(false, "");
            }

            return new Match(true, text[prefix.Length..]);
        }
    }
}
