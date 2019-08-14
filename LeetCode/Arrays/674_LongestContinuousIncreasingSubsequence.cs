using System;

namespace LeetCode.Arrays
{
    class LongestContinuousIncreasingSubsequence
    {

        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int maxLength = 1;
            int length = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    length++;
                }
                else
                {
                    maxLength = Math.Max(maxLength, length);
                    length = 1;
                }
            }

            return Math.Max(maxLength, length);
        }
    }
}
