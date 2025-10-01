namespace LeetCode.Dropbox
{
    public class NumIslands
    {
        public int NumIslands1(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }

            int n = grid.Length;
            int m = grid[0].Length;

            int islands = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        islands++;
                        check(grid, i, j);
                    }
                }
            }

            return islands;
        }

        private void check(char[][] grid, int n, int m)
        {
            if (n < 0 || m < 0 || n >= grid.Length || m >= grid[0].Length || grid[n][m] == '0') return;

            grid[n][m] = '0';

            check(grid, n - 1, m);
            check(grid, n + 1, m);
            check(grid, n, m - 1);
            check(grid, n, m + 1);
        }
    }
}
