using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCode.Strings
{
    class _282_ExpressionAddOperators
    {
        [Test]
        public void Test()
        {
            var answer = AddOperators("123", 6);
        }

        public IList<string> AddOperators(string num, int target)
        {
            var result = new List<string>();

            if (string.IsNullOrEmpty(num)) return result;

            var permutations = GetAllPermutations(num);

            foreach (var perm in permutations)
            {
                if (Evaluate(perm) == target)
                    result.Add(perm);
            }

            return result;
        }

        private List<string> operators = new List<string> { "", "+", "-", "*" };

        private List<string> GetAllPermutations(string num)
        {
            var source = new List<string>();
            var dest = new List<string>();

            source.Add(num[num.Length - 1].ToString());

            for (int i = num.Length - 2; i >= 0; i--)
            {
                foreach (var s in source)
                {
                    foreach (var o in operators)
                    {
                        dest.Add($"{num[i]}{o}{s}");
                    }
                }
                source = dest;
                dest = new List<string>();
            }

            return source;
        }

        private int Evaluate(string expression)
        {
            while (true)
            {
                if (Evaluate(ref expression, "*")) continue;
                if (Evaluate(ref expression, "+")) continue;
                if (Evaluate(ref expression, "-")) continue;
                break;
            }

            return int.Parse(expression);
        }

        // wrong
        private bool Evaluate(ref string expression, string @operator)
        {
            int p = -1;

            if (@operator == "*") p = expression.LastIndexOf(@operator);
            else p = expression.IndexOf(@operator);

            if (p < 0) return false;

            if (@operator == "-" && p == 0) return false; // negative number
                
            int i = p-1;
            // get left number
            while (i >= 0 && !operators.Contains(expression[i].ToString()))
            {
                i--;
            }
           
            int l = i+1;
            int leftNumber = int.Parse(expression.Substring(l, p - l));

            // get rigth number
            i = p+1;
            while (i < expression.Length && !operators.Contains(expression[i].ToString()))
            {
                i++;
            }
            int r = i - 1;
            int rightNumber = int.Parse(expression.Substring(p + 1, r-p));

            int res = 0;
            if (@operator == "*") res = leftNumber * rightNumber;
            else if (@operator == "+") res = leftNumber + rightNumber;
            else if (@operator == "-") res = leftNumber - rightNumber;

            string leftPart = "";
            string rigthPart = "";

            if (l > 0) leftPart = expression.Substring(0, l); // [0..0]
            //if (r < expression.Length) rigthPart = expression.Substring(r + 1, expression.Length - r - 1);

             expression = $"{leftPart}{res}{expression.Substring(r + 1, expression.Length - r - 1)}";

            return true;
        }
    }
}
