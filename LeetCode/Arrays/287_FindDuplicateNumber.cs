

using NUnit.Framework;

namespace LeetCode.Arrays
{
    class FindDuplicateNumber
    {
        [Test]
        public void Test1()
        {
            var nums = new int[] { 1, 3 ,4, 2, 2 };
            int expected = 2;
            int actual = FindDuplicate(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 3, 1, 3, 4, 2 };
            int expected = 3;
            int actual = FindDuplicate(nums);
            Assert.That(actual, Is.EqualTo(expected));
        }

        public int FindDuplicate(int[] nums)
        {
            // Find the intersection point of the two runners.
            int tortoise = nums[0];
            int hare = nums[0];

            do
            {
                tortoise = nums[tortoise];
                hare = nums[hare];
                hare = nums[hare];
            } while (tortoise != hare);

            // Find the "entrance" to the cycle.
            int ptr1 = nums[0];
            int ptr2 = tortoise;
            while (ptr1 != ptr2)
            {
                ptr1 = nums[ptr1];
                ptr2 = nums[ptr2];
            }

            return ptr1;
        }

    }
}
