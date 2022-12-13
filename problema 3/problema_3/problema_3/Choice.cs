using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public class Choice : IPattern
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Match(string text)
        {
            for (int i = 0; i < patterns.Length; i++)
            {
                if (patterns[i].Match(text) == true)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
