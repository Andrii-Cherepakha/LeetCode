using System;
using NUnit.Framework;

namespace LeetCode.BinarySearch
{
    public class SearchInRotatedSortedArray
    {
        [Test]
        public void Example1()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 0;
            int expected = 4;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 3;
            int expected = -1;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 7;
            int expected = 3;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 4;
            int expected = 0;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 2;
            int expected = 6;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            int[] nums = { 4, 2 };
            int target = 2;
            int expected = 1;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            int[] nums = { 4, 2 };
            int target = 4;
            int expected = 0;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test6()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 100;
            int expected = -1;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test7()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = -100;
            int expected = -1;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test8()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 3;
            int expected = -1;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test9()
        {
            int[] nums = { 1 };
            int target = 1;
            int expected = 0;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test10()
        {
            int[] nums = { 1 };
            int target = 2;
            int expected = -1;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }


        [Test]
        public void Test11()
        {
            int[] nums = { 1, 3 };
            int target = 1;
            int expected = 0;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test12()
        {
            int[] nums = { 5, 1, 3 };
            int target = 3;
            int expected = 2;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test13()
        {
            int[] nums = { 4, 5, 6, 7, 8, 1, 2, 3 };
            int target = 8;
            int expected = 4;
            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            // A[0] .... A[p] A[p+1] .... A[N]
            // each element in left sub array is greater A[N]
            // each element in right sub array is smaller A[0]

            int start = 0;
            int end = nums.Length - 1;

            if (nums[0] <= nums[nums.Length - 1]) // no rotation
            {
                return BinarySearch(nums, start, end, target);
            }

            if (target > nums[end] && target < nums[start])
            {
                return -1;
            }

            int pivot = FindPivot(nums);
            Console.WriteLine($"Pivot {nums[pivot]} at {pivot}");

            if (target <= nums[nums.Length - 1])
            {
                // we need to search in the right sub array
                start = pivot;
            }
            if (target >= nums[0])
            //else
            {
                // we need to search in the left sub array
                end = pivot - 1;
            }
            
            return BinarySearch(nums, start, end, target);
        }

        private int FindPivot(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int position = start + (end - start) / 2;
                if (nums[position] >= nums[0])
                {
                    // we are in the left sub array
                    start = position + 1;
                }

                if (nums[position] <= nums[nums.Length - 1])
                {
                    // we are in the right sub array
                    end = position - 1;
                }
            }

            return start;
        }

        private int BinarySearch(int[] nums, int start, int end, int target)
        {
            while (start <= end)
            {
                int position = start + (end - start) / 2;
                if (nums[position] == target)
                {
                    return position;
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

            return -1;
        }
    }
}