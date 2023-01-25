using System.Text.RegularExpressions;

namespace problema_3
{
    public class UnitTest_Choice
    {
        [Fact]
        public void Match_ValidateChoiceClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.Equal(digit.Match("01234"), new Match(true, "1234"));
        }

        [Fact]
        public void Match_ValidateChoiceClass_ShouldRetrunFalseAndTextForEmptyString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.Equal(digit.Match(""), new Match(false, ""));
        }

        [Fact]
        public void Match_ValidateChoiceClass_ShouldRetrunFalseAndTextForNull()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.Equal(digit.Match(null), new Match(false, null));
        }

        [Fact]
        public void Match_ValidateComplexChoiceClass_ShouldRetrunTrueAndRemainingTextIfConditionsAreMet()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.Equal(digit.Match("01234"), new Match(true, "1234"));
        }

        [Fact]
        public void Match_ValidateComplexChoiceClass_ShouldRetrunFalseAndTextForEmpltyString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.Equal(digit.Match(""), new Match(false, ""));
        }

        [Fact]
        public void Match_ValidateComplexChoiceClass_ShouldRetrunFalseAndTextForNull()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.Equal(digit.Match(null), new Match(false, null));
        }
    }
}
