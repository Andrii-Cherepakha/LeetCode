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

        public string NumberToWords(int num) // WRONG
        {
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
                    sb.Append(" ");
                    if (divisor >= 100)
                    {
                        sb.Append(dict[divisor]);
                        sb.Append(" ");
                    }
                }
                num = num % divisor;
                divisor /= 1000;
            }

            //divisor = 1000000000;
            //n = num / divisor;
            //if(n > 0)
            //{
            //    sb.Append(Get(n));
            //    sb.Append(" ");
            //    sb.Append(dict[divisor]);
            //    sb.Append(" ");
            //}
            //num = num % divisor;

            //divisor = 1000000;
            //n = num / divisor;
            //if(n > 0)
            //{
            //    sb.Append(Get(n));
            //    sb.Append(" ");
            //    sb.Append(dict[divisor]);
            //    sb.Append(" ");
            //}

            return sb.ToString().Trim();
        }

        private string Get(int num)
        {
            StringBuilder sb = new StringBuilder();

            int p100 = num / 100;

            if (p100 > 0)
            {
                sb.Append(dict[p100]);
                sb.Append(" Hundred");
            }

            int p10 = (num % 100) / 10 * 10;

            if (p10 > 0)
            {
                sb.Append(" ");
                sb.Append(dict[p10]);
            }

            int p1 = (num % 100) % 10;

            if (p1 > 0)
            {
                sb.Append(" ");
                sb.Append(dict[p1]);
            }

            //    int divisor = 100;

            //    while(num > 0)
            //    {
            //        int n = num / divisor;
            //        if (n > 0)
            //        {
            //            sb.Append(" ");
            //            sb.Append(dict[n]);
            //            sb.Append(" ");
            //            if (divisor == 100) sb.Append(dict[divisor]);
            //        }
            //        num = num % divisor;
            //        divisor /= 10;
            //    }

            return sb.ToString().Trim();

        }

        private Dictionary<int, string> dict = new Dictionary<int, string>()
    {
        {0, ""},
        {1, "One"},
        {2, "Two"},
        {3, "Three"},
        {4, "Four"},
        {5, "Five"},
        {6, "Six"},
        {7, "Seven"},
        {8, "Eight"},
        {9, "Nine"},
        {10, "Ten"},
        {11, "Eleven"},
        {12, "Twelve"},
        {13, "Thirteen"},
        {14, "Fourteen"},
        {15, "Fifteen"},
        {16, "Sixteen"},
        {17, "Seventeen"},
        {18, "Eighteen"},
        {19, "Nineteen"},
        {20, "Twenty"},
        {30, "Thirty"},
        {40, "Forty"},
        {50, "Fifty"},
        {60, "Sixty"},
        {70, "Seventy"},
        {80, "Eighty"},
        {90, "Ninety"},
        {100, "Hundred"},
        {1000, "Thousand"},
        {1000000, "Million"},
        {1000000000, "Billion"},
    };

    }
}
