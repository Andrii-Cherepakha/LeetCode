using NUnit.Framework;
using System;

namespace LeetCode.Arrays
{
    class _718_MaximumLengthofRepeatedSubarray
    {
        [Test]
        public void Test()
        {
            var A = new int[] { 1, 2, 3, 2, 1 };
            var B = new int[] { 3, 2, 1, 4, 7 };
            //FindLength(A,B);
        }

        public int FindLength_dp(int[] A, int[] B)
        {
            int max = 0;
            int[,] memo = new int[A.Length + 1, B.Length + 1];

            for (int i = A.Length - 1; i >=0 ; i--)
            {
                for (int j = B.Length - 1; j >= 0; j--)
                {
                    if (A[i] == B[j])
                    {
                        memo[i,j] = memo[i + 1,j + 1] + 1;
                        if (max < memo[i,j]) max = memo[i,j];
                    }
                }
            }

            return max;
        }

        public int FindLength_LeetCode_TimeLimitExceeded(int[] A, int[] B) 
        {
            int max = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    int k = 0;
                    while (i + k < A.Length && j + k < B.Length && A[i + k] == B[j + k])
                    {
                        k++;
                    }

                    max = Math.Max(max, k);
                }
            }

            return max;
        }

        public int FindLength_TimeLimitExceeded(int[] A, int[] B) // 	Time Limit Exceeded
        {
            int max = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    if (B[j] != A[i]) continue;

                    int startB = j + 1;
                    int startA = i + 1;
                    int length = 1;

                    while (startA < A.Length && startB < B.Length && A[startA] == B[startB])
                    {
                        length++;
                        startA++;
                        startB++;
                    }

                    max = Math.Max(max, length);
                }
            }

            return max;
        }
    }
}
