using Problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace problema_3
{
    public class UnitTest_Any
    {
        [Fact]
        public void Match_ValidateAnyClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var e = new Problema_3.Any("eE");
            var match = e.Match("ea");
            Assert.Equal((true, "a"), (match.Succes(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateAnyClass_ShouldRetrunFalseAndText()
        {
            var e = new Problema_3.Any("eE");
            var match = e.Match("aa");
            Assert.Equal((false, "aa"), (match.Succes(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateAnyClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMetForSignCharacters()
        {
            var sign = new Problema_3.Any("-+");
            var match = sign.Match("+aa");
            Assert.Equal((true, "aa"), (match.Succes(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateAnyClass_ShouldRetrunfalseAndNull()
        {
            var sign = new Problema_3.Any("-+");
            var match = sign.Match(null);
            Assert.Equal((false, null), (match.Succes(), match.RemainingText()));
        }


    }
}
