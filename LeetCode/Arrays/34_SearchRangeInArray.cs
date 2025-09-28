using NUnit.Framework;

// #binary_search

namespace LeetCode.Arrays
{
    public class SearchRangeInArray
    {
        [Test]
        public void Example1()
        {
            int[] nums = {5, 7, 7, 8, 8, 10};
            int target = 8;
            int[] expected = {3, 4};
            var actual = SearchRange(nums, target);
            
            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Example2()
        {
            int[] nums = { 5, 7, 7, 8, 8, 10 };
            int target = 6;
            int[] expected = { -1, -1 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test1()
        {
            int[] nums = { 5, 7, 7, 8, 9, 10 };
            int target = 8;
            int[] expected = { 3, 3 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test2()
        {
            int[] nums = { 5, 7, 7, 8, 9 };
            int target = 8;
            int[] expected = { 3, 3 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test3()
        {
            int[] nums = { 5, 8, 8, 8, 9 };
            int target = 8;
            int[] expected = { 1, 3 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test4()
        {
            int[] nums = { 5, 8, 8, 8, 8, 9 };
            int target = 8;
            int[] expected = { 1, 4 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test5()
        {
            int[] nums = { 8, 8, 8, 8, 9 };
            int target = 8;
            int[] expected = { 0, 3 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test6()
        {
            int[] nums = { 8, 8, 8, 8, 8, 9 };
            int target = 8;
            int[] expected = { 0, 4 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test7()
        {
            int[] nums = { 1, 8, 8, 8, 8, 8 };
            int target = 8;
            int[] expected = { 1, 5 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test8()
        {
            int[] nums = { 1, 8, 8, 8, 8, 8, 8 };
            int target = 8;
            int[] expected = { 1, 6 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test9()
        {
            int[] nums = { 8, 8, 8, 8, 8, 8, 8 };
            int target = 8;
            int[] expected = { 0, 6 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test10()
        {
            int[] nums = { 1 };
            int target = 1;
            int[] expected = { 0, 0 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void TestMiddle()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6 };
            int target = 3;
            int[] expected = { 2, 2 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void TestBegin()
        {
            int[] nums = { 1 ,2 ,3, 4, 5, 6};
            int target = 1;
            int[] expected = { 0, 0 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void TestEnd()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6 };
            int target = 6;
            int[] expected = { 5, 5 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return new[] { -1, -1 };
            }

            int left = BinarySearchToTheLeft(nums, target);

            if (left == -1)
            {
                return new[] { -1, -1 };
            }

            int rigth = BinarySearchToTheRigth(nums, target);

            return new[] { left, rigth };
        }

        private int BinarySearchToTheLeft(int[] array, int target)
        {
            int start = 0;
            int end = array.Length - 1;
            bool targetFound = false;
            while (start < end)
            {
                int position = start + (end - start) / 2; // (start + end) / 2;
                targetFound = targetFound || array[position] == target;
                if (array[position] < target)
                {
                    start = position + 1;
                }
                else // >=
                {
                    end = position - 1;
                }
            }

            // or end
            if (array[start] == target) // target found on last step
            {
                return start;
            }

            if (!targetFound) return -1; // target is not present in the range

            return start + 1; // target is present and found recently
        }

        private int BinarySearchToTheRigth(int[] array, int target)
        {
            int start = 0;
            int end = array.Length - 1;
            bool targetFound = false;
            while (start < end)
            {
                int position = start + (end - start) / 2; // (start + end) / 2;
                targetFound = targetFound || array[position] == target;
                if (array[position] > target)
                {
                    end = position - 1;
                }
                else // <=
                {
                    start = position + 1;
                }
            }

            // or end
            if (array[start] == target) // target found on last step
            {
                return start;
            }

            if (!targetFound) return -1; // target is not present in the range

            return start - 1; // target is present and found recently
        }
    }
}