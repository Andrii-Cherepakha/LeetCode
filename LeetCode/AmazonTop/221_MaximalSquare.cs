using System;

namespace LeetCode.AmazonTop
{
    class _221_MaximalSquare
    {
        public int MaximalSquare_dp(char[][] matrix)
        {

            int m = matrix.Length;
            int n = matrix[0].Length;

            int[,] dp = new int[m + 1, n + 1];

            max = 0;

            for (int i = 1; i <= m; i++)
                for (int j = 1; j <= n; j++)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i, j - 1], dp[i - 1, j])) + 1;
                        max = Math.Max(dp[i, j], max);
                    }
                }

            return max * max;
        }

        private int max;

        public int MaximalSquare(char[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            max = 0;

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        max = Math.Max(max, 1);
                        MaximalSquare(matrix, i, i + 1, j, j + 1);
                    }
                }

            return max;
        }



        public void MaximalSquare(char[][] matrix, int r1, int r2, int c1, int c2)
        {
            if (r2 >= matrix.Length || c2 >= matrix[0].Length)
                return;

            bool all1 = true;

            for (int i = r1; i <= r2; i++)
                for (int j = c1; j <= c2; j++)
                {
                    if (matrix[i][j] == '0')
                    {
                        all1 = false;
                        break;
                    }
                }

            if (all1)
            {
                max = Math.Max(max, (r2 - r1 + 1) * (c2 - c1 + 1));
                MaximalSquare(matrix, r1, r2 + 1, c1, c2 + 1);
            }
        }
    }
}
