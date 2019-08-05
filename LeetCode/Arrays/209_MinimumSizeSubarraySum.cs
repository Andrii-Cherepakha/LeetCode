using System;

namespace LeetCode.Arrays
{
    class MinimumSizeSubarraySum
    {
        public int MinSubArrayLen(int s, int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int left = 0;
            int sum = 0;
            int minLength = int.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];
                while (sum >= s)
                {
                    minLength = Math.Min(minLength, i + 1 - left);
                    sum = sum - nums[left];
                    left++;
                }
            }

            return minLength == int.MaxValue ? 0 : minLength;
        }


        public int MinSubArrayLen1(int s, int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int left = 0;
            int right = 0;
            int sum = nums[0];
            int length = 1;
            int minLength = 0;

            while (true)
            //while (right < nums.Length)
            {
                if (sum < s)
                {
                    right++;
                    if (right >= nums.Length) break;
                    sum = sum + nums[right];
                    length++;
                }
                else if (sum >= s)
                {
                    minLength = minLength == 0 ? length : Math.Min(minLength, length);
                    sum = sum - nums[left];
                    left++;
                    length--;
                }
            }

            return minLength;
        }
    }
}