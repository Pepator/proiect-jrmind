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
            Assert.Equal((true, "bc"), (match.Succes(), match.RemainingText()));
        }
        [Fact]
        public void Match_ValidateOptionalClass_ShouldRetrunTrueAndText()
        {
            var a = new Optional(new Character('a'));
            var match = a.Match("bc");
            Assert.Equal((true, "bc"), (match.Succes(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateOptionalClass_ShouldRetrunTrueAndEmptyForEmptyText()
        {
            var a = new Optional(new Character('a'));
            var match = a.Match("");
            Assert.Equal((true, ""), (match.Succes(), match.RemainingText()));
        }
        [Fact]
        public void Match_ValidateOptionalClass_ShouldRetrunTrueAndNullForNull()
        {
            var a = new Optional(new Character('a'));
            var match = a.Match(null);
            Assert.Equal((true, null), (match.Succes(), match.RemainingText()));
        }


    }
}
