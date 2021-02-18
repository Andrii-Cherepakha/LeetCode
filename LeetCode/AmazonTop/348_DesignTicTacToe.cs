using System;

namespace LeetCode.AmazonTop
{
    public class TicTacToe
    {

        /** Initialize your data structure here. */
        public TicTacToe(int n)
        {
            size = n;
            columns = new int[n];
            rows = new int[n];
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            int amendment = player == 1 ? 1 : -1;

            columns[col] += amendment;
            rows[row] += amendment;

            if (row == col) diag1 += amendment;
            if (row + col == size - 1) diag2 += amendment;

            if (Math.Abs(rows[row]) == size ||
               Math.Abs(columns[col]) == size ||
               Math.Abs(diag1) == size ||
               Math.Abs(diag2) == size)
            {
                return player;
            }

            return 0;
        }

        private int[] columns;
        private int[] rows;
        private int diag1;
        private int diag2;
        private int size;
    }
}
