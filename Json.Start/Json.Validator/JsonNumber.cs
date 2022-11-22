using System;

namespace Json
{
    public static class JsonNumber
    {

        const int IndexAfterOperator = 2;
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

            if (!input.StartsWith('-'))
            {
                return IsNumber(input);
            }

            return IsNumber(input[1..]);
        }

        static bool IsExponent(string input)
        {
            if (input.Length == 1)
            {
                return false;
            }

            if (input.Length == 0)
            {
                return true;
            }

            if (input[1] != '+' && input[1] != '-')
            {
                return IsNumber(input[1..]);
            }

            return IsNumber(input[IndexAfterOperator..]);
        }

        static bool IsNumber(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }

            for (int i = 1; i < input.Length; i++)
            {
                if (!IsFigure(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsFigure(char nr)
        {
            return nr >= '0' && nr <= '9';
        }

        static string Fraction(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot == -1)
            {
                return string.Empty;
            }

            input = indexOfExponent == -1 ? input[indexOfDot..] : input[indexOfDot..indexOfExponent];

            return input;
        }

        static bool IsFraction(string input)
        {
            if (input.Length == 1)
            {
                return false;
            }
            else if (input.Length == 0)
            {
                return true;
            }

            return IsNumber(input[1..]);
        }

        static string Exponent(string input, int indexOfExponent)
        {
            if (indexOfExponent == -1)
            {
                return string.Empty;
            }

            input = input[indexOfExponent..];

            return input;
        }
    }
}