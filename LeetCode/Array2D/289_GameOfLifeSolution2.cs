
namespace LeetCode.Array2D
{
    public class GameOfLifeSolution2
    {
        public void GameOfLife(int[][] board)
        {
            if (board == null || board[0].Length == 0)
            {
                return;
            }

            RowsCount = board.Length;
            ColumnsCount = board[0].Length;

            for (int row = 0; row < RowsCount; row++)
            {
                for (int col = 0; col < ColumnsCount; col++)
                {
                    UpdateToNextState(board, row, col);
                }
            }

            for (int row = 0; row < RowsCount; row++)
            {
                for (int col = 0; col < ColumnsCount; col++)
                {
                    if (board[row][col] == ZeroToOne)
                    {
                        board[row][col] = 1;
                    }
                    if (board[row][col] == OneToZero)
                    {
                        board[row][col] = 0;
                    }
                }
            }
        }

        private void UpdateToNextState(int[][] board, int r, int c)
        {
            /* 
                1 2 3
                4 * 5
                6 7 8
             */

            // Get live neighbors
            int live = 0;

            if (r > 0 && c > 0 && (board[r - 1][c - 1] == 1 || board[r - 1][c - 1] == OneToZero)) // 1
            {
                live++;
            }

            if (r > 0 && (board[r - 1][c] == 1 || board[r - 1][c] == OneToZero)) // 2
            {
                live++;
            }

            if (r > 0 && c < ColumnsCount - 1 && (board[r - 1][c + 1] == 1 || board[r - 1][c + 1] == OneToZero)) // 3
            {
                live++;
            }

            if (c > 0 && (board[r][c - 1] == 1 || board[r][c - 1] == OneToZero)) // 4
            {
                live++;
            }

            if (c < ColumnsCount - 1 && (board[r][c + 1] == 1 || board[r][c + 1] == OneToZero)) // 5
            {
                live++;
            }

            if (r < RowsCount - 1 && c > 0 && (board[r + 1][c - 1] == 1 || board[r + 1][c - 1] == OneToZero)) // 6
            {
                live++;
            }

            if (r < RowsCount - 1 && (board[r + 1][c] == 1 || board[r + 1][c] == OneToZero)) // 7
            {
                live++;
            }

            if (r < RowsCount - 1 && c < ColumnsCount - 1 && (board[r + 1][c + 1] == 1 || board[r + 1][c + 1] == OneToZero)) // 8
            {
                live++;
            }

            // rules
            // 1. Any live cell with fewer than two live neighbors dies as if caused by under-population.
            if (board[r][c] == 1 && live < 2)
            {
                board[r][c] = OneToZero;
            }
            // 2. Any live cell with two or three live neighbors lives on to the next generation.
            /*
            if (board[r][c] == 1 && (live == 2 || live == 3))
            {
                board[r][c] = 1;
            }
            */
            // 3. Any live cell with more than three live neighbors dies, as if by over-population.
            if (board[r][c] == 1 && live > 3)
            {
                board[r][c] = OneToZero;
            }
            // 4. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
            if (board[r][c] == 0 && live == 3)
            {
                board[r][c] = ZeroToOne;
            }
        }

        private int ColumnsCount;
        private int RowsCount;

        private const int ZeroToOne = 2;
        private const int OneToZero = 3;
    }
}
