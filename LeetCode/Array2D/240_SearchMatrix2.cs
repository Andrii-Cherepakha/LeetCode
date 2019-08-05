namespace LeetCode.Array2D
{
    public class SearchMatrix2
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null)
            {
                return false;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int r = 0;
            int c = m - 1;

            while (r <= n - 1 && c >= 0)
            {
                if (matrix[r, c] > target)
                {
                    c--;
                }
                else if (matrix[r, c] < target)
                {
                    r++;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public bool SearchMatrix1(int[,] matrix, int target)
        {
            if (matrix == null)
            {
                return false;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int r = 0;
            int c = m - 1;

            while (r <= n - 1 && c >= 0)
            {
                if (matrix[r, c] == target)
                {
                    return true;
                }
                else if (matrix[r, c] > target)
                {
                    c--;
                }
                else // < target
                {
                    r++;
                }
            }

            return false;
        }
    }
}