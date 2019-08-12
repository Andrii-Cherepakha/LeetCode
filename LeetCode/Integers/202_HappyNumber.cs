using System;
using System.Collections.Generic;
using NUnit.Framework;

// #cycle_detection

namespace LeetCode.Integers
{
    public class HappyNumber
    {
        [Test]
        public void Test19()
        {
            int n = 19;
            bool expected = true;
            Assert.That(IsHappy(n), Is.EqualTo(expected));
        }

        [Test]
        public void Test18()
        {
            int n = 18;
            bool expected = false;
            Assert.That(IsHappy(n), Is.EqualTo(expected));
        }

        //[Test]
        public void TestGetSquaredNumeric()
        {
            int n;
            n = 19; Console.WriteLine($"{n} -> {GetSquaredNumeric(n)}");
            n = 82; Console.WriteLine($"{n} -> {GetSquaredNumeric(n)}");
            n = 68; Console.WriteLine($"{n} -> {GetSquaredNumeric(n)}");
            n = 100; Console.WriteLine($"{n} -> {GetSquaredNumeric(n)}");
        }

        public bool IsHappy(int n)
        {
            if (n < 1)
            {
                return false;
            }

            int slow = n;
            int fast = n;

            do
            {
                slow = GetSquaredNumeric(slow);
                fast = GetSquaredNumeric(fast);
                fast = GetSquaredNumeric(fast);
            } while (slow != fast);

            return slow == 1;
        }


        public bool IsHappyHashTable(int n)
        {
            if (n < 1)
            {
                return false;
            }

            var storage = new Dictionary<int, int>();

            while (!storage.ContainsKey(n))
            {
                storage[n] = 0;
                n = GetSquaredNumeric(n);
            }
            return n == 1;
        }

        private int GetSquaredNumeric(int n)
        {
            int result = 0;
            while (n != 0)
            {
                int numeric = n % 10;
                result = result + numeric * numeric;
                n = n / 10;
            }

            return result;
        }
    }
}