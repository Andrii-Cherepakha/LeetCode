using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCode.Arrays
{
    class ContainsDuplicateSolution
    {
        [Test]
        public void Example1()
        {
            int[] nums = { 1, 2, 3, 1 };
            bool expected = true;
            Assert.That(ContainsDuplicate(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int[] nums = { 1, 2, 3, 4 };
            bool expected = false;
            Assert.That(ContainsDuplicate(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Example3()
        {
            int[] nums = { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
            bool expected = true;
            Assert.That(ContainsDuplicate(nums), Is.EqualTo(expected));
        }

        public bool ContainsDuplicate(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return false;
            }

            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    return true;
                }
                else
                {
                    dict[num] = 1;
                }
            }

            return false;
        }

        public bool ContainsDuplicateSort(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return false;
            }

            Array.Sort(nums); // N log N

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}