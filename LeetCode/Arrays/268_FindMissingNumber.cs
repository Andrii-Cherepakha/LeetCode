namespace LeetCode.Arrays
{
    public class FindMissingNumber
    {
        public int MissingNumber(int[] nums)
        {
            long expectedSum = nums.Length * (nums.Length + 1) / 2;

            long actualSum = 0;
            foreach (var num in nums)
            {
                actualSum = actualSum + num;
            }

            return (int)(expectedSum - actualSum);
        }
    }
}