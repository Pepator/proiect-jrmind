using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Problema_3
{
    public class UnitTest_Text
    {
        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var b = new Text("true");
            var match = b.Match("truex");
            Assert.Equal((true, "x"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunfalseAndTextIfPrefixDoesNotMatch()
        {
            var b = new Text("true");
            var match = b.Match("false");
            Assert.Equal((false, "false"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunTrueAndTextForEmptyPrefix()
        {
            var b = new Text("");
            var match = b.Match("true");
            Assert.Equal((false, ""), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunfalseAndNull()
        {
            var b = new Text("");
            var match = b.Match(null);
            Assert.Equal((false, null), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunfalseAndText()
        {
            var b = new Text("true");
            var match = b.Match("xtruex");
            Assert.Equal((false, "xtruex"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunfalseAndTextIfPrefixHasMoreCharacters()
        {
            var b = new Text("truexx");
            var match = b.Match("truex");
            Assert.Equal((false, "truex"), (match.Success(), match.RemainingText()));
        }

    }
}
