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
            var white = new Many(new Any(" \n\r\t"));

            var value = new Choice(new Number(),
                                   new String(),
                                   new Text("true"),
                                   new Text("false"),
                                   new Text("null"));

            var element = new Sequence(white, value, white);

            var array = new Sequence(new Character('['),
                        white,
                        new List(element, new Character(',')),
                        white,
                        new Character(']'));

            var member = new Sequence(white,
                                      new String(),
                                      white,
                                      new Character(':'),
                                      element);

            var Object = new Sequence(new Character('{'),
                                      white,
                                      new List(member, new Character(',')),
                                      white,
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
