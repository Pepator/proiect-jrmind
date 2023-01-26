using System.Text.RegularExpressions;

namespace problema_3
{
    public class UnitTest_Choice
    {
        [Fact]
        public void Match_ValidateChoiceClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.Equal((true, "1234"), (digit.Match("01234").Succes(), digit.Match("01234").RemainingText()));
        }

        [Fact]
        public void Match_ValidateChoiceClass_ShouldRetrunFalseAndTextForEmptyString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.Equal((false, ""), (digit.Match("").Succes(), digit.Match("").RemainingText()));
        }

        [Fact]
        public void Match_ValidateChoiceClass_ShouldRetrunFalseAndTextForNull()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.Equal((false, null), (digit.Match(null).Succes(), digit.Match(null).RemainingText()));
        }

        [Fact]
        public void Match_ValidateComplexChoiceClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.Equal((true, "1234"), (hex.Match("01234").Succes(), hex.Match("01234").RemainingText()));
        }

        [Fact]
        public void Match_ValidateComplexChoiceClass_ShouldRetrunFalseAndTextForEmpltyString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.Equal((false, ""), (hex.Match("").Succes(), hex.Match("").RemainingText()));
        }

        [Fact]
        public void Match_ValidateComplexChoiceClass_ShouldRetrunFalseAndTextForNull()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.Equal((false, null), (hex.Match(null).Succes(), hex.Match(null).RemainingText()));
        }
    }
}
