using System;
using LeetCode.Arrays;
using NUnit.Framework;

namespace LeetCode.BinarySearch
{
    class FindMinimumInRotatedSortedArrayDuplicates
    {
        [Test]
        public void Example1()
        {
            int[] nums = {1, 3, 5};
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int[] nums = {2, 2, 2, 0, 1};
            int expected = 0;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            int[] nums = {2, 2, 2, 0, 1, 2};
            int expected = 0;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            int[] nums = {1};
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            int[] nums = {1, 1};
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test31()
        {
            int[] nums = {1, 2, 1};
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            int[] nums = {3, 3, 3, 4, 4, 4, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3};
            int expected = 0;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            int[] nums = {1, 2};
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test6()
        {
            int[] nums = {2, 1};
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test7()
        {
            int[] nums = {1, 1, 2, 2};
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        //[Test]
        public void Test8()
        {
            int[] nums = {2, 2, 1, 1};
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        //[Test]
        public void Test9()
        {
            int[] nums = {2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        //[Test]
        public void Test10()
        {
            int[] nums = {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1};
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test11()
        {
            int[] nums = {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2};
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test12()
        {
            int[] nums = {2, 2, 2, 1, 2, 2, 2};
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test13()
        {
            int[] nums = {1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1};
            int expected = 0;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test14()
        {
            int[] nums = { 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 };
            int expected = 0;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test15()
        {
            int[] nums = { 10, 1, 10, 10, 10 };
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test16()
        {
            int[] nums = { 10, 10, 10, 1, 10 };
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test17()
        {
            int[] nums = { 1, 1, 3, 1 }; // Incorrect pivot
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        public int FindMin(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return int.MinValue;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            if (nums[0] < nums[nums.Length - 1]) // no rotation
            {
                return nums[0];
            }

            int pe = FindPivot(nums);
            ArrayHelper.PrintArray(nums);
            Console.WriteLine($"\nPivot from end   : {nums[pe]} at {pe}");

            return nums[FindPivot(nums)];
        }

        private int FindPivot(int[] nums) // array can contain duplicates
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                int position = start + (end - start) / 2;
                if (nums[position] > nums[end])
                {
                    start = position + 1;
                }
                else if (nums[position] < nums[end])
                {
                    end = position;
                }
                else
                {
                    end--; // since comparison is done with nums[end]
                }
            }

            return start;
        }

        // DOES NOT WORK
        private int FindPivotFromStart(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                int position = start + (end - start) / 2;
                if (nums[position] > nums[start])
                {
                    start = position + 1;
                }
                else if (nums[position] < nums[start])
                {
                    end = position;
                }
                else
                {
                    start++; // since comparison is done with nums[start]
                }
            }

            return start;
        }
    }
}