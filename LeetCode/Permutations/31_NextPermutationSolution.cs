using System;
using LeetCode.Arrays;
using NUnit.Framework;

namespace LeetCode.Permutations
{
    public class NextPermutationSolution
    {
        [Test]
        public void Example1()
        {
            int[] nums = {1, 2, 3};
            int[] expected = {1, 3, 2};
            NextPermutation(nums);
            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(nums);
            Assert.That(nums, Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int[] nums = {3, 2, 1};
            int[] expected = {1, 2, 3};
            NextPermutation(nums);
            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(nums);
            Assert.That(nums, Is.EqualTo(expected));
        }

        [Test]
        public void Example3()
        {
            int[] nums = {1, 1, 5};
            int[] expected = {1, 5, 1};
            NextPermutation(nums);
            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(nums);
            Assert.That(nums, Is.EqualTo(expected));
        }

        [Test]
        public void Test132()
        {
            int[] nums = {1, 3, 2};
            int[] expected = {2, 1, 3};
            NextPermutation(nums);
            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(nums);
            Assert.That(nums, Is.EqualTo(expected));
        }

        [Test]
        public void Test213()
        {
            int[] nums = {2, 1, 3};
            int[] expected = {2, 3, 1};
            NextPermutation(nums);
            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(nums);
            Assert.That(nums, Is.EqualTo(expected));
        }

        [Test]
        public void Test231()
        {
            int[] nums = {2, 3, 1};
            int[] expected = {3, 1, 2};
            NextPermutation(nums);
            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(nums);
            Assert.That(nums, Is.EqualTo(expected));
        }

        [Test]
        public void Test312()
        {
            int[] nums = {3, 1, 2};
            int[] expected = {3, 2, 1};
            NextPermutation(nums);
            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(nums);
            Assert.That(nums, Is.EqualTo(expected));
        }

        [Test]
        public void Test321()
        {
            int[] nums = {3, 2, 1};
            int[] expected = {1, 2, 3};
            NextPermutation(nums);
            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(nums);
            Assert.That(nums, Is.EqualTo(expected));
        }


        [Test]
        public void Test1()
        {
            int[] nums = { 1 };
            int[] expected = { 1 };
            NextPermutation(nums);
            ArrayHelper.PrintArray(expected);
            ArrayHelper.PrintArray(nums);
            Assert.That(nums, Is.EqualTo(expected));
        }

        public void NextPermutation(int[] nums) // from right to left
        {
            if (nums == null)
            {
                return;
            }

            int k = nums.Length - 1;
            while (k > 0 && nums[k - 1] >= nums[k])
            {
                k--;
            }
            k--;

            //int k = -1;
            //for (int i = nums.Length - 1; i >= 0; i--)
            //{
            //    if (i > 0 && nums[i - 1] < nums[i])
            //    {
            //        k = i - 1;
            //        break;
            //    }
            //}

            if (k < 0) // If no such index exists, the permutation is the last permutation.
            {
                Array.Sort(nums);
                return;
            }

            // find the smallest element in the suffix that is greater than the pivot
            int l = nums.Length - 1;
            while (nums[l] <= nums[k]) // can be omitted "l > 0 &&" 
            {
                l--;
            }

            //int l = 0;
            //for (int i = nums.Length - 1; i >= 0; i--)
            //{
            //    if (nums[i] > nums[k])
            //    {
            //        l = i;
            //        break;
            //    }
            //}

            // 3. Swap the value of a[k] with that of a[l].
            int tmp = nums[l];
            nums[l] = nums[k];
            nums[k] = tmp;

            // 4. Reverse the sequence from a[k + 1] up to and including the final element a[n].
            k++;
            int n = nums.Length - 1;
            while (k < n)
            {
                tmp = nums[n];
                nums[n] = nums[k];
                nums[k] = tmp;
                k++;
                n--;
            }
        }

        // The following algorithm generates the next permutation lexicographically after a given permutation.
        // It changes the given permutation in-place.
        // 1. Find the largest index k such that a[k] < a[k + 1]. If no such index exists, the permutation is the last permutation.
        // 2. Find the largest index l greater than k such that a[k] < a[l].
        // 3. Swap the value of a[k] with that of a[l].
        // 4. Reverse the sequence from a[k + 1] up to and including the final element a[n].

        public void NextPermutationLeftToRight(int[] nums) // from left to rigth
        {
            if (nums == null)
            {
                return;
            }

            int k = -1;
            int l = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                // 1. Find the largest index k such that a[k] < a[k + 1].
                if (i < nums.Length - 1 && nums[i] < nums[i + 1])
                {
                    k = i;
                }

                // 2. Find the largest index l greater than k such that a[k] < a[l].
                if (k != -1 && nums[k] < nums[i])
                {
                    l = i;
                }
            }

            if (k == -1) // If no such index exists, the permutation is the last permutation.
            {
                Array.Sort(nums);
                return;
            }

            // 3. Swap the value of a[k] with that of a[l].
            int tmp = nums[l];
            nums[l] = nums[k];
            nums[k] = tmp;

            // 4. Reverse the sequence from a[k + 1] up to and including the final element a[n].
            k++;
            int n = nums.Length - 1;
            while (k < n)
            {
                tmp = nums[n];
                nums[n] = nums[k];
                nums[k] = tmp;
                k++;
                n--;
            }
        }
    }
}