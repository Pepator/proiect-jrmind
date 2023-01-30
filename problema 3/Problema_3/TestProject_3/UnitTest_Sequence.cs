using Problema_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public class UnitTest_Sequence
    {
        [Fact]
        public void Match_ValidateSequenceClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var match = ab.Match("abcd");
            Assert.Equal((true, "cd"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateSequenceClass_ShouldRetrunfalseAndTextIfConditionsAreNotMet()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var match = ab.Match("axcd");
            Assert.Equal((false, "axcd"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateSequenceClass_ShouldRetrunfalseAndTextForEmptyString()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var match = ab.Match("");
            Assert.Equal((false, ""), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateSequenceClass_ShouldRetrunfalseAndTextFornull()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var match = ab.Match(null);
            Assert.Equal((false, null), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateComplexSequenceClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var abc = new Sequence(ab, new Character('c'));
            var match = abc.Match("abcd");
            Assert.Equal((true, "d"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateComplexHexaSequenceClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));
            var match = hexSeq.Match("u1234");
            Assert.Equal((true, ""), (match.Success(), match.RemainingText()));
        }
    }
}
