using NUnit.Framework;
using System;

namespace LeetCode.Arrays
{
    class MaximumProductOfThreeNumbers
    {
        [Test]
        public void Example2()
        {
            int[] nums = { 1, 2, 3, 4 };
            int expected = 24;
            Assert.That(MaximumProduct(nums), Is.EqualTo(expected));
        }
               
        public int MaximumProduct(int[] nums) // N log(N) ACCEPTED
        {
            Array.Sort(nums);

            int max = nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];
            int min = nums[nums.Length - 1] * nums[0] * nums[1];

            return Math.Max(max, min);
        }
    }
}