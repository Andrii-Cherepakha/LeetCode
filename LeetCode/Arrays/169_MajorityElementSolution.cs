using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCode.Arrays
{
    class MajorityElementSolution
    {
        [Test]
        public void Example1()
        {
            int[] nums = { 3, 2, 3 };
            int expected = 3;
            Assert.That(MajorityElement(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int[] nums = { 2, 2, 1, 1, 1, 2, 2 };
            int expected = 2;
            Assert.That(MajorityElement(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            int[] nums = { 2, 2, 2, 2 };
            int expected = 2;
            Assert.That(MajorityElement(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            int[] nums = { 2 };
            int expected = 2;
            Assert.That(MajorityElement(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            int[] nums = { 3, 2, 3, 3 };
            int expected = 3;
            Assert.That(MajorityElement(nums), Is.EqualTo(expected));
        }

        // Boyer-Moore Voting Algorithm  commplexity O(N)
        // https://ru.wikipedia.org/wiki/%D0%90%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC_%D0%B1%D0%BE%D0%BB%D1%8C%D1%88%D0%B8%D0%BD%D1%81%D1%82%D0%B2%D0%B0_%D0%B3%D0%BE%D0%BB%D0%BE%D1%81%D0%BE%D0%B2_%D0%91%D0%BE%D0%B9%D0%B5%D1%80%D0%B0_%E2%80%94_%D0%9C%D1%83%D1%80%D0%B0
        //  always thinking about the pair. 
        public int MajorityElement(int[] nums) // complexity O(N)
        {
            int majority = int.MinValue;
            int counter = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (counter == 0)
                {
                    majority = nums[i];
                    counter = 1;
                }
                else
                {
                    if (nums[i] == majority)
                        counter++;
                    else //  the code means found a pair.
                        counter--;
                }
            }

            return majority;
        }

        public int MajorityElementBoyerMooreSimplification(int[] nums) // complexity O(N)
        {
            int majority = int.MinValue;
            int counter = 0;

            foreach (int num in nums)
            {
                if (counter == 0)
                {
                    majority = num;
                }
                counter += num == majority ? 1 : -1;
            }

            return majority;
        }

        public int MajorityElementN(int[] nums) // complexity O(N log N)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }

        public int MajorityElementNN(int[] nums) // complexity O(N) + space O(N)
        {
            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict[num] = 1;
                }
            }

            // The majority element is the element that appears more than ⌊ n/2 ⌋ times.
            int majority = nums.Length / 2;

            foreach (int key in dict.Keys)
            {
                if (dict[key] > majority)
                    return key;
            }

            return int.MinValue;
        }
    }
}