
// #sort

namespace LeetCode.Arrays
{
    class SortColorsSolution
    {

        public void SortColors(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            int[] count = new int[3];

            foreach (int idx in nums)
            {
                count[idx]++;
            }

            int i = 0;
            int j = 0;
            while (i < nums.Length)
            {
                while (j < count.Length && count[j] == 0) j++;
                nums[i] = j;
                i++;
                count[j]--;
            }

            //for (int i = 0; i < count[0]; i++)
            //{
            //    nums[i] = 0;
            //}

            //for (int i = 0; i < count[1]; i++)
            //{
            //    nums[i + count[0]] = 1;
            //}

            //for (int i = 0; i < count[2]; i++)
            //{
            //    nums[i + count[0] + count[1]] = 2;
            //}
        }
    }
}
