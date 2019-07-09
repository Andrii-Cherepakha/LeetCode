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
    }
}