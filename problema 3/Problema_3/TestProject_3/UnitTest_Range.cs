using static System.Runtime.InteropServices.JavaScript.JSType;

namespace problema_3
{
    public class UnitTest_range
    {
        [Fact]
        public void Match_ValidateStartOfString_ShouldReturnTrueAndRemainingTextIfStartOfStringIsInRange()
        {
            Range test = new Range('a', 'f');
            var match = test.Match("abcd");
            Assert.Equal((true, "bcd"), (match.Succes(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateStartOfString_ShouldReturnFalseAndTextIfStringIsNull()
        {
            Range test = new Range('a', 'f');
            var match = test.Match("");
            Assert.Equal((false, ""), (match.Succes(), match.RemainingText()));
        }

        [Fact]
        public void Match_ValidateStartOfString_ShouldReturnFalseAndTextIfStringIsEmpty()
        {
            Range test = new Range('a', 'f');
            var match = test.Match(null);
            Assert.Equal((false, null), (match.Succes(), match.RemainingText()));
        }
    }
}