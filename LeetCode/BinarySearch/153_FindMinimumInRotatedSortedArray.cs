
using NUnit.Framework;

namespace LeetCode.BinarySearch
{
    class FindMinimumInRotatedSortedArray
    {
        [Test]
        public void Example1()
        {
            int[] nums = { 3, 4, 5, 1, 2 };
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int expected = 0;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            int[] nums = { 4, 5, 6, 7, 0 };
            int expected = 0;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            int[] nums = { 1, 2, 4, 5, 6, 7 };
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            int[] nums = { 1 };
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            int[] nums = { 1, 2 };
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            int[] nums = { 2, 1 };
            int expected = 1;
            Assert.That(FindMin(nums), Is.EqualTo(expected));
        }

        public int FindMin(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return int.MinValue;
            }

            if (nums[0] < nums[nums.Length - 1]) // no rotation
            {
                return nums[0];
            }

            return nums[FindPivot(nums)];
        }

        private int FindPivot(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                int position = start + (end - start) / 2;
                if (nums[position] <= nums[end])
                {
                    end = position;
                }
                else
                {
                    start = position + 1;
                }
            }

            return start;
        }
    }
}
