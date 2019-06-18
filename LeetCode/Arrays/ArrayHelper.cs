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
    }
}