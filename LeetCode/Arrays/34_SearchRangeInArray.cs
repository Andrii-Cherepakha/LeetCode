using NUnit.Framework;

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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
        }

        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null)
            {
                return new[] { -1, -1 };
            }

            int position = BinarySearch(nums, target);

            if (position == -1)
            {
                return new[] {-1, -1};
            }

            // start ............... position ................... end
            // ........... T T T T T T T T T T T T T T T T T ....
            //                 <--------|-------->
            int left = BinarySearchToTheLeft(nums, position - 1, target);
            int right = BinarySearchToTheRight(nums, position + 1, target);

            if (left == -1) left = position;
            if (right == -1) right = position;

            return new[] { left, right };
        }

        private int BinarySearchToTheRight(int[] array, int position, int target)
        {
            if (position >= array.Length) return - 1;

            int start = position;
            int end = array.Length - 1;
            bool targetFound = false;
            while (start < end)
            {
                position = (start + end) / 2;
                if (array[position] == target)
                {
                    // all the values to the left are equal to target, need to go to the right
                    start = position + 1;
                    targetFound = true;
                }

                if (array[position] != target)
                {
                    // jumped over the border, need to go to the left
                    end = position - 1;
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

        private int BinarySearchToTheLeft(int[] array, int position, int target)
        {
            if (position < 0) return -1;

            int start = 0;
            int end = position;
            bool targetFound = false;
            while (start < end)
            {
                position = (start + end) / 2;
                if (array[position] == target)
                {
                    // all the values to the right are equal to target, need to go to the left
                    end = position - 1;
                    targetFound = true;
                }

                if (array[position] != target)
                {
                    // jumped over the border, need to go to the right
                    start = position + 1;
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


        // returns index of the element or -1
        private int BinarySearch(int[] array, int value)
        {
            int start = 0;
            int end = array.Length - 1;
            while (start <= end)
            {
                int position = (start + end) / 2;
                if (array[position] == value)
                {
                    return position;
                }
                if (array[position] < value)
                {
                    start = position + 1;
                }
                if (array[position] > value)
                {
                    end = position - 1;
                }
            }

            return -1;
        }
    }
}