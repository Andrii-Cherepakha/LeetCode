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

        public IList<int> FindDisappearedNumbersLeetCode(int[] nums)
        {
            if (nums == null) return null;

            var list = new List<int>();

            // iterate through the input array and mark elements as negative 
            // In this way all the numbers that we have seen will be marked as negative
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1; // it can be already marked as negative on previous step
                if (nums[index] > 0) // can be already marked as negative. do not do it again
                {
                    nums[index] = -nums[index];
                }
            }

            // In the second iteration, if a value is not marked as negative,
            // it implies we have never seen that index before, so just add it to the return list.
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    list.Add(i+1);
            }

            return list;
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