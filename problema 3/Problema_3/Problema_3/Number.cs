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
            var digits = new OneOrMore(new Range('0', '9'));

            var integer = new Sequence(new Optional(new Character('-')),
                                       new Choice(new Character('0'),
                                       digits));

            var fraction = new Optional(new Sequence(new Character('.'),
                                                     digits));

            var exponent = new Optional(new Sequence(new Any("eE"), 
                                                     new Optional(new Any("-+")), 
                                                     digits));

            pattern = new Sequence(integer, fraction, exponent); 

        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
