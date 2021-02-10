using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.AmazonTop
{
    class _273_IntegertoEnglishWords
    {
        [Test]
        public void Test()
        {
            NumberToWords(645);
        }

        public string NumberToWords(int num)
        {

            if (num == 0) return "Zero";

            StringBuilder sb = new StringBuilder();
            int n = num;
            int divisor;

            divisor = 1000000000;

            while (divisor > 0)
            {
                n = num / divisor;
                if (n > 0)
                {
                    sb.Append(Get(n));
                    sb.Append(suffixes[divisor]);
                }
                num = num % divisor;
                divisor /= 1000;
            }

            return sb.ToString().Trim();
        }

        private string Get(int num)
        {
            StringBuilder sb = new StringBuilder();

            int divisor = 100;

            while (divisor > 0)
            {
                if (num >= 10 && num <= 19)
                {
                    sb.Append(numbers[num]);
                    break;
                }

                int n = num / divisor;

                if (n > 0)
                {
                    if (divisor == 10) n *= 10;

                    sb.Append(numbers[n]);
                    sb.Append(suffixes[divisor]);
                }

                num = num % divisor;
                divisor /= 10;
            }

            return sb.ToString().Trim();
        }

        private Dictionary<int, string> numbers = new Dictionary<int, string>()
    {
        {0, ""},
        {1, "One "},
        {2, "Two "},
        {3, "Three "},
        {4, "Four "},
        {5, "Five "},
        {6, "Six "},
        {7, "Seven "},
        {8, "Eight "},
        {9, "Nine "},
        {10, "Ten "},
        {11, "Eleven "},
        {12, "Twelve "},
        {13, "Thirteen "},
        {14, "Fourteen "},
        {15, "Fifteen "},
        {16, "Sixteen "},
        {17, "Seventeen "},
        {18, "Eighteen "},
        {19, "Nineteen "},
        {20, "Twenty "},
        {30, "Thirty "},
        {40, "Forty "},
        {50, "Fifty "},
        {60, "Sixty "},
        {70, "Seventy "},
        {80, "Eighty "},
        {90, "Ninety "},
    };

        private Dictionary<int, string> suffixes = new Dictionary<int, string>()
    {
        {0, ""},
        {1, ""},
        {10, ""},
        {100, "Hundred "},
        {1000, " Thousand "},
        {1000000, " Million "},
        {1000000000, " Billion "},
    };

    }
}