using problema_3;
using Problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var whiteSpace = new Many(new Any(" \n\r\t"));

            var value = new Choice(new Number(),
                                   new String(),
                                   new Text("true"),
                                   new Text("false"),
                                   new Text("null"));

            var element = new Sequence(whiteSpace, value, whiteSpace);

            var array = new Sequence(new Character('['),
                                     whiteSpace,
                                     new List(element, new Character(',')),
                                     whiteSpace,
                                     new Character(']'));
             
            var member = new Sequence(whiteSpace,
                                      new String(),
                                      whiteSpace,
                                      new Character(':'),
                                      element);

            var Object = new Sequence(new Character('{'),
                                      whiteSpace,
                                      new List(member, new Character(',')),
                                      whiteSpace,
                                      new Character('}'));

            value.Add(array);
            value.Add(Object);

            pattern = element;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
