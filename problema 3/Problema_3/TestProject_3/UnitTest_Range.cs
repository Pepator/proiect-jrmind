using static System.Runtime.InteropServices.JavaScript.JSType;

namespace problema_3
{
    public class UnitTest_range
    {
        [Fact]
        public void Match_ValidateStartOfString_ShouldReturnTrueAndRemainingTextIfStartOfStringIsInRange()
        {
            Range test = new Range('a', 'f');
            Assert.Equal((true, "bcd"), (test.Match("abcd").Succes(), test.Match("abcd").RemainingText()));
        }

        [Fact]
        public void Match_ValidateStartOfString_ShouldReturnFalseAndTextIfStringIsNull()
        {
            Range test = new Range('a', 'f');
            Assert.Equal((false, null), (test.Match(null).Succes(), test.Match(null).RemainingText()));
        }

        [Fact]
        public void Match_ValidateStartOfString_ShouldReturnFalseAndTextIfStringIsEmpty()
        {
            Range test = new Range('a', 'f');
            Assert.Equal((false, ""), (test.Match("").Succes(), test.Match("").RemainingText()));
        }
    }
}