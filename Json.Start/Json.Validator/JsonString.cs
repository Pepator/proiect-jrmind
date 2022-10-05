using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Json
{
    public static class JsonString
    {
        const int MinLengt = 2;

        public static bool IsJsonString(string input)
        {
            return input != null
                && !ContainsControlCharacters(input)
                && IsDoubleQuoted(input);
        }

        private static bool IsDoubleQuoted(string input)
        {
            return input.Length >= MinLengt && input[0] == '"' && input[^1] == '"';
        }

        private static bool ContainsControlCharacters(string input)
        {
            return input.Any(char.IsControl);
        }
    }
}
