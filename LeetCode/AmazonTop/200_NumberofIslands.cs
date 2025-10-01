
namespace LeetCode.AmazonTop
{
    // also can be solved with the Union Find (Disjoint Set Union) approach 
    class _200_NumberofIslands
    {
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;

            int m = grid.Length;
            int n = grid[0].Length;

            int numIslands = 0;

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        numIslands++;
                        NumIslands(grid, i, j);
                    }
                }

            return numIslands;
        }

        private void NumIslands(char[][] grid, int i, int j)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == '0') return;

            grid[i][j] = '0';

            NumIslands(grid, i - 1, j);
            NumIslands(grid, i + 1, j);
            NumIslands(grid, i, j - 1);
            NumIslands(grid, i, j + 1);
        }
    }
}
