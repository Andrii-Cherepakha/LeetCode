using System.Collections.Generic;

namespace LeetCode.Integers
{
    public class RomanToIntegerLinear
    {
        public int RomanToInt(string s)
        {
            int result = _intByRoman[s[s.Length - 1]];

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (_intByRoman[s[i]] < _intByRoman[s[i + 1]])
                {
                    result -= _intByRoman[s[i]];
                }
                else
                {
                    result += _intByRoman[s[i]];
                }
            }

            return result;
        }


        // If I comes before V or X, subtract 1 eg: IV = 4 and IX = 9
            // If X comes before L or C, subtract 10 eg: XL = 40 and XC = 90
            // If C comes before D or M, subtract 100 eg: CD = 400 and CM = 900

        public int RomanToIntLessLength(string s)
        {
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int sign = 1;

                if (i + 1 < s.Length && (
                        (s[i] == 'I' && (s[i + 1] == 'V' || s[i + 1] == 'X')) ||
                        (s[i] == 'X' && (s[i + 1] == 'L' || s[i + 1] == 'C')) ||
                        (s[i] == 'C' && (s[i + 1] == 'D' || s[i + 1] == 'M')) )
                    )
                {
                    sign = -1;
                }

                result = result + sign * _intByRoman[s[i]];
            }

            return result;
        }


        public int RomanToIntLong(string s)
        {
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'I' && i + 1 < s.Length)
                {
                    if (s[i + 1] == 'V' || s[i + 1] == 'X')
                    {
                        result = result - 1;
                    }
                    else
                    {
                        result = result + 1;
                    }
                }
                else if (s[i] == 'X' && i + 1 < s.Length)
                {
                    if (s[i + 1] == 'L' || s[i + 1] == 'C')
                    {
                        result = result - 10;
                    }
                    else
                    {
                        result = result + 10;
                    }
                }
                else if (s[i] == 'C' && i + 1 < s.Length)
                {
                    if (s[i + 1] == 'D' || s[i + 1] == 'M')
                    {
                        result = result - 100;
                    }
                    else
                    {
                        result = result + 100;
                    }
                }
                else
                {
                    result = result + _intByRoman[s[i]];
                }
            }

            return result;
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