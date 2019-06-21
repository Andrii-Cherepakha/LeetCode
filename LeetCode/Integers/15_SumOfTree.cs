using System;
using System.Collections.Generic;

namespace LeetCode.Integers
{
    public class SumOfTree
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();

            if (nums == null)
            {
                return list;
            }

            Array.Sort(nums); // n log(n)

            // n n log(n)
            for (int a = 0; a < nums.Length - 2; a++)
            {
                if (a > 0 && nums[a] == nums[a - 1])
                {
                    continue;
                }

                for (int b = a + 1; b < nums.Length - 1; b++)
                {
                    if (b > a + 1 && nums[b] == nums[b - 1])
                    {
                        continue;
                    }

                    int reminder = 0 - nums[a] - nums[b];
                    int c = BinarySearch(nums, b + 1, nums.Length - 1, reminder);
                    if (c == -1)
                    {
                        continue;
                    }

                    list.Add(new List<int>() { nums[a] , nums[b], nums[c] });
                }
            }

            return list;
        }

        // returns index of the element or -1
        private int BinarySearch(int[] nums, int start, int end, int value)
        {
            while (start <= end)
            {
                int position = (start + end) / 2;
                if (nums[position] == value)
                {
                    return position;
                }
                if (nums[position] > value)
                {
                    end = position - 1;
                }
                if (nums[position] < value)
                {
                    start = position + 1;
                }
            }

            return -1;
        }
    }
}