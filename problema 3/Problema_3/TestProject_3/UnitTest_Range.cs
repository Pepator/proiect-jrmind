using static System.Runtime.InteropServices.JavaScript.JSType;

namespace problema_3
{
    public class UnitTest_range
    {
        [Fact]
        public void Match_ValidateStartOfString_ShouldReturnTrueAndRemainingTextIfStartOfStringIsInRange()
        {
            Range test = new Range('a', 'f');
            Assert.Equal(test.Match("abcd"), new Match(true, "bcd"));
        }

        [Fact]
        public void Match_ValidateStartOfString_ShouldReturnFalseAndTextIfStringIsNull()
        {
            Range test = new Range('a', 'f');
            Assert.Equal(test.Match(null), new Match(false, null));
        }

        [Fact]
        public void Match_ValidateStartOfString_ShouldReturnFalseAndTextIfStringIsEmpty()
        {
            Range test = new Range('a', 'f');
            Assert.Equal(test.Match(""), new Match(false, ""));
        }
    }
}