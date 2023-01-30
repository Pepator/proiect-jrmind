using problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_3
{
    public class UnitTest_OneOrMore
    {
        [Fact]
        public void Match_ValidateOneOrMoreClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var a = new OneOrMore(new problema_3.Range('0', '9'));
            var match = a.Match("123");
            Assert.Equal((true, ""), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateOneOrMoreClass_ShouldRetrunTrueAndRemainingText()
        {
            var a = new OneOrMore(new problema_3.Range('0', '9'));
            var match = a.Match("1a");
            Assert.Equal((true, "a"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateOneOrMoreClass_ShouldRetrunFalseAndText()
        {
            var a = new OneOrMore(new problema_3.Range('0', '9'));
            var match = a.Match("a123");
            Assert.Equal((false, "a123"), (match.Success(), match.RemainingText()));
        }
    }
}
