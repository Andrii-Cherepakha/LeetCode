using System;

namespace LeetCode.Array2D
{
    class _1091_ShortestPathinBinaryMatrix
    {
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            //int shortest = -1;
            if (grid == null || grid.Length == 0 || grid[0].Length == 0 
                || grid[0][0] == 1
                || grid[grid.Length - 1][grid[grid.Length - 1].Length - 1] == 1) // N * N
                return -1;

            ShortestPathBinaryMatrix(grid, 0, 0, 0);

            return shortest == int.MaxValue ? -1 : shortest;
        }

        private int shortest = int.MaxValue;

        private void ShortestPathBinaryMatrix(int[][] grid, int i, int j, int length) // time limit
        {
            //if (i >= grid.Length || j >= grid.Length) return;

            length++;

            if (i == grid.Length - 1 && j == grid.Length - 1)
            {
                shortest = Math.Min(shortest, length);
            }

            grid[i][j] = 1;

            if (j+1 < grid.Length && grid[i][j+1] == 0) 
                ShortestPathBinaryMatrix(grid, i, j + 1, length);

            if(j-1 > 0 && grid[i][j - 1] == 0)
                ShortestPathBinaryMatrix(grid, i, j - 1, length);

            if (i + 1 < grid.Length && grid[i + 1][j] == 0) 
                ShortestPathBinaryMatrix(grid, i + 1, j, length);

            if (i - 1 > 0 && grid[i - 1][j] == 0)
                ShortestPathBinaryMatrix(grid, i - 1, j, length);

            if (i+1 < grid.Length && j+1 < grid.Length && grid[i + 1][j + 1] == 0) 
                ShortestPathBinaryMatrix(grid, i + 1, j + 1, length);

            if (i - 1 > 0 && j - 1 > 0 && grid[i - 1][j - 1] == 0)
                ShortestPathBinaryMatrix(grid, i - 1, j - 1, length);

            if (i - 1 > 0 && j + 1 < grid.Length && grid[i - 1][j + 1] == 0)
                ShortestPathBinaryMatrix(grid, i - 1, j + 1, length);

            if (i + 1 < grid.Length && j - 1 > 0 && grid[i + 1][j - 1] == 0)
                ShortestPathBinaryMatrix(grid, i + 1, j - 1, length);

            grid[i][j] = 0;
        }
    }
}
