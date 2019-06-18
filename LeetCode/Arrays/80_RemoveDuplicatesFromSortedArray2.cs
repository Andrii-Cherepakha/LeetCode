using System;
using NUnit.Framework;

namespace LeetCode.Arrays
{
    public class RemoveDuplicatesFromSortedArray2
    {
        [Test]
        public void Test()
        {
            int[] arr = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            //int[] arr = { 0 };
            //int[] arr = { 0, 0 };
            //int[] arr = { 0, 1 };
            //int[] arr = { 1, 1, 2 };
            //int[] arr = { 1, 1, 1, 1, 1, 1, 2, 2 };

            //int[] arr = {1, 1, 1, 2, 2, 3};
            //int[] arr = {0, 0, 1, 1, 1, 1, 2, 3, 3};
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

            const int duplicatesAllowed = 2;
            int indexToCompare = 0;
            int indexToInsert = 1;
            int length = 1;
            int occurence = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[indexToCompare])
                {
                    occurence++;

                    if (occurence <= duplicatesAllowed)
                    {
                        nums[indexToInsert] = nums[i];
                        indexToInsert++;
                        indexToCompare++;
                        length++;
                    }
                }
                //if (nums[i] != nums[indexToCompare])
                else
                {
                    nums[indexToInsert] = nums[i];
                    indexToInsert++;
                    indexToCompare++;
                    length++;
                    occurence = 1;
                }
            }

            return length;
        }
    }
}