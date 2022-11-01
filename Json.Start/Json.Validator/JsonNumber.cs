using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsZero(input)
                && !ContainsLetters(input);
        }

        static bool IsZero(string input)
        {
            return input == "0";
        }

        static bool ContainsLetters(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] > 'a' && input[i] < 'z') && (input[i] < 'A' || input[i] > 'Z'))
                {
                    return true;
                }
            }

            return false;
        }
    }
}