using NUnit.Framework;

namespace LeetCode.Arrays
{
    class RotateArray
    {
        [Test]
        public void Example1()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void Example2()
        {
            int[] nums = { -1, -100, 3, 99 };
            int k = 2;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void TestEmpty()
        {
            int[] nums = { };
            int k = 0;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void TestKLength()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 7;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void Test1()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 1;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void Test2()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 2;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void Test3()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void Test4()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 4;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void Test5()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 5;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void Test6()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 6;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void Test1k5()
        {
            int[] nums = { 1 };
            int k = 5;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void Test2k1()
        {
            int[] nums = { 1, 2 };
            int k = 1;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void TestWrong()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6 };
            int k = 4;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        public void Rotate(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            while (k >= nums.Length) // k > length
            {
                k = k - nums.Length;
            }

            if (k == 0) // k = length
            {
                return;
            }

            int storage = 0;
            int i = k;

            while (i < nums.Length) // O(N)
            {
                if (storage == k)
                {
                    storage = 0;
                }

                int tmp = nums[i];
                nums[i] = nums[storage];
                nums[storage] = tmp;

                i++;
                storage++;
            }

            if (nums.Length % k == 0)
            {
                return; // no need to deal with the reminder [0 .. k]
            }

            // remainder [0 .. k] is not sorted as needed
            i = 0;
            while (storage < k)  // O(k)
            {
                int tmp = nums[storage];
                nums[storage] = nums[i];
                nums[i] = tmp;

                i++;
                storage++;
                //if (storage == k)
                //{
                //    storage = k - 1;
                //}                
            }

        }
    }
}
