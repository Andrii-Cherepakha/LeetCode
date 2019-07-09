using System;
using System.Collections.Generic;

namespace LeetCode.Integers
{
    public class SumOfFour
    {


        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> list = new List<IList<int>>();

            if (nums == null)
            {
                return list;
            }

            Array.Sort(nums); // n log(n)

            for (int a = 0; a < nums.Length - 3; a++)
            {
                // skip duplicates
                if (a > 0 && nums[a] == nums[a - 1])
                {
                    continue;
                }

                for (int b = a + 1; b < nums.Length - 2; b++)
                {
                    // skip duplicates
                    if (b > 1 && nums[b] == nums[b - 1])
                    {
                        continue;
                    }

                    int start = b + 1;
                    int end = nums.Length - 1;
                    int reminder = target - nums[a] - nums[b];

                    while (start < end)
                    {
                        int sum = nums[start] + nums[end];
                        if (sum == reminder)
                        {
                            list.Add(new List<int>() { nums[a], nums[b], nums[start], nums[end] });

                            // skip duplicates
                            while (start < end && nums[start] == nums[start + 1]) { start++; }
                            while (start < end && nums[end] == nums[end - 1]) { end--; }

                            start++;
                            end--;
                        }
                        else if (sum > reminder)
                        {
                            end--;
                        }
                        else // if (sum < reminder)
                        {
                            start++;
                        }
                    }
                }
            }
            
            return list;
        }
    }
}