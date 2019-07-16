using NUnit.Framework;

namespace LeetCode.BinarySearch
{
    public class SearchInRotatedSortedArray2 // NOT SOLVED
    {
        [Test]
        public void Example1()
        {
            int[] nums = {2, 5, 6, 0, 0, 1, 2};
            int target = 0;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int[] nums = { 2, 5, 6, 0, 0, 1, 2 };
            int target = 3;
            bool expected = false;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            int[] nums = { 2, 5, 6, 0, 0, 1, 2 };
            int target = 5;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            int[] nums = { 2, 5, 6, 0, 0, 1, 2 };
            int target = 1;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            int[] nums = { 2, 5, 6, 0, 0, 1, 2 };
            int target = 2;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            int[] nums = {2, 5, 6, 0, 0, 1, 2};
            int target = 0;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            int[] nums = { 1, 2, 5, 6 };
            int target = 0;
            bool expected = false;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test6()
        {
            int[] nums = { 1, 2, 5, 6 };
            int target = 2;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test7()
        {
            int[] nums = { 1, 2, 5, 6, 0 };
            int target = 2;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test8()
        {
            int[] nums = { 1, 2, 5, 6, 0 };
            int target = 4;
            bool expected = false;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test9()
        {
            int[] nums = { 1 };
            int target = 4;
            bool expected = false;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test10()
        {
            int[] nums = { 1 };
            int target = 1;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test11()
        {
            int[] nums = { 1, 2 };
            int target = 1;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test12()
        {
            int[] nums = { 1, 2 };
            int target = 2;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test13()
        {
            int[] nums = { 2, 1 };
            int target = 1;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test14()
        {
            int[] nums = { 2, 1 };
            int target = 2;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test15()
        {
            int[] nums = { 1, 1 };
            int target = 2;
            bool expected = false;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test16()
        {
            int[] nums = { 1, 1 };
            int target = 1;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        [Test]
        public void Test17()
        {
            int[] nums = { 1, 1, 3, 1 };
            int target = 3;
            bool expected = true;

            Assert.That(Search(nums, target), Is.EqualTo(expected));
        }

        public bool Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return false;
            }

            if (nums.Length == 1)
            {
                return nums[0] == target;
            }

            int start = 0;
            int end = nums.Length - 1;

            if (nums[0] < nums[nums.Length - 1]) // no rotation, NO <=
            {
                return BinarySearch(nums, start, end, target) > -1;
            }

            int pivot = FindPivot(nums);

            if (target <= nums[nums.Length - 1])
            {
                return BinarySearch(nums, pivot, end, target) > -1;
            }

            return BinarySearch(nums, start, pivot - 1, target) > -1;

            //if (target >= nums[0])
            //{
            //    return BinarySearch(nums, start, pivot - 1, target) > -1;
            //}

            //return BinarySearch(nums, pivot, end, target) > -1;
        }

        private int FindPivot(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                int position = start + (end - start) / 2;
                if (nums[position] < nums[end])
                {
                    end = position;
                }
                else if (nums[position] > nums[end])
                {
                    start = position + 1;
                }
                else
                {
                    end--; // !!!!!
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
                else if (nums[position] < target)
                {
                    start = position + 1;
                }
                else
                {
                    end = position - 1;
                }
            }

            return -1;
        }
    }
} 