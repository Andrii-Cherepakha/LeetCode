using System;

namespace LeetCode.Array2D
{
    class _1672_RichestCustomerWealth
    {
        public int MaximumWealth(int[][] accounts)
        {
            int max = int.MinValue;

            for (int i = 0; i < accounts.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < accounts[i].Length; j++)
                {
                    sum += accounts[i][j];
                }

                max = Math.Max(max, sum);
            }

            return max;
        }
    }
}
