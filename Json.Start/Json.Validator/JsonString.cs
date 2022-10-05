using System;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Json
{
    public static class JsonString
    {
        const int MinLengt = 2;
        const int SecondToLast = 2;

        public static bool IsJsonString(string input)
        {
            return input != null
                && !ContainsControlCharacters(input)
                && HasValidFirstAndLastCharacters(input)
                && !ContainsUnrecognizedEscapedChar(input)
                ;
        }

        private static bool IsEndingInReverseSolidus(string input)
        {
            return input[input.Length - SecondToLast] == '\\';
        }

        private static bool HasValidFirstAndLastCharacters(string input)
        {
            return input.Length >= MinLengt && input[0] == '"' && input[^1] == '"'
                && !IsEndingInReverseSolidus(input);
        }

        private static bool ContainsControlCharacters(string input)
        {
            return input.Any(char.IsControl);
        }

        private static bool ContainsUnrecognizedEscapedChar(string input)
        {
            try
            {
                Regex.Unescape(input);
            }
            catch (System.ArgumentException x)
            {
                return true;
            }

            return false;
        }
    }
}
