using NUnit.Framework;
using System;

namespace LeetCode.Arrays
{
    class _845_LongestMountain
    {
        [Test]
        public void Test()
        {
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 14, 13, 12, 12, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            LongestMountain(arr);
        }
        
        public int LongestMountain(int[] arr)
        {
            if (arr.Length < 3) return 0;

            int max = 0;
            int minIndex = -1;
            int maxIndex = -1;

            if (arr[0] < arr[1]) minIndex = 0;

            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (arr[i - 1] >= arr[i] && arr[i] <= arr[i + 1]) //  4 cases: \/  \_  _/  __
                {
                    if (maxIndex != -1)
                    {
                        int length = i - minIndex + 1;
                        max = Math.Max(max, length);
                        maxIndex = -1;
                    }

                    minIndex = i;
                } 
                else if (arr[i - 1] < arr[i] && arr[i] > arr[i + 1]) maxIndex = i; // maximum: /\
            }

            if (arr[arr.Length - 1] < arr[arr.Length - 2] && maxIndex != -1)
            {
                int length = arr.Length - 1 - minIndex + 1;
                max = Math.Max(max, length);
            }

            return max;
        }
    }
}
