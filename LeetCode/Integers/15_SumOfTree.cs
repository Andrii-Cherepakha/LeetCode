using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.Integers
{
    public class SumOfTree
    {
        [Test]
        public void Test1()
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4 };
            var list = ThreeSum(nums);
        }


        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums); // n log(n)
            

            return null;
        }
    }
}