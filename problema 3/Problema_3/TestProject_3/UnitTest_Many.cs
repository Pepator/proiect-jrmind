using problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_3
{
    public class UnitTest_Many
    {
        [Fact]
        public void Match_ValidateManyClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var a = new Many(new Character('a'));
            var match = a.Match("aaaabc");
            Assert.Equal((true, "bc"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunTrueAndTextIfConditionsAreNotMet()
        {
            var a = new Many(new Character('a'));
            var match = a.Match("bc");
            Assert.Equal((true, "bc"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunTrueAndEmptyStringForEmptyText()
        {
            var a = new Many(new Character('a'));
            var match = a.Match("");
            Assert.Equal((true, ""), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunTrueAndRemainingText()
        {
            var digits = new Many(new problema_3.Range('0', '9'));
            var match = digits.Match("12345ab123");
            Assert.Equal((true, "ab123"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunTrueAndTextIfRangeIsNotFound()
        {
            var digits = new Many(new problema_3.Range('0', '9'));
            var match = digits.Match("ab");
            Assert.Equal((true, "ab"), (match.Success(), match.RemainingText()));
        }
    }
}
