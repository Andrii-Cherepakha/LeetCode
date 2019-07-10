using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.Arrays
{
    public class FindAllDuplicates
    {
        [Test]
        public void Test()
        {
            int[] nums = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };
            var actual = FindDuplicates(nums);
            foreach (var item in actual)
            {
                Console.Write(item + " ");
            }
        }

        public IList<int> FindDuplicates(int[] nums)
        {
            if (nums == null) return null;

            var list = new List<int>();

            // foreach (var num in nums)
            for (int i = 0; i < nums.Length; i++)
            {
                // int index = Math.Abs(num) - 1;
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] > 0)
                {
                    nums[index] = -nums[index];
                }
                else
                {
                    list.Add(index + 1);
                }
            }
            
            return list;
        }
    }
}