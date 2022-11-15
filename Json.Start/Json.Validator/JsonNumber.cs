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
            if (indexOfDot == -1 && indexOfExponent != -1)
            {
                return input[..indexOfExponent];
            }
            else if (indexOfDot == -1 && indexOfExponent == -1)
            {
                return input;
            }

            return input[..indexOfDot];
        }

        static bool IsInteger(string input)
        {
            if (input.Length > 1 && input[0] == '0')
            {
                return false;
            }

            if (input[0] != '-' && input[0] != '+' && (input[0] < '0' || input[0] > '9'))
            {
                return false;
            }

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] < '0' || input[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsExponent(string input)
        {
            if (input == null)
            {
                return false;
            }

            if (!AcceptableFirsAndLastCharacter(input))
            {
                return false;
            }

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] < '0' || input[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }

        static bool AcceptableFirsAndLastCharacter(string input)
        {
            if (input.Length == 0)
            {
                return true;
            }
            else if (input[0] != '-' && input[0] != '+' && (input[0] < '0' || input[0] > '9'))
            {
                return false;
            }
            else if (input[input.Length - 1] < '0' || input[input.Length - 1] > '9')
            {
                return false;
            }

            return true;
        }

        static string Fraction(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot == input.Length - 1)
            {
                return null;
            }

            if (indexOfDot == -1)
            {
                return string.Empty;
            }

            input = indexOfExponent == -1 ? input[(indexOfDot + 1)..] : input[(indexOfDot + 1)..indexOfExponent];

            return input;
        }

        static bool IsFraction(string input)
        {
            if (input == null)
            {
                return false;
            }
            else if (input.Length == 0)
            {
                return true;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < '0' || input[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }

        static string Exponent(string input, int indexOfExponent)
        {
            if (indexOfExponent == -1)
            {
                return string.Empty;
            }

            if (indexOfExponent == input.Length - 1)
            {
                return null;
            }

            input = input[(indexOfExponent + 1)..];

            return input;
        }
    }
}