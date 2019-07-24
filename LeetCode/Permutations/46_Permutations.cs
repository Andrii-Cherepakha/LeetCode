using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Permutations
{
    class Permutations
    {
        [Test]
        public void Test1()
        {
            int[] nums = { 1 };
            var result = Permute(nums);
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test2()
        {
            int[] nums = { 2, 1 };
            var result = Permute(nums);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test3()
        {
            int[] nums = { 2, 3, 1 };
            var result = Permute(nums);
            Assert.That(result.Count, Is.EqualTo(6));
        }

        [Test]
        public void Test4()
        {
            int[] nums = { 4, 2, 3, 1 };
            var result = Permute(nums);
            Assert.That(result.Count, Is.EqualTo(24));
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var list = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
            {
                return list;
            }

            Array.Sort(nums);

            do
            {
                list.Add(nums.ToList());
            }
            while (NextPermutation(nums));

            return list;
        }

        private bool NextPermutation(int[] nums)
        {
            int k = nums.Length - 1;

            while (k > 0 && nums[k] <= nums[k-1])
            {
                k--;
            }
            k--;

            if(k < 0)
            {
                return false;
            }

            int l = nums.Length - 1;
            while (nums[k] >= nums[l])
            {
                l--;
            }

            Swap(nums, k, l);
            Reverse(nums, k +1, nums.Length - 1);

            return true;
        }

        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        private void Reverse(int[] nums, int i, int j)
        {
            while (i < j)
            {
                Swap(nums, i, j);
                i++;
                j--;
            }
        }
    }
}