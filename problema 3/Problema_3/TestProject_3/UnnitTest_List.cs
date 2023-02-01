using problema_3;
using Problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public class UnnitTest_List
    {
        [Fact]
        public void Match_ValidateListClass_ShouldRetrunTrueAndEmptyStringIfAllConditionsAreMet()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            var match = a.Match("1,2,3");
            Assert.Equal((true, ""), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateListClass_ShouldRetrunTrueAndSeparator()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            var match = a.Match("1,2,3,");
            Assert.Equal((true, ","), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateListClass_ShouldRetrunTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            var match = a.Match("1a");
            Assert.Equal((true, "a"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateListClass_ShouldRetrunTrueAndText()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            var match = a.Match("abc");
            Assert.Equal((true, "abc"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateListClass_ShouldRetrunTrueAndEmptyStringIfAllConditionsAreMetForComplexList()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            var match = list.Match("1; 22  ;\n 333 \t; 22");
            Assert.Equal((true, ""), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateListClass_ShouldRetrunTrueAndAllSeparatorsForOnlyOneElement()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            var match = list.Match("1 \n;");
            Assert.Equal((true, " \n;"), (match.Success(), match.RemainingText()));
        }
    }
}
