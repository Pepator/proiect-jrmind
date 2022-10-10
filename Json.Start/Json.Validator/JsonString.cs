using System;

namespace Json
{
    public static class JsonString
    {
        const int MinLenght = 2;
        const int SecondToLast = 2;

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
            foreach (char x in input)
            {
                if (char.IsControl(x))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsUnrecognizedEscapedChar(string input)
        {
            const int StartOfHexNumber = 2;
            const int EndOfHexNumber = 3;
            char[] escapedChars = { 'a', 'b', 'f', 'n', 'r', 'v', 't', '\'', '\"', '?', '\\', '/' };
            int i = 0;

            while (i < input.Length)
            {
                if (input[i] == '\\' && i < input.Length - 1 && input[i + 1] == ' ')
                {
                    i++;
                    continue;
                }

                if (input[i] == '\\' && !ContainsChar(escapedChars, input[i + 1]))
                {
                    if (input[i + 1] == 'u' && ValidHexNumber(input, i + StartOfHexNumber))
                    {
                        i = i + StartOfHexNumber + EndOfHexNumber;
                    }
                    else
                    {
                        return true;
                    }
                }

                i++;
            }

            return false;
        }

        private static bool ValidHexNumber(string input, int index)
        {
            const int HexadecimalLenght = 4;
            char[] hexNumber = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F' };

            if (index + HexadecimalLenght > input.Length - 1)
            {
                return false;
            }

            for (int i = index; i < index + HexadecimalLenght; i++)
            {
                if (!ContainsChar(hexNumber, input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ContainsChar(char[] charList, char serchChar)
        {
            foreach (char x in charList)
            {
                if (x == serchChar)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
