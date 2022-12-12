namespace problema_3
{
    public class UnitTest_range
    {
        [Fact]
        public void Match_ValidateStartOfString_ShouldReturnTrueIfStartOfStringIsInRange()
        {
            Range test = new Range('a', 'f');
            Assert.True(test.Match("asd"));
        }

        [Fact]
        public void Match_ValidateStartOfString_ShouldReturnFalseIfStringIsNull()
        {
            Range test = new Range('a', 'f');
            Assert.False(test.Match(null));
        }

        [Fact]
        public void Match_ValidateStartOfString_ShouldReturnFalseIfStringIsEmpty()
        {
            Range test = new Range('a', 'f');
            Assert.False(test.Match(""));
        }
    }
}