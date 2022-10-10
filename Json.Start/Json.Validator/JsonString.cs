using System;

namespace Json
{
    public static class JsonString
    {
        const int MinLenght = 2;
        const int SecondToLast = 2;
        const int JumpAfterBackslash = 2;
        const string JsonContrlCharacters = "\b\f\n\r\t";

        public static bool IsJsonString(string input)
        {
            return input != null
                && !ContainsControlCharacters(input)
                && HasValidCharacters(input)
                && !ContainsUnrecognizedEscapedChar(input)
                ;
        }

        private static bool HasValidCharacters(string input)
        {
            return HasValidFirstAndLastCharacters(input) && !IsEndingInReverseSolidus(input);
        }

        private static bool IsEndingInReverseSolidus(string input)
        {
            return input[input.Length - SecondToLast] == '\\';
        }

        private static bool HasValidFirstAndLastCharacters(string input)
        {
            return input.Length >= MinLenght && input[0] == '"' && input[^1] == '"';
        }

        private static bool ContainsControlCharacters(string input)
        {
            for (int i = 1; i < input.Length - 1; i++)
            {
                if (JsonContrlCharacters.Contains(input[i]))
                {
                    return true;
                }

                if (input[i] == '\"' && input[i - 1] != '\\')
                {
                    return true;
                }

                if (input[i] == '/' && input[i - 1] != '\\')
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsUnrecognizedEscapedChar(string input)
        {
            const int StartOfHexNumber = 2;
            const int EndOfHexNumber = 4;
            const string EscapedCharacter = "abfnrvt\'\"?\\/ ";
            int i = 0;

            while (i < input.Length)
            {
                if (input[i] == '\\' && !EscapedCharacter.Contains(input[i + 1]))
                {
                    if (input[i + 1] == 'u' && ValidHexNumber(input, i + StartOfHexNumber))
                    {
                        i = i + StartOfHexNumber + EndOfHexNumber;
                        continue;
                    }

                    return true;
                }

                i++;
            }

            return false;
        }

        private static bool ValidHexNumber(string input, int index)
        {
            const int HexadecimalLenght = 4;
            const string HexNumber = "0123456789abcdefABCDEF";

            if (index + HexadecimalLenght > input.Length - 1)
            {
                return false;
            }

            for (int i = index; i < index + HexadecimalLenght; i++)
            {
                if (!HexNumber.Contains(input[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
