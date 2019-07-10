using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.Arrays
{
    public class DisappearedNumbers
    {
        [Test]
        public void Test()
        {
            int[] nums = new int[]{ 4, 3, 2, 7, 8, 2, 3, 1 };
            var actual = FindDisappearedNumbers(nums);
            foreach (var item in actual)
            {
                Console.Write(item + " ");
            }
        }

        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            if (nums == null) return null;

            var list = new List<int>();

            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] != nums[nums[i] - 1]) // avoid infinite loop
                {
                    // swap
                    int tmp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = tmp;
                    continue;
                }
                i++;
            }

            // find
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != j + 1)
                {
                    list.Add(j+1);
                }
            }

            return list;
        }
    }
}