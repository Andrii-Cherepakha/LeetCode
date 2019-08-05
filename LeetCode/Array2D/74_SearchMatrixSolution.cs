
namespace LeetCode.Array2D
{
    public class SearchMatrixSolution
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0)
            {
                return false;
            }

            int start;
            int end;
            int row = -1;

            // find a row
            if (target < matrix[0][0])
            {
                return false;
            }
            else if (target >= matrix[matrix.Length - 1][0])
            {
                row = matrix.Length - 1;
            }
            else // binary search through rows
            {
                start = 0;
                end = matrix.Length - 1;
                while (start <= end)
                {
                    int position = start + (end - start) / 2;
                    if (matrix[position][0] == target)
                    {
                        return true;
                    }
                    else if (matrix[position][0] > target)
                    {
                        end = position - 1;
                    }
                    else // matrix[position][0] < target
                    {
                        start = position + 1;
                    }
                }

                row = end;
            }
            
            // binary search through columns in the row
            if (target > matrix[row][matrix[row].Length - 1])
            {
                return false;
            }

            start = 0;
            end = matrix[row].Length - 1;
            while (start <= end)
            {
                int position = start + (end - start) / 2;
                if (matrix[row][position] == target)
                {
                    return true;
                }
                else if (matrix[row][position] > target)
                {
                    end = position - 1;
                }
                else // matrix[row][position] < target
                {
                    start = position + 1;
                }
            }

            return false;
        }
    }
}