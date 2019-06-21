using System;
using System.Collections.Generic;

namespace LeetCode.Integers
{
    class SumOfTreeNN
    {

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();

            if (nums == null)
            {
                return list;
            }

            Array.Sort(nums); // n log(n)

            for (int a = 0; a < nums.Length - 2; a++)
            {
                // Since the nums is sorted, if first number is bigger than 0, it is impossible to have a sum of 0.
                if (nums[a] > 0)
                {
                    break;
                }

                if (a > 0 && nums[a] == nums[a - 1])
                {
                    continue;
                }

                int start = a + 1;
                int end = nums.Length - 1;
                int reminder = 0 - nums[a];

                while (start < end)
                {
                    if (nums[start] + nums[end] == reminder)
                    {
                        list.Add(new List<int>() { nums[a], nums[start], nums[end] });
                        // skip duplicates
                        while (start < end && nums[start] == nums[start+1]) { start++; }
                        while (start < end && nums[end] == nums[end - 1]) { end--; }

                        start++;
                        end--;
                    }
                    else if (nums[start] + nums[end] < reminder)
                    {
                        //while (start < end && nums[start] == nums[start + 1]) { start++; } // skip duplicates
                        start++;
                    }
                    else //  if (nums[start] + nums[end] > reminder)
                    {
                        //while (start < end && nums[end] == nums[end - 1]) { end--; } // skip duplicates
                        end--;
                    }                        
                }
            }

            return list;
        }
    }
}