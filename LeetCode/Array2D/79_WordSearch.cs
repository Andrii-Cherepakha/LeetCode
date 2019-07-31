using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.Array2D
{
    public class WordSearch
    {
        [Test]
        public void Example1()
        {
            char[][] board =
            {
                new [] {'A','B','C','E'},
                new [] {'S','F','C','S'},
                new [] {'A','D','E','E'},
            };

            string word = "ABCCED";
            bool expected = true;
            Assert.That(Exist(board, word), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            char[][] board =
            {
                new [] {'A','B','C','E'},
                new [] {'S','F','C','S'},
                new [] {'A','D','E','E'},
            };

            string word = "SEE";
            bool expected = true;
            Assert.That(Exist(board, word), Is.EqualTo(expected));
        }

        [Test]
        public void Example3()
        {
            char[][] board =
            {
                new [] {'A','B','C','E'},
                new [] {'S','F','C','S'},
                new [] {'A','D','E','E'},
            };

            string word = "ABCB";
            bool expected = false;
            Assert.That(Exist(board, word), Is.EqualTo(expected));
        }

        [Test]
        public void Example4()
        {
            char[][] board =
            {
                new [] {'C','A','A'},
                new [] {'A','A','A'},
                new [] {'B','C','D'},
            };

            string word = "AAB";
            bool expected = true;
            Assert.That(Exist(board, word), Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            char[][] board =
            {
                new [] {'A','A','A','A'},
                new [] {'A','A','A','A'},
                new [] {'A','A','A','A'},
            };

            string word = "AAAAAAAAAAA";
            bool expected = true;
            Assert.That(Exist(board, word), Is.EqualTo(expected));
        }

        public bool Exist(char[][] board, string word) 
        {
            if (board == null || board[0] == null)
            {
                return false;
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (Exist(board, i, j, word, 0))
                        return true;
                }
            }

            return false;
        }

        private bool Exist(char[][] board, int i, int j, string word, int charPosition)
        {
            if (charPosition == word.Length) return true;

            if (i < 0 || j < 0 || i >= board.Length || j >= board[0].Length || board[i][j] != word[charPosition])
            {
                return false;
            }

            board[i][j] = '-';

            bool exist = Exist(board, i - 1, j, word, charPosition + 1) // top
                      || Exist(board, i + 1, j, word, charPosition + 1) // bottom
                      || Exist(board, i, j - 1, word, charPosition + 1) // left
                      || Exist(board, i, j + 1, word, charPosition + 1) // right
                ;

            board[i][j] = word[charPosition];

            return exist;
        }


        #region Time limit

        public bool ExistTimeLimit(char[][] board, string word) // time limit
        {
            if (board == null || board[0] == null)
            {
                return false;
            }

            int n = board[0].Length;
            int m = board.Length;
            char firstChar = word[0];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == firstChar)
                    {
                        var spots = new List<int[]>();
                        spots.Add(new []{i, j});
                        var exists = WordExists(spots, board, word, 1);

                        if (exists)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool WordExists(List<int[]> spots, char[][] board, string word, int charPosition)
        {
            if (spots.Count == 0)
            {
                return false;
            }

            if (charPosition >= word.Length)
            {
                return true;
            }

            bool exists = false;
            foreach (var spot in spots)
            {
                char tmp = board[spot[0]][spot[1]];
                board[spot[0]][spot[1]] = '-';
                var newSpots = ExistInAdjacentCell(spot[0], spot[1], board, word[charPosition]);
                if (WordExists(newSpots, board, word, charPosition + 1))
                {
                    exists = true;
                }
                board[spot[0]][spot[1]] = tmp;
            }

            return exists;
        }

        private List<int[]> ExistInAdjacentCell(int i, int j, char[][] board, char ch)
        {
            List<int[]> spots = new List<int[]>();
            
            if (i-1 >= 0 && board[i-1][j] == ch) spots.Add(new[] { i - 1, j });// top
            if (i + 1 < board.Length && board[i + 1][j] == ch) spots.Add(new[] { i + 1, j });// bottom
            if (j - 1 >= 0 && board[i][j-1] == ch) spots.Add(new[] { i, j-1 }); //left
            if (j + 1 < board[i].Length && board[i][j + 1] == ch) spots.Add(new[] { i, j + 1 }); // right
            return spots;
        }
        
        #endregion
    }
}