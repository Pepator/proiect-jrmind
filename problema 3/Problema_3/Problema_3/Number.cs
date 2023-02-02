using Problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            pattern = new Sequence(new Sequence(new Optional(new Character('-')), new Choice(new Character('0'), new OneOrMore(new Range('0', '9')))),
                                   new Optional(new Sequence(new Character('.'), new OneOrMore(new Range('0', '9')))),
                                   new Optional(new Sequence(new Any("eE"), new Optional(new Any("-+")), new OneOrMore(new Range('0', '9')))));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
