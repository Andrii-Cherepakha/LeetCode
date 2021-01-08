using System;

namespace LeetCode.Arrays
{
    class _215_KthLargestElementinanArray
    {
        public int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[nums.Length - k];
        }
    }
}
