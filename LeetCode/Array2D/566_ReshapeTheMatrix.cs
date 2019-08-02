namespace LeetCode.Array2D
{
    public class ReshapeTheMatrix
    {


        public int[][] MatrixReshape(int[][] nums, int r, int c)
        {
            if (nums == null || nums.Length == 0 || nums[0].Length == 0 
                || nums.Length * nums[0].Length != r * c
                || (nums.Length == r && nums[0].Length == c))
            {
                return nums;
            }

            int row = 0;
            int col = 0;
            int[][] newNums = new int[r][];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[0].Length; j++)
                {
                    if (newNums[row] == null)
                    {
                        newNums[row] = new int[c];
                    }

                    newNums[row][col] = nums[i][j];

                    col++;
                    if (col == c)
                    {
                        col = 0;
                        row++;
                    }
                }
            }

            return newNums;
        }
    }
}