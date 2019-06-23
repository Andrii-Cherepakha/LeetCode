using NUnit.Framework;
using System;

namespace LeetCode.Arrays
{
    class FirstMissingPositiveSolution
    {

        [Test]
        public void Test3()
        {
            var nums = new int[] { 1, 2, 0 };
            int expected = 3;
            int actual = FirstMissingPositive(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            var nums = new int[] { -1, -2, 0 };
            int expected = 1;
            int actual = FirstMissingPositive(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 3, 4, -1, 1 };
            int expected = 2;
            int actual = FirstMissingPositive(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            var nums = new int[] { 7, 8, 9, 11, 12 };
            int expected = 1;
            int actual = FirstMissingPositive(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            var nums = new int[] { 4, 6, 1, 2, 3 };
            int expected = 5;
            int actual = FirstMissingPositive(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test7()
        {
            var nums = new int[] { 4, 6, 1, 2, 3, 5 };
            int expected = 7;
            int actual = FirstMissingPositive(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test8()
        {
            var nums = new int[] { -10, -22, -20 };
            int expected = 1;
            int actual = FirstMissingPositive(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test0()
        {
            var nums = new int[] { 0 };
            int expected = 1;
            int actual = FirstMissingPositive(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test9()
        {
            var nums = new int[] { -200, 1, 3, 5, 100 };
            int expected = 2;
            int actual = FirstMissingPositive(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestNo()
        {
            var nums = new int[] { };
            int expected = 1;
            int actual = FirstMissingPositive(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void TestMax()
        {
            var nums = new int[] { int.MinValue, int.MaxValue, 1, 3, 5, 100 };
            int expected = 2;
            int actual = FirstMissingPositive(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }

        public int FirstMissingPositive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 1;
            }

            int i = 0;
            while (i < nums.Length)
            {
                // idea: put the number on its position in the array if
                // 1. positive integer only
                // 2. number can be put (less than array length)
                // 3. do not do if the number already on its position (avoid infinite loop)
                if (nums[i] > 0 && nums[i] <= nums.Length && nums[i] != nums[nums[i] - 1])
                {
                    // swap values
                    int temp = nums[i];
                    nums[i] = nums[nums[i] - 1];
                    nums[temp - 1] = temp; // do not use nums[nums[j] - 1] = temp; since nums[j] is already changed

                    // still, need to check the value that was swapped
                    continue;
                }
                i++;
            }

            // find
            for (i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            return nums.Length + 1;
        }

        private void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
        

        public int FirstMissingPositiveOutOfMemory(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 1;
            }

            int max = nums[0];

            // 1. find min and max O(N)
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    max = Math.Max(max, nums[i]);
                }
            }

            max = Math.Max(0, max);

            int[] extra = new int[max]; // out of memory

            // 2. init existing elements
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    extra[nums[i] - 1] = 1;
                }
            }

            // 3 return first missing
            int position;
            for (position = 0; position < extra.Length; position++)
            {
                if (extra[position] == 0)
                {
                    return ++position;
                }
            }

            return ++position;
        }



    }
}