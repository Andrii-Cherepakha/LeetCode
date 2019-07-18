namespace LeetCode.Arrays
{
    public class RotateArrayLeetCode
    {


        public void Rotate(int[] nums, int k)
        {
            // Idea: reverse initial array, then reverse each part
            k %= nums.Length; // if k > nums.Length

            // Original List:                             1 2 3 | 4 5 6 7
            // 1. Revers initial array:                   7 6 5 | 4 3 2 1
            Reverse(nums, 0, nums.Length - 1);
            // 2. Revers first k numbers                  5 6 7 | 4 3 2 1
            Reverse(nums, 0, k - 1);
            // 3. Revers last n - k numbers               5 6 7 | 1 2 3 4
            Reverse(nums, k, nums.Length - 1);
        }

        public void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int tmp = nums[end];
                nums[end] = nums[start];
                nums[start] = tmp;
                start++;
                end--;
            }
        }
    }
}