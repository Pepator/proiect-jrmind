using System.Text.RegularExpressions;

namespace problema_3
{
    public class UnitTest_Choice
    {
        [Fact]
        public void Match_ValidateChoiceClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var digit = new Choice(new Character('0'), new Range('0', '9'));
            var match = digit.Match("01234");
            Assert.Equal((true, "1234"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateChoiceClass_ShouldRetrunFalseAndTextForEmptyString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var match = digit.Match("");
            Assert.Equal((false, ""), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateChoiceClass_ShouldRetrunFalseAndTextForNull()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var match = digit.Match(null);
            Assert.Equal((false, null), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateComplexChoiceClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            var match = hex.Match("01234");
            Assert.Equal((true, "1234"), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateComplexChoiceClass_ShouldRetrunFalseAndTextForEmpltyString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            var match = hex.Match("");
            Assert.Equal((false, ""), (match.Success(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateComplexChoiceClass_ShouldRetrunFalseAndTextForNull()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            var match = hex.Match(null);
            Assert.Equal((false, null), (match.Success(), match.RemainingText()));
        }
    }
}
