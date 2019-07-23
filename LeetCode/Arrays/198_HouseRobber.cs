using System;
using NUnit.Framework;

namespace LeetCode.Arrays
{
    public class HouseRobber
    {
        [Test]
        public void Example1()
        {
            int[] nums = { 1, 2, 3, 1 };
            int expected = 4;
            Assert.That(Rob(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int[] nums = { 2, 7, 9, 3, 1 };
            int expected = 12;
            Assert.That(Rob(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Example3()
        {
            int[] nums = { 1, 3, 1 };
            int expected = 3;
            Assert.That(Rob(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Example4()
        {
            int[] nums = { 4,1,2,7,5,3,1};
            int expected = 14;
            Assert.That(Rob(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            int[] nums = { 2 };
            int expected = 2;
            Assert.That(Rob(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            int[] nums = { 2, 1 };
            int expected = 2;
            Assert.That(Rob(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test2_2()
        {
            int[] nums = { 1, 2 };
            int expected = 2;
            Assert.That(Rob(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            int[] nums = { 0, 100, 0, 0, 100, 0};
            int expected = 200;
            Assert.That(Rob(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            int[] nums = {100, 0, 0, 100 };
            int expected = 200;
            Assert.That(Rob(nums), Is.EqualTo(expected));
        }

        // A robber has 2 options: a) rob current house i; b) don't rob current house.
        // If an option "a" is selected it means she can't rob previous i-1 house
        //      but can safely proceed to the one before previous i-2 and gets all cumulative loot that follows.
        // If an option "b" is selected the robber gets all the possible loot from robbery of i-1 and all the following buildings.

        // rob(i) = Math.max( rob(i - 2) + currentHouseValue, rob(i - 1) )

        public int RobLeetCode(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int even = 0;
            int odd = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even = Math.Max(even + nums[i], odd);
                }
                else
                {
                    odd = Math.Max(odd + nums[i], even);
                }
            }

            return Math.Max(even,odd);
        }

        public int Rob(int[] nums) // INCORRECT
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            if (nums.Length == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }

            int sumEven = nums[0];
            int sumOdd = nums[1];
            int maxSum = Math.Max(sumEven, sumOdd);

            for (int i = 2; i < nums.Length; i++)
            {
                if (i % 2 == 0) // even position
                {
                    sumEven = sumEven + nums[i];
                    maxSum = Math.Max(maxSum, Math.Max(sumEven, sumOdd - nums[i - 1] + nums[i]));
                }
                else // odd position
                {
                    sumOdd = sumOdd + nums[i];
                    maxSum = Math.Max(maxSum, Math.Max(sumEven - nums[i - 1] + nums[i], sumOdd));
                }
            }

            //return Math.Max(sumEven, sumOdd);
            return maxSum;
        }
    }
}