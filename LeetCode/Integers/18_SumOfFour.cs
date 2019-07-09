using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Integers
{
    public class SumOfFour
    {

        [Test]
        public void Test()
        {
            int[] nums = new int[] { 1, 0, -1, 0, -2, 2 };
            int target = 0;
            FourSum(nums, target);
        }

        [Test]
        public void Test2()
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            int target = -1;
            FourSum(nums, target);
        }


        public IList<IList<int>> FourSum2(int[] nums, int target) // N*N ? ACCEPTED
        {
            IList<IList<int>> list = new List<IList<int>>();

            if (nums == null)
            {
                return list;
            }

            var dict = new Dictionary<int, List<int[]>>();

            for (int i = 0; i < nums.Length - 1; i++) // N*N
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var key = nums[i] + nums[j]; // O(N) ?
                    if (!dict.ContainsKey(key))
                    {
                        dict[key] = new List<int[]>();
                    }

                    bool exists = false;
                    foreach (int[] arr in dict[key])
                    {
                        if ((arr[0] == nums[i] && arr[1] == nums[j]) ||
                            (arr[1] == nums[i] && arr[0] == nums[j]))
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        dict[key].Add(new[] { i, j }); // add indexes not values
                    }
                }
            }

            foreach (int key in dict.Keys) // O(N) ?
            {
                int key2 = target - key;

                if (!dict.ContainsKey(key2)) continue;

                foreach (int[] arr1 in dict[key]) // for each element in first list 
                {
                    foreach (int[] arr2 in dict[key2]) // for each element in second list 
                    {
                        if (arr1.Union(arr2).ToArray<int>().Distinct().Count() < 4) continue; // remove duplicates indexes

                        var item = new List<int>() { nums[arr1[0]], nums[arr1[1]], nums[arr2[0]], nums[arr2[1]] };
                        item.Sort();

                        bool exists = false;
                        foreach (var arr in list)
                        {
                            if (arr[0] == item[0] && arr[1] == item[1] && arr[2] == item[2] && arr[3] == item[3])
                            {
                                exists = true;
                                break;
                            }
                        }

                        if (!exists)
                        {
                            list.Add(item);
                        }
                    }
                }
            }

            return list;
        }

         
        public IList<IList<int>> FourSum(int[] nums, int target) // N^3 ACCEPTED
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
                    if (b > a + 1 && nums[b] == nums[b - 1])
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