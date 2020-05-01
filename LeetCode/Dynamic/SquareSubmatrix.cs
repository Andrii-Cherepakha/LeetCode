

using NUnit.Framework;
using System;

namespace LeetCode.Dynamic
{
    public class SquareSubmatrix
    {
        [Test]
        public void Test1()
        {
            bool[,] arr = new bool[3,4];

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = true;

            arr[0, 0] = false;
            arr[0, 2] = false;
            arr[0, 3] = false;
            arr[2, 0] = false;
            arr[2, 3] = false;

            Assert.That(SquareSubmatrixFunc(arr), Is.EqualTo(2));
        }


        public int SquareSubmatrixFunc(bool[,] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j]) max = Math.Max(max, SquareSubmatrixFunc(arr, i, j));

            return max;
        }

        private int SquareSubmatrixFunc(bool[,] arr, int i, int j)
        { 
            if (i == arr.GetLength(0) || j == arr.GetLength(1)) return 0;

            if (!arr[i, j]) return 0;

            int right = SquareSubmatrixFunc(arr, i, j + 1);
            int bottom = SquareSubmatrixFunc(arr, i + 1, j);
            int bottomRight = SquareSubmatrixFunc(arr, i + 1, j + 1);

            int result = Math.Min(right, bottom);
            return 1 + Math.Min(result, bottomRight);
        }

    }
}
