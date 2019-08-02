namespace LeetCode.Array2D
{
    public class GameOfLifeSolution
    {

        public void GameOfLife(int[][] board)
        {
            if (board == null || board.Length == 0)
            {
                return;
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    board[i][j] = GetNextState(board, i,j);
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == ZeroBecomesOne) board[i][j] = 1;
                    if (board[i][j] == OneBecomesZero) board[i][j] = 0;
                }
            }
        }

        private int GetNextState(int[][] board, int i, int j)
        {
            int r = board.Length - 1;
            int c = board[0].Length - 1;

            // 1 2 3
            // 4 * 5
            // 6 7 8
            int countOfOnes = 0;

            if (i > 0 && j > 0 && (board[i - 1][j - 1] == 1 || board[i - 1][j - 1] == OneBecomesZero)) // 1
            {
                countOfOnes++;
            }

            if (i > 0 && (board[i - 1][j] == 1 || board[i - 1][j] == OneBecomesZero)) // 2
            {
                countOfOnes++;
            }

            if (i > 0 && j < c && (board[i - 1][j + 1] == 1 || board[i - 1][j + 1] == OneBecomesZero)) // 3
            {
                countOfOnes++;
            }

            if(j > 0 && (board[i][j - 1] == 1 || board[i][j - 1] == OneBecomesZero)) // 4
            {
                countOfOnes++;
            }

            if(j < c && (board[i][j + 1] == 1 || board[i][j + 1] == OneBecomesZero)) // 5
            {
                countOfOnes++;
            }

            if(i < r && j > 0 && (board[i + 1][j - 1] == 1 || board[i + 1][j - 1] == OneBecomesZero)) // 6
            {
                countOfOnes++;
            }

            if(i < r && (board[i + 1][j] == 1 || board[i + 1][j] == OneBecomesZero)) // 7
            {
                countOfOnes++;
            }

            if(i < r && j < c && (board[i + 1][j + 1] == 1 || board[i + 1][j + 1] == OneBecomesZero)) // 8
            {
                countOfOnes++;
            }

            // -------------------
            if (countOfOnes < 2 && board[i][j] == 1)
            {
                return  OneBecomesZero;
            }
            if ((countOfOnes == 2 || countOfOnes == 3) && board[i][j] == 1)
            {
                return board[i][j]; // 1
            }
            if (countOfOnes > 3 && board[i][j] == 1)
            {
                return OneBecomesZero;
            }
            if (countOfOnes == 3 && board[i][j] == 0)
            {
                return ZeroBecomesOne;
            }

            return board[i][j];
        }

        private const int ZeroBecomesOne = 5;
        private const int OneBecomesZero = 7;
    }
}