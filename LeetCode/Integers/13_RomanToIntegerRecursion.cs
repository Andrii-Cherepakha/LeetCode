using System.Collections.Generic;

namespace LeetCode.Integers
{
    public class RomanToIntegerRecursion
    {

        // O( N * N)
        public int RomanToInt(string s)
        {
            int significantPosition = FindMostSignificant(s);

            string left = s.Substring(0, significantPosition);
            string right = s.Substring(significantPosition + 1, s.Length - 1 - significantPosition);
            
            int leftInt = left.Length == 0 ? 0 : RomanToInt(left);
            int rightInt = right.Length == 0 ? 0 : RomanToInt(right);

            return _intByRoman[s[significantPosition]] - leftInt + rightInt;
        }

        // return position of the first most significant roman numeric
        public int FindMostSignificant(string roman)
        {
            int position = 0;

            for (int i = 1; i < roman.Length; i++)
            {
                if (_intByRoman[roman[i]] > _intByRoman[roman[position]])
                {
                    position = i;
                }
            }

            return position;
        }

        private readonly Dictionary<char, int> _intByRoman = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        }; 
    }
}