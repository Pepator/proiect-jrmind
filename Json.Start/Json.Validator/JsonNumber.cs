using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsZero(input);
        }

        static bool IsZero(string input)
        {
            return input == "0";
        }
    }
}
