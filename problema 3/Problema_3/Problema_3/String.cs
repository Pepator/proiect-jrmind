using Problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var hex = new Choice(new Range('0', '9'),
                                 new Range('a', 'f'),
                                 new Range('A', 'F'));

            var escape = new Choice(new Any("bfnrt\\\"/"),
                                    new Sequence(new Character('u'), hex, hex, hex, hex));

            var character = new Many(new Choice(new Range(' ', '\u0021'),
                                       new Range('\u0023', '\u005B'),
                                       new Range('\u005D', '\uFFFF'),
                                       new Sequence(new Character('\\'), escape)));

            pattern = new Sequence(new Character('"'), character, new Character('"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
