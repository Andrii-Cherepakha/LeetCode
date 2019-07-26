using System;
using NUnit.Framework;

namespace LeetCode
{
    public class JustTest
    {
        [Test]
        public void Shift()
        {
            for (int i = 0; i <= 10; i++)
            {
                int result = 1 << i;
                Console.WriteLine($"1 << {i} == 2^{i} == {result}");
            }
        }

        [Test]
        public void ContainsSubStringTest()
        {
            int c = ContainsSubString("AAAAA", "A");
        }

        private int ContainsSubString(string word, string sub)
        {
            int counter = 0;

            int pos = word.IndexOf(sub, StringComparison.Ordinal);

            while (pos >= 0)
            {
                counter++;
                word = word.Substring(pos + 1, word.Length - 1 - pos);
                pos = word.IndexOf(sub, StringComparison.Ordinal);
            }
            
            return counter;
        }
    }
}