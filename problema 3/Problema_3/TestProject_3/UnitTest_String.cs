using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public class UnitTest_String
    {
        [Fact]
        public void Match_ValidateStringClass_ShouldRetrunEmptyStringForValidJsonString()
        {
            var a = new String();
            var match = a.Match(Quoted(@"\""a\"" b⚾\b \f"));
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void Match_ValidateStringClass_CanContainSolidusAndEscapedSolidus()
        {
            var a = new String();
            var match = a.Match(Quoted(@"a \\ \/ b"));
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void Match_ValidateStringClass_CanContainUnicodeCharacters()
        {
            var a = new String();
            var match = a.Match(Quoted(@"a \u26Be b"));
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void Match_ValidateStringClass_DoesNotContainUnrecognizedExcapceCharacters()
        {
            var a = new String();
            var match = a.Match(Quoted(@"a\x"));
            Assert.Equal(Quoted(@"a\x"), match.RemainingText());
        }

        [Fact]
        public void Match_ValidateStringClass_DoesNotEndWithReverseSolidus()
        { 
            var a = new String();
            var match = a.Match(Quoted(@"a\"));
            Assert.Equal(Quoted(@"a\"), match.RemainingText());
        }

        [Fact]
        public void Match_ValidateStringClass_DoesNotEndWithUnfinishedHexNumber()
        {
            var a = new String();
            var match = a.Match(Quoted(@"a\u123"));
            Assert.Equal(Quoted(@"a\u123"), match.RemainingText());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
