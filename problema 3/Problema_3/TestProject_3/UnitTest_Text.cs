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
            Assert.Equal((true, "x"), (match.Succes(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunfalseAndTextIfPrefixDoesNotMatch()
        {
            var b = new Text("true");
            var match = b.Match("false");
            Assert.Equal((false, "false"), (match.Succes(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunTrueAndTextForEmptyPrefix()
        {
            var b = new Text("");
            var match = b.Match("true");
            Assert.Equal((true, "true"), (match.Succes(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateTextClass_ShouldRetrunfalseAndNull()
        {
            var b = new Text("");
            var match = b.Match(null);
            Assert.Equal((false, null), (match.Succes(), match.RemainingText()));
        }

    }
}
