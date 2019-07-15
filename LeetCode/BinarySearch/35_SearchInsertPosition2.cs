﻿using NUnit.Framework;

namespace LeetCode.BinarySearch
{
    public class SearchInsertPosition2
    {
        [Test]
        public void Example1()
        {
            int[] nums = { 1, 3, 5, 6 };
            int target = 5;
            int expected = 2;
            Assert.That(SearchInsert(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int[] nums = { 1, 3, 5, 6 };
            int target = 2;
            int expected = 1;
            Assert.That(SearchInsert(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Example3()
        {
            int[] nums = { 1, 3, 5, 6 };
            int target = 7;
            int expected = 4;
            Assert.That(SearchInsert(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Example4()
        {
            int[] nums = { 1, 3, 5, 6 };
            int target = 0;
            int expected = 0;
            Assert.That(SearchInsert(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            int[] nums = { 1, 3, 5, 6 };
            int target = 4;
            int expected = 2;
            Assert.That(SearchInsert(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            int[] nums = { 1 };
            int target = 1;
            int expected = 0;
            Assert.That(SearchInsert(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            int[] nums = { 1 };
            int target = 0;
            int expected = 0;
            Assert.That(SearchInsert(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            int[] nums = { 1 };
            int target = 5;
            int expected = 1;
            Assert.That(SearchInsert(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            int[] nums = { 1 };
            int target = 2;
            int expected = 1;
            Assert.That(SearchInsert(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test6()
        {
            int[] nums = { 1, 3 };
            int target = 2;
            int expected = 1;
            Assert.That(SearchInsert(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test7()
        {
            int[] nums = { 1, 3 };
            int target = 4;
            int expected = 2;
            Assert.That(SearchInsert(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test8()
        {
            int[] nums = { 1, 3 };
            int target = 0;
            int expected = 0;
            Assert.That(SearchInsert(nums, target), Is.EqualTo(expected));
        }

        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int position = start + (end - start) / 2;
                if (nums[position] == target)
                {
                    return position; // found
                }

                if (nums[position] < target)
                {
                    start = position + 1;
                }

                if (nums[position] > target)
                {
                    end = position - 1;
                }
            }

            return start;
        }


        public int SearchInsert2(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int start = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                int position = start + (end - start) / 2;
                if (nums[position] == target)
                {
                    return position; // found
                }

                if (nums[position] < target)
                {
                    start = position + 1;
                }

                if (nums[position] > target)
                {
                    end = position - 1;
                }
            }

            if (nums[start] >= target)
                return start;

            return start + 1;
        }
    }
}