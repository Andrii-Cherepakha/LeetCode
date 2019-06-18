using System;
using NUnit.Framework;

namespace LeetCode.Arrays
{
    public class RemoveAllInstances
    {
        [Test]
        public void Test()
        {
            //int[] arr = { 3,2,2,3 };
            //int[] arr = { 3, 3, 3, 3 };
            //int[] arr = { 3, 3, 1, 3 };
            //int[] arr = { 3, 3, 1, 3, 3, 3, 4 };
            //var length = RemoveElement(arr, 3);

            int[] arr = {0, 1, 2, 2, 3, 0, 4, 2};
            var length = RemoveElement(arr, 2);
            Console.WriteLine($"Lenght: {length}");
            ArrayHelper.PrintArray(arr);
        }

        public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int length = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[length] = nums[i];
                    length++;
                }
            }

            return length;
        }
    }
}