

using NUnit.Framework;

namespace LeetCode.Integers
{
    class SumOfTreeTests
    {
        private SumOfTree _solution = new SumOfTree();

        [Test]
        public void TestNull()
        {
            var list = _solution.ThreeSum(null);
        }


        [Test]
        public void TestL0()
        {
            var nums = new int[] { };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void TestL1()
        {
            var nums = new int[] { -1 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void TestL2()
        {
            var nums = new int[] { -1, 0 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void Test0()
        {
            var nums = new int[] { -1, 0, 2 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void Test1()
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4, -1, -1 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4, -1, -1, 2, 2 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void Test4()
        {
            var nums = new int[] { -1, -1, -1, -1, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, -4, -4, -4, -4 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void Test5()
        {
            var nums = new int[] { 5, 5, 5, 5, 5, 5, 5, 5 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void Test6()
        {
            var nums = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void Test7()
        {
            var nums = new int[] { 10, 10, 10, 0, 0, 0, -10, -10, -10 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void Test8()
        {
            var nums = new int[] { 10, 11, 12, 0, 0, 0, 1, 2, -2, -1, -12, -11, -10 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void TestWrong1()
        {
            var nums = new int[] { 1, 2, -2, -1 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void TestBoundary1()
        {
            var nums = new int[] { -2147483648, 0, -2147483648 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void TestBoundary2()
        {
            var nums = new int[] { -2147483648, 0, 2147483647 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void TestBoundary3()
        {
            var nums = new int[] { -2147483647, 0, -2147483647 };
            var list = _solution.ThreeSum(nums);
        }

        [Test]
        public void TestBoundary4()
        {
            var nums = new int[] { -2147483647, 0, 2147483647 };
            var list = _solution.ThreeSum(nums);
        }
    }
}
