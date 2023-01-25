using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace problema_3
{
    public class Range : IPattern
    {
        private char start;
        private char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text) || !(text[0] >= start && text[0] <= end))
            {
                return new Match(false, text);
            }

            return new Match(true, text[1..]);
        }
    }
}
