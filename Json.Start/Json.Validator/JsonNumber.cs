using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !string.IsNullOrEmpty(input) && SplitInput(input);
        }

        static bool SplitInput(string input)
        {
            var indexOfDot = input.IndexOf('.');
            var indexOfExponent = input.IndexOfAny("eE".ToCharArray());

            return IsInteger(Integer(input, indexOfDot, indexOfExponent))
                     && IsFraction(Fraction(input, indexOfDot, indexOfExponent))
                     && IsExponent(Exponent(input, indexOfExponent));
        }

        static string Integer(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot != -1)
            {
                return input[..indexOfDot];
            }

            if (indexOfExponent != -1)
            {
                return input[..indexOfExponent];
            }

            return input;
        }

        static bool IsInteger(string input)
        {
            if (input.Length > 1 && input.StartsWith('0'))
            {
                return false;
            }

            if (input.StartsWith('-'))
            {
                input = input[1..];
            }

            return IsNumber(input);
        }

        static bool IsExponent(string input)
        {
            input = input[1..];

            if (input.StartsWith('+') || input.StartsWith('-'))
            {
                input = input[1..];
            }

            return IsNumber(input);
        }

        static bool IsNumber(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static string Fraction(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot == -1)
            {
                return string.Empty;
            }

            return indexOfExponent == -1 ? input[indexOfDot..] : input[indexOfDot..indexOfExponent];
        }

        static bool IsFraction(string input)
        {
            return input.Length == 0 || IsNumber(input[1..]);
        }

        static string Exponent(string input, int indexOfExponent)
        {
            if (indexOfExponent == -1)
            {
                return string.Empty;
            }

            return input[indexOfExponent..];
        }
    }
}