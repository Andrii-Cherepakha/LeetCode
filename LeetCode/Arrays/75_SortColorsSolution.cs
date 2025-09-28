// #sort The Dutch National Flag Problem (The Quicksort "Band-Aid") https://www.youtube.com/watch?v=ER4ivZosqCg

using NUnit.Framework;
using System;

namespace LeetCode.Arrays
{
    class SortColorsSolution
    {
        [Test]
        public void Example1()
        {
            int[] nums = { 2, 0, 2, 1, 1, 0 };
            SortColors(nums);
            Assert.That(ArrayHelper.IsSorted(nums), Is.True);
        }

        [Test]
        public void Test1()
        {
            int[] nums = { 0, 1, 1, 2, 2, 2, 1, 1, 1, 0, 0, 0, 2 };
            SortColors(nums);
            Assert.That(ArrayHelper.IsSorted(nums), Is.True);
        }

        [Test]
        public void Test2()
        {
            int[] nums = { 1, 1, 2, 2, 2, 1, 1, 1, 2 };
            SortColors(nums);
            Assert.That(ArrayHelper.IsSorted(nums), Is.True);
        }

        [Test]
        public void Test1_0()
        {
            int[] nums = { 0 };
            SortColors(nums);
            Assert.That(ArrayHelper.IsSorted(nums), Is.True );
        }

        [Test]
        public void Test1_1()
        {
            int[] nums = { 1 };
            SortColors(nums);
            Assert.That(ArrayHelper.IsSorted(nums), Is.True);
        }

        [Test]
        public void Test1_2()
        {
            int[] nums = { 2 };
            SortColors(nums);
            Assert.That(ArrayHelper.IsSorted(nums), Is.True);
        }

        [Test]
        public void Test012()
        {
            int[] nums = { 0, 1, 2 };
            SortColors(nums);
            Assert.That(ArrayHelper.IsSorted(nums), Is.True);
        }

        [Test]
        public void Test210()
        {
            int[] nums = { 2, 1, 0 };
            SortColors(nums);
            Assert.That(ArrayHelper.IsSorted(nums), Is.True);
        }

        [Test]
        public void Test201()
        {
            int[] nums = { 2, 0, 1 };
            SortColors(nums);
            Assert.That(ArrayHelper.IsSorted(nums), Is.True);
        }

        [Test]
        public void Test120()
        {
            int[] nums = { 1, 2, 0 };
            SortColors(nums);
            Assert.That(ArrayHelper.IsSorted(nums), Is.True);
        }

        public void SortColors(int[] nums) // right to left
        {
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            int low = 0, mid = nums.Length - 1, high = nums.Length - 1;

            while (low <= mid)
            {
                if (nums[mid] == 0)
                {
                    nums[mid] = nums[low];
                    nums[low] = 0;
                    low++;
                }
                else if (nums[mid] == 1)
                {
                    mid--;
                }
                else if (nums[mid] == 2)
                {
                    nums[mid] = nums[high];
                    nums[high] = 2;
                    high--;
                    mid = Math.Min(mid, high);
                }
            }
        }

        public void SortColorsLeftToRight(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            int low = 0, mid = 0, high = nums.Length - 1;

            while (mid <= high)
            {
                if (nums[mid] == 0)
                {
                    nums[mid] = nums[low];
                    nums[low] = 0;
                    low++;
                    mid++;
                }
                else if (nums[mid] == 1)
                {
                    mid++;
                }
                else if (nums[mid] == 2)
                {
                    nums[mid] = nums[high];
                    nums[high] = 2;
                    high--;
                }
            }
        }

        public void SortColorsOnePass(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            int n0 = -1, n1 = -1, n2 = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[++n2] = 2; nums[++n1] = 1; nums[++n0] = 0;
                }
                else if (nums[i] == 1)
                {
                    nums[++n2] = 2; nums[++n1] = 1;
                }
                else if (nums[i] == 2)
                {
                    nums[++n2] = 2;
                }
            }
        }

        public void SortColorsN(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            int left = 0;
            int right = nums.Length - 1;
            int position2 = nums.Length - 1;

            while (left <= right)
            {
                if (nums[left] == 0)
                {
                    left++;
                }
                else if (nums[left] == 1)
                {
                    if(nums[left] != nums[right]) Swap(nums, left, right);
                    right--;
                }
                else if (nums[left] == 2)
                {
                    if (nums[left] != nums[position2]) Swap(nums, left, position2);
                    position2--;
                    right = Math.Min(right, position2);
                }
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[j];
            nums[j] = nums[i];
            nums[i] = tmp;
        }

        public void SortColorsCountingSort(int[] nums) // counting sort
        {
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            int[] count = new int[3];

            foreach (int idx in nums)
            {
                count[idx]++;
            }

            int i = 0;
            int j = 0;
            while (i < nums.Length)
            {
                while (j < count.Length && count[j] == 0) j++;
                nums[i] = j;
                i++;
                count[j]--;
            }

            //for (int i = 0; i < count[0]; i++)
            //{
            //    nums[i] = 0;
            //}

            //for (int i = 0; i < count[1]; i++)
            //{
            //    nums[i + count[0]] = 1;
            //}

            //for (int i = 0; i < count[2]; i++)
            //{
            //    nums[i + count[0] + count[1]] = 2;
            //}
        }
    }
}