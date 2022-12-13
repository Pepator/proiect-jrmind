namespace problema_3
{
    public class UnitTest_Choice
    {
        [Fact]
        public void Match_ValidateChoiceClass_ShouldRetrunTrueIfConditionsAreMet()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.True(digit.Match("012"));
        }

        [Fact]
        public void Match_ValidateChoiceClass_ShouldRetrunFalseForEmptyString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.False(digit.Match(""));
        }

        [Fact]
        public void Match_ValidateChoiceClass_ShouldRetrunFalseForNull()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.False(digit.Match(null));
        }

        [Fact]
        public void Match_ValidateComplexChoiceClass_ShouldRetrunTrueIfConditionsAreMet()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(hex.Match("012"));
        }

        [Fact]
        public void Match_ValidateComplexChoiceClass_ShouldRetrunFalseForEmpltyString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.False(hex.Match(""));
        }

        [Fact]
        public void Match_ValidateComplexChoiceClass_ShouldRetrunFalseForNull()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.False(hex.Match(null));
        }
    }
}
