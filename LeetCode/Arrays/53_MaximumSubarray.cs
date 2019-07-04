using System;
using NUnit.Framework;

namespace LeetCode.Arrays
{
    public class MaximumSubarray
    {
        [Test]
        public void Test()
        {
            //int[] nums = {-2, 1, -3, 4, -1, 2, 1, -5, 4};
            //int[] nums = {1, 2, -1, -2, 2, 1, -2, 1, 4, -5, 4};
            int[] nums = { -1, -2, -2, -5 };

            int actual = MaxSubArray(nums);
            Console.WriteLine("Actual: " + actual);
            //Console.WriteLine("Actual: " + MaxSubArrayLeetCode(nums));
        }

        public int MaxSubArray(int[] nums) // O (N)
        {
            if (nums == null || nums.Length == 0)
            {
                return int.MinValue;
            }

            int sum = nums[0];
            int maxSum = sum;

            for (int i = 1; i < nums.Length; i++)
            {
                // add current value to the sum
                sum = sum + nums[i];

                // we need to decide what is better: keep adding value OR start new range with current value
                // if we added current value and sum is not bigger than current value it's better to start new range
                // since it will be bigger and there is no sense to continue with old range
                if (nums[i] > sum)
                {
                    sum = nums[i];
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            return maxSum;
        }

        public int MaxSubArrayNN(int[] nums) // O (N * N)
        {
            if (nums == null)
            {
                return int.MinValue;
            }

            // O (N * N)
            int maxSum = int.MinValue;

            for (int i = 0; i < nums.Length; ++i)
            {
                int sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum = sum + nums[j];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }

            return maxSum;
        }

        public int MaxSubArrayLeetCode(int[] nums)
        {
            int maxSum = int.MinValue;
            int currentSum = 0;

            foreach (var num in nums)
            {
                if (currentSum < 0) currentSum = 0;
                currentSum += num;
                maxSum = Math.Max(maxSum, currentSum);
            }
            return maxSum;
        }
        
        public int MaxSubArrayWrong(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return int.MinValue;
            }

            int sum = 0;
            foreach (var num in nums)
            {
                sum = sum + num;
            }

            int start = 0;
            int end = nums.Length - 1;
            int maxSum = sum;

            while (start < end)
            {
                if (nums[start] < nums[end])
                {
                    sum = sum - nums[start];
                    start++;
                }
                else
                {
                    sum = sum - nums[end];
                    end--;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            return maxSum;
        }
    }
}