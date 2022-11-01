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

            if (input[input.Length - 1] == '.' || ContainsTwoFractionParts(input) > 1)
            {
                return false;
            }

            if (input.Length > 1 && input[0] == '0' && input[1] != '.')
            {
                return false;
            }

            return true;
        }

        static int ContainsTwoFractionParts(string input)
        {
            int numberOfFractionParts = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '.')
                {
                    numberOfFractionParts++;
                }
            }

            return numberOfFractionParts;
        }

        static bool ContainsLetters(string input)
        {
            input = input.ToLower();
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= 'a' && input[i] <= 'd') || (input[i] >= 'f' && input[i] <= 'z'))
                {
                    return true;
                }
            }

            return false;
        }
    }
}