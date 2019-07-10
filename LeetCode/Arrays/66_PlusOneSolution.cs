using System;
using NUnit.Framework;

namespace LeetCode.Arrays
{
    public class PlusOneSolution
    {
        [Test]
        public void TestNull()
        {
            PlusOne(null);
        }

        [Test]
        public void TestEmpty()
        {
            PlusOne(new int[] { });
        }

        [Test]
        public void Test0()
        {
            int[] digits = new[] { 0 };
            var actual = PlusOne(digits);
            ArrayHelper.PrintArray(actual);
        }

        [Test]
        public void Test10()
        {
            int[] digits = new[] { 1, 0 };
            var actual = PlusOne(digits);
            ArrayHelper.PrintArray(actual);
        }

        [Test]
        public void Test89()
        {
            int[] digits = new[] { 8, 9 };
            var actual = PlusOne(digits);
            ArrayHelper.PrintArray(actual);
        }

        [Test]
        public void Test99()
        {
            int[] digits = new[] { 9, 9 };
            var actual = PlusOne(digits);
            ArrayHelper.PrintArray(actual);
        }

        public int[] PlusOne(int[] digits)
        {
            if (digits == null) return null;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }

            int[] newDigits = new int[digits.Length + 1];
            newDigits[0] = 1;

            return newDigits;
        }

        public int[] PlusOneMy(int[] digits)
        {
            if (digits == null) return null;

            int carry = 1; // plus one
            int index = digits.Length - 1;
            while (carry != 0 && index >= 0)
            {
                digits[index] += carry;
                carry = 0;

                if (digits[index] == 10)
                {
                    digits[index] = 0;
                    carry = 1;
                }
                index--;
            }

            if (carry != 0)
            {
                int[] newDigits = new int[digits.Length + 1];
                newDigits[0] = carry;                            
                Array.Copy(digits, 0, newDigits, 1, digits.Length);
                digits = newDigits;
            }

            return digits;
        }
    }
}