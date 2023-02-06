using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public class UnitTest_Value
    {
        [Fact]
        public void Match_ValidateValueClass_ShouldRetrunEmptyStringForString()
        {
            var value = new Value();
            var match = value.Match("\"test test test asdasd\"");
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void Match_ValidateValueClass_ShouldRetrunEmptyStringForNumber()
        {
            var value = new Value();
            var match = value.Match("12344534234223");
            Assert.Equal("", match.RemainingText());
        }


        [Fact]
        public void Match_ValidateValueClass_ShouldRetrunEmptyStringForNull()
        {
            var value = new Value();
            var match = value.Match("null");
            Assert.Equal("", match.RemainingText());
        }


        [Fact]
        public void Match_ValidateValueClass_ShouldRetrunEmptyStringForBoolean()
        {
            var value = new Value();
            var match = value.Match("true");
            Assert.Equal("", match.RemainingText());
        }


        [Fact]
        public void Match_ValidateValueClass_ShouldRetrunEmptyStringForArray()
        {
            var value = new Value();
            var match = value.Match("[ 10, 20, 30, 40, 100 ]");
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void Match_ValidateValueClass_ShouldRetrunEmptyStringForObject()
        {
            var value = new Value();
            var match = value.Match("{ \"test\" : 100 }");
            Assert.Equal("", match.RemainingText());
        }
    }
}
