using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsValid(input)
                && !ContainsLetters(input);
        }

        static bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (input.Length > 1 && input[0] == '0' && input[1] != '.')
            {
                return false;
            }

            return true;
        }

        static bool ContainsLetters(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= 'a' && input[i] <= 'z') && (input[i] <= 'A' || input[i] >= 'Z'))
                {
                    return true;
                }
            }

            return false;
        }
    }
}