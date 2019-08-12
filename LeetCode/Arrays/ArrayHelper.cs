using System;

namespace LeetCode.Arrays
{
    public class ArrayHelper
    {
        public static void PrintArray(int[] arr)
        {
            Console.WriteLine();
            foreach (var i in arr)
            {
                Console.Write(" " + i);
            }
        }

        public static void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}