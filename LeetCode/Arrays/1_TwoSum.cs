using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.Arrays
{
    public class TwoSumTask
    {
        [Test]
        public void TestExample()
        {
            var nums = new int[] {2, 7, 11, 15};
            int target = 9;
            var result = TwoSum(nums, target);

            Console.WriteLine($"indices: {result[0]}, {result[1]}  Expression: {nums[result[0]]} + {nums[result[1]]}  = {target}");
            Assert.That(nums[result[0]] + nums[result[1]], Is.EqualTo(target));
        }


        [Test]
        public void Test2()
        {
            var nums = new int[] { 11, 11, 2, 7, 11, 15, 11, 15 };
            int target = 18;
            var result = TwoSum(nums, target);

            Console.WriteLine($"indices: {result[0]}, {result[1]}  Expression: {nums[result[0]]} + {nums[result[1]]}  = {target}");
            Assert.That(nums[result[0]] + nums[result[1]], Is.EqualTo(target));
        }

        [Test]
        public void Test1()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            int target = 18;
            var result = TwoSum(nums, target);

            Console.WriteLine($"indices: {result[0]}, {result[1]}  Expression: {nums[result[0]]} + {nums[result[1]]}  = {target}");
            Assert.That(nums[result[0]] + nums[result[1]], Is.EqualTo(target));
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var hashTable = new Hashtable();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (hashTable.ContainsKey(complement))
                {
                    return new[] {(int) hashTable[complement], i };
                }

                hashTable[nums[i]] = i;
                //hashTable.Add(nums[i], i);
            }

            throw new Exception("No two sum solution");
        }


        public int[] TwoSum1(int[] nums, int target) // brute force
        {
            for(int i = 0; i < nums.Length; i++)
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new[] {i, j};
                }
            }

            throw new Exception("No two sum solution");
        }
    }
}