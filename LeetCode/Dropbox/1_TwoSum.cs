
using System.Collections.Generic;

namespace LeetCode.Dropbox
{
    public class TwoSum
    {
        public int[] TwoSum1(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int expected = target - nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == expected)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { 0, 0 };
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                dict[nums[i]] = i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int expected = target - nums[i];
                if (dict.ContainsKey(expected) && i != dict[expected])
                {
                    return new int[] { i, dict[expected] };
                }
            }

            return new int[] { 0, 0 };
        }

        public int[] TwoSum3(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int expected = target - nums[i];
                if (dict.ContainsKey(expected))
                {
                    return new int[] { i, dict[expected] };
                }
                dict[nums[i]] = i;
            }

            return new int[] { 0, 0 };
        }
    }
}
