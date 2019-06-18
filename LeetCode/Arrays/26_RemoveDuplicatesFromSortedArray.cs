using System;
using NUnit.Framework;

namespace LeetCode.Arrays
{
    public class RemoveDuplicatesFromSortedArray
    {
        [Test]
        public void Test()
        {
            int[] arr = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            //int[] arr = { 0 };
            //int[] arr = { 0, 0 };
            //int[] arr = { 0, 1 };
            //int[] arr = { 0, 1, 1 };
            //int[] arr = { 1, 1, 2 };
            //int[] arr = { 1, 1, 1, 1, 1, 1, 2, 2 };
            // ArrayHelper.PrintArray(arr);
            var length = RemoveDuplicates(arr);
            Console.WriteLine($"Lenght: {length}");
            ArrayHelper.PrintArray(arr);
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int length = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[length - 1])
                {
                    nums[length] = nums[i];
                    length++;
                }
            }

            return length;
        }


        public int RemoveDuplicates2(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            //int indexToCompare = 0;
            //int indexToInsert = 1;
            int length = 1; // can be combined in one variable

            for (int i = 1; i < nums.Length; i++)
            {
                //Console.WriteLine($"indexToCompare {indexToCompare} indexToInsert {indexToInsert} length {length}");

                if (nums[i] != nums[length - 1])
                {
                    nums[length] = nums[i];
                    length++;
                }

                //if (nums[i] != nums[indexToCompare])
                //{
                //    nums[indexToInsert] = nums[i];
                //    indexToInsert++;
                //    indexToCompare++;
                //    length++;
                //}
            }

            return length;
        }
    }
}
