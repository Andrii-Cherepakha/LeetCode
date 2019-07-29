using System.Collections.Generic;

namespace LeetCode.Array2D
{
    class ValidSudoku
    {        
        public bool IsValidSudoku(char[][] board) // N*N
        {
            Dictionary<string, int> storage = new Dictionary<string, int>();

            for (int i = 0; i <= 8; i++)
                for (int j = 0; j <= 8; j++)
                {
                    if (board[i][j] == '.') continue;

                    string row = $"{i}-{board[i][j]}";
                    if (storage.ContainsKey(row)) return false;

                    string column = $"{j}|{board[i][j]}";
                    if (storage.ContainsKey(column)) return false;

                    int b = j / 3 + i / 3 * 3;
                    string box = $"{b}#{board[i][j]}";
                    if (storage.ContainsKey(box)) return false;

                    storage[row] = 0;
                    storage[column] = 0;
                    storage[box] = 0;
                }

            return true;
        }

        public bool IsValidSudoku1(char[][] board) // 2 * N*N
        {
            if (!IsValidRange(board, 0, 2, 0, 2)) return false; // 1
            if (!IsValidRange(board, 0, 2, 3, 5)) return false; // 2
            if (!IsValidRange(board, 0, 2, 6, 8)) return false; // 3

            if (!IsValidRange(board, 3, 5, 0, 2)) return false; // 4
            if (!IsValidRange(board, 3, 5, 3, 5)) return false; // 5
            if (!IsValidRange(board, 3, 5, 6, 8)) return false; // 6

            if (!IsValidRange(board, 6, 8, 0, 2)) return false; // 7
            if (!IsValidRange(board, 6, 8, 3, 5)) return false; // 8
            if (!IsValidRange(board, 6, 8, 6, 8)) return false; // 9


            for (int i = 0; i <= 8; i++)
            {
                if (!IsValidRange(board, i, i, 0, 8)) return false; // rows
                if (!IsValidRange(board, 0, 8, i, i)) return false; // columns
            }

            return true;
        }

        private bool IsValidRange(char[][] board, int rStart, int rEnd, int cStart, int cEnd)
        {
            Dictionary<char, int> storage = new Dictionary<char, int>();

            for (int i = rStart; i <= rEnd; i++)
                for (int j = cStart; j <= cEnd; j++)
                {
                    if (board[i][j] == '.') continue;
                    if (storage.ContainsKey(board[i][j]))
                    {
                        return false;
                    }
                    storage[board[i][j]] = 0;
                }

            return true;
        }
    }
}