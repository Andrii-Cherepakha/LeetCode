using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Arrays
{
    public class MajorityElement2
    {
        [Test]
        public void Example1()
        {
            int[] nums = {3, 2, 3};
            List<int> expected = new List<int> { 3 };
            Assert.That(MajorityElement(nums), Is.EquivalentTo(expected));
        }

        [Test]
        public void Example2()
        {
            int[] nums = { 1, 1, 1, 3, 3, 2, 2, 2 };
            List<int> expected = new List<int> { 1, 2 };
            Assert.That(MajorityElement(nums), Is.EquivalentTo(expected));
        }

        [Test]
        public void Test1()
        {
            int[] nums = { 1, 1, 4, 3, 3, 5, 2, 2 };
            List<int> expected = new List<int>( );
            Assert.That(MajorityElement(nums), Is.EquivalentTo(expected));
        }
        
        public IList<int> MajorityElement(int[] nums)
        {
            List<int> list = new List<int>();

            if (nums == null)
            {
                return list;
            }

            int candidate1 = 0, candidate2 = 0, counter1 = 0, counter2 = 0;

            foreach (int num in nums)
            {
                if (num == candidate1)
                {
                    counter1++;
                }
                else if (num == candidate2)
                {
                    counter2++;
                }
                else if (counter1 == 0)
                {
                    candidate1 = num;
                    counter1 = 1;
                }
                else if (counter2 == 0)
                {
                    candidate2 = num;
                    counter2 = 1;
                }
                else
                {
                    counter1--;
                    counter2--;
                }
            }

            int majority = nums.Length / 3;

            if (nums.Count(i => i == candidate1) > majority)
            {
                list.Add(candidate1);
            }

            if (candidate2 != candidate1 && nums.Count(i => i == candidate2) > majority)
            {
                list.Add(candidate2);
            }

            return list;
        }
    }
}