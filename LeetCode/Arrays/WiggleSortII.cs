using NUnit.Framework;

namespace LeetCode.Arrays
{
    // 324. Wiggle Sort II Medium
    // Given an unsorted array nums, reorder it such that nums[0] < nums[1] > nums[2] < nums[3]..
    public class WiggleSortII
    {
        [Test]
        public void Test()
        {
            //int[] arr = { 1, 5, 1, 1, 6, 4 };
            int[] arr = { 1, 3, 2, 2, 3, 1 };
            //int[] arr = { 1, 1, 1, 5, 2, 4 };
            ArrayHelper.PrintArray(arr);
            WiggleSort(arr);
            ArrayHelper.PrintArray(arr);
        }


        public void WiggleSort(int[] arr) // WRONG !!!
        {
            for (int i = 0; i < arr.Length; i += 2)
            {
                // If current even element is smaller than previous 
                if (i > 0 && arr[i - 1] < arr[i])
                    Swap(arr, i - 1, i);

                // If current even element is smaller than next 
                if (i < arr.Length - 1 && arr[i] > arr[i + 1])
                    Swap(arr, i, i + 1);
            }

        }

        private void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}