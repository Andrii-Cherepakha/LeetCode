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

        public int MaximumProduct(int[] nums) // N 
        {
            int max1 = int.MinValue;
            int max2 = int.MinValue;
            int max3 = int.MinValue;

            int min1 = int.MaxValue;
            int min2 = int.MaxValue;

            foreach (var num in nums)
            {
                if (num >= max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = num;
                }
                else if (num >= max2)
                {
                    max3 = max2;
                    max2 = num;
                }
                else if (num >= max3)
                {
                    max3 = num;
                }

                if (num <= min1)
                {
                    min2 = min1;
                    min1 = num;
                }
                else if (num <= min2)
                {
                    min2 = num;
                }
            }

            return Math.Max(max1 * max2 * max3, min1 * min2 * max1);
        }

        public int MaximumProductNlogN(int[] nums) // N log(N) ACCEPTED
        {
            Array.Sort(nums);

            int max = nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];
            int min = nums[nums.Length - 1] * nums[0] * nums[1];

            return Math.Max(max, min);
        }
    }
}