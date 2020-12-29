using System.Collections.Generic;

namespace LeetCode.Strings
{
    public class _20_ValidParentheses
    {
        public bool IsValid(string s)
        {
            if (s == null || s.Length == 0 || s.Length % 2 == 1) return false;

            var openBrackets = new List<char> { '(', '[', '{' };
            var openToCloseBrackets = new Dictionary<char, char> { { ')', '(' }, { ']', '[' }, { '}', '{' } };
            var stack = new Stack<char>();

            foreach (var ch in s)
            {
                if (openBrackets.Contains(ch))
                {
                    stack.Push(ch);
                }
                else
                {
                    if (stack.Count == 0) return false;
                    var openActual = stack.Pop();

                    var openExpected = openToCloseBrackets[ch];

                    if (openExpected != openActual) return false;
                }
            }

            if (stack.Count > 0) return false;

            return true;
        }

        public bool IsValidLeetCode(string s)
        {
            if (s == null || s.Length == 0 || s.Length % 2 == 1) return false;

            var stack = new Stack<char>();

            foreach (var ch in s)
            {
                if (ch == '(') stack.Push(')');
                else if (ch == '[') stack.Push(']');
                else if (ch == '{') stack.Push('}');
                else if (stack.Count == 0 || stack.Pop() != ch) return false;
            }

            return stack.Count == 0;
        }

    }
}
