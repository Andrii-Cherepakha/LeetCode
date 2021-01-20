using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCode.Array2D
{
    class PalindromicPaths
    {

        [Test]
        public void Test1()
        {
            char[][] matrix = new char[][]
            {
                new char[] {'a', 'a', 'a', 'b'},
                new char[] {'b', 'a', 'a', 'a'},
                new char[] {'a', 'b', 'b', 'a'}
            };

            var result = PalindromicPath(matrix);
        }

        [Test]
        public void Test2()
        {
            char[][] matrix = new char[][]
            {
                new char[] {'a', 'a'},
                new char[] {'b', 'a'}
            };

            var result = PalindromicPath(matrix);
        }

        [Test]
        public void Test3()
        {
            char[][] matrix = new char[][]
            {
                new char[] {'a'}
            };

            var result = PalindromicPath(matrix);
        }


        public List<string> PalindromicPath(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return result;

            PalindromicPath(matrix, 0, 0, "");

            return result;
        }

        private void PalindromicPath(char[][] matrix, int i, int j, string path)
        {
            if (i >= matrix.Length || j >= matrix[0].Length) return;

            path = path + matrix[i][j];

            if (i == matrix.Length - 1 && j == matrix[0].Length - 1)
            {
                if (IsPalindrom(path))
                {
                    result.Add(path);
                }
                return;
            }

            PalindromicPath(matrix, i, j + 1, path);
            PalindromicPath(matrix, i + 1, j, path);
        }

        private bool IsPalindrom(string path)
        {
            int start = 0;
            int end = path.Length - 1;

            while (start < end)
            {
                if (path[start] != path[end]) return false;
                start++;
                end--;
            }

            return true;
        }

        private List<string> result = new List<string>();
    }
}