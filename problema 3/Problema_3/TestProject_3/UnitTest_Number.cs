using Problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public class UnitTest_Number
    {
        [Fact]
        public void Match_ValidateNumberClass_ShouldRetrunEmptyStringForValidJsonNumber()
        {
            var a = new Number();
            var match = a.Match("-12.3e+2");
            Assert.Equal((true, ""), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateNumberClass_ShouldRetrunNumberFromZeroIfItStartsWithZero()
        {
            var a = new Number();
            var match = a.Match("-012.3e+2");
            Assert.Equal((true, "12.3e+2"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateNumberClass_ShouldRetrunEmptyStringForZero()
        {
            var a = new Number();
            var match = a.Match("0");
            Assert.Equal((true, ""), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateNumberClass_ShouldRetrunSecondExponentForTwoExponents()
        {
            var a = new Number();
            var match = a.Match("12.12e-12e-12");
            Assert.Equal("e-12", match.RemainingText());
        }

        [Fact]
        public void Match_ValidateNumberClass_ShouldRetrunIncompleteExponentForIncompleteExponent()
        {
            var a = new Number();
            var match = a.Match("12e-");
            Assert.Equal("e-", match.RemainingText());
        }

        [Fact]
        public void Match_ValidateNumberClass_ShouldRetrunFractionIfExponentIsBeforeFraction()
        {
            var a = new Number();
            var match = a.Match("12e2.2");
            Assert.Equal(".2", match.RemainingText());
        }
    }
}
