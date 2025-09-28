using NUnit.Framework;

namespace LeetCode.Arrays
{
    class SearchRangeInArray2
    {
        [Test]
        public void Example1()
        {
            int[] nums = { 5, 7, 7, 8, 8, 10 };
            int target = 8;
            int[] expected = { 3, 4 };
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
            Assert.That(expected, Is.EqualTo(actual)    );
        }

        [Test]
        public void TestMiddle2()
        {
            int[] nums = { 1, 2, 2, 3, 3, 3, 4, 4, 5, 6 };
            int target = 3;
            int[] expected = { 3, 5 };
            var actual = SearchRange(nums, target);

            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void TestBegin()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6 };
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

        [Test]
        public void TestEnd2()
        {
            int[] nums = { 7, 8, 8 };
            int target = 8;
            int[] expected = { 1, 2 };
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

            // find idex where all the elements less or equal to target - 1
            // and an idex where all the element greater or equal to target + 1

            int left = BinarySearch(nums, target - 0.5);
            int right = BinarySearch(nums, target + 0.5);

            if (left == right)
            {
                return new[] { -1, -1 };
            }

            return new[] { left, right - 1};
        }

        private int BinarySearch(int[] nums, double target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int position = start + (end - start) / 2;
                if (nums[position] < target)
                {
                    start = position + 1;
                }
                else
                {
                    end = position - 1;
                }
            }
            
            return start; // alway return start, not end
        }
    }
}
