using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCode.AmazonTop
{
    class _1091_ShortestPathinBinaryMatrix
    {
        [Test]
        public void Test()
        {
            int[][] grid = new int[][] { new int[] { 0, 1 }, new int[] { 1,0 } };
            ShortestPathBinaryMatrix(grid);
        }

        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0
                || grid[0][0] == 1
                || grid[grid.Length - 1][grid[grid.Length - 1].Length - 1] == 1) // N * N
                return -1;

            var queue = new Queue<int[]>();

            queue.Enqueue(new int[] { 0, 0, 1 }); // row, column, distance

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();

                int r = cell[0];
                int c = cell[1];
                int d = cell[2];

                if (r < 0 || c < 0 || r >= grid.Length || c >= grid[0].Length || grid[r][c] == 1)
                    continue;

                if (r == grid.Length - 1 && c == grid[0].Length - 1)
                {
                    return d;
                }

                grid[r][c] = 1;

                queue.Enqueue(new int[] { r - 1, c - 1, d + 1 });
                queue.Enqueue(new int[] { r - 1, c, d + 1 });
                queue.Enqueue(new int[] { r - 1, c + 1, d + 1 });

                queue.Enqueue(new int[] { r, c - 1, d + 1 });
                queue.Enqueue(new int[] { r, c + 1, d + 1 });

                queue.Enqueue(new int[] { r + 1, c - 1, d + 1 });
                queue.Enqueue(new int[] { r + 1, c, d + 1 });
                queue.Enqueue(new int[] { r + 1, c + 1, d + 1 });
            }

            return -1;
        }
    }
}
