using Problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public class UnitTest_Optional
    {
        [Fact]
        public void Match_ValidateOptionalClass_ShouldRetrunTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));
            var match = a.Match("abc");
            Assert.Equal((true, "bc"), (match.Success(), match.RemainingText()));
        }
        [Fact]
        public void Match_ValidateOptionalClass_ShouldRetrunTrueAndText()
        {
            var a = new Optional(new Character('a'));
            var match = a.Match("bc");
            Assert.Equal((true, "bc"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateOptionalClass_ShouldRetrunTrueAndEmptyForEmptyText()
        {
            var a = new Optional(new Character('a'));
            var match = a.Match("");
            Assert.Equal((true, ""), (match.Success(), match.RemainingText()));
        }
        [Fact]
        public void Match_ValidateOptionalClass_ShouldRetrunTrueAndNullForNull()
        {
            var a = new Optional(new Character('a'));
            var match = a.Match(null);
            Assert.Equal((true, null), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void asdMatch_ValidateOptionalClass_ShouldRetrunTrueAndRemainingText()
        {
            var sign = new Optional(new Character('-'));
            var match = sign.Match("123");
            Assert.Equal((true, "123"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void adMatch_ValidateOptionalClass_ShouldRetrunTrueAndRemainingText()
        {
            var sign = new Optional(new Character('-'));
            var match = sign.Match("-123");
            Assert.Equal((true, "123"), (match.Success(), match.RemainingText()));
        }
    }
}
