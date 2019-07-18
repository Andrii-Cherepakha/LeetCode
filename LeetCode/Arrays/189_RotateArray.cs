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

        [Test]
        public void Test7()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            int k = 4;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void Test8()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6 };
            int k = 4;
            ArrayHelper.PrintArray(nums);
            Rotate(nums, k);
            ArrayHelper.PrintArray(nums);
        }

        [Test]
        public void Test9()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
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

            int storage = 0; // storage means first k elements
            int i = k; // first position for rotation

            // 1 2 3 ... k 10 11 12 .... N
            // 1) put k    element into 0 position
            //    put k+1  element into 1 position
            //    put k+2  element into 2 position
            // and so on till we meat k position
            // once k position is reached, reset counter to 0
            // repeat till the ned of the array
            // Example:
            // s       i
            // 1 2 3 4 5 6 7 8 9 10 11 12   k = 4
            // s               i
            // 5 6 7 8 1 2 3 4 9 10 11 12  - once k position reached first time
            // s                          i
            // 9 10 11 12 1 2 3 4 5 6 7 8  - once k position reached second time

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

            // if k multiple array length no need to do any additional steps 
            if (nums.Length % k == 0)
            {
                return; // no need to deal with the reminder [0 .. k]
            }

            // remainder [0 .. k] is not sorted as needed
            // Otherwise there can be several cases:
            // Example: k = 4
            // case 1            case 2            case 3
            // 1 2 3 4 5         1 2 3 4 5 6       1 2 3 4 5 6 7
            // after previous loop:
            //   s                   s                   s
            // 5 2 3 4 1         5 6 3 4 1 2       5 6 7 4 1 2 3
            // we need to move all elements starting from s position to the left up to 0 position
            // each time an element is moved, increase position
            // 5 2 3 4           5 6 3 4           5 6 7 4 
            // 2 5                 3 6                 4 7 
            //   3 5             3 5                 4 6
            //     4 5               4 6           4 5
            //                     4 5             
            // 2 3 4 5           3 4 5 6           4 5 6 7


            int position = 0;
            while (storage < k) // O(k)
            {
                i = storage; // start with s
                while (i - 1 >= position) // while the left is not reached
                {
                    int tmp = nums[i];  // swap
                    nums[i] = nums[i - 1];
                    nums[i - 1] = tmp;
                    i--;  // and move to the left
                }

                storage++;  // go to the next element
                position++; // that will be placed in left + 1 position
            }
        }
    }
}
