using NUnit.Framework;

namespace LeetCode.Arrays
{
    class RotateImage
    {

        [Test]
        public void Test1()
        {
            //int[][] matrix = { new int[] { 1, 2, 3}, new int[] { 4, 5, 6}, new int[] { 7, 8, 9} };

            //int[][] matrix = {
            //    new int[] { 2,29,20,26,16,28 },
            //    new int[] { 12,27,9,25,13,21 },
            //    new int[] { 32,33,32,2,28,14 },
            //    new int[] { 13,14,32,27,22,26 },
            //    new int[] { 33,1,20,7,21,7 },
            //    new int[] { 4,24,1,6,32,34 } };

            int[][] matrix = {
                new int[] { 1,2,3,4,5,6 },
                new int[] { 7,8,9,10,11,12 },
                new int[] { 13,14,15,16,17,18 },
                new int[] { 19,20,21,22,23,24 },
                new int[] { 25,26,27,28,29,30 },
                new int[] { 31,32,33,34,35,36 } };

            Rotate(matrix);
        }

        public void Rotate(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return;
            }

            int start = 0;
            int end = matrix.Length - 1;

            while (start < end)
            {
                for (int i = 0; i < end - start; ++i)
                {
                    int tmp = matrix[start][start + i];                
                    matrix[start][start + i] = matrix[end - i][start]; 
                    matrix[end - i][start] = matrix[end][end - i];     
                    matrix[end][end - i] = matrix[start + i][end];     
                    matrix[start + i][end] = tmp;                      
                }
                start++;
                end--;
            }
        }
    }
}
