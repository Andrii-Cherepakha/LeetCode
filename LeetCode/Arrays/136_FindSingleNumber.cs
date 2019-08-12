using NUnit.Framework;
using System.Collections.Generic;

// #bit

namespace LeetCode.Arrays
{
    class FindSingleNumber
    {
        [Test]
        public void Test1()
        {
            var nums = new int[] { 2, 2, 1 };
            int expected = 1;
            Assert.That(SingleNumber(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 4, 1, 2, 1, 2 };
            int expected = 4;
            Assert.That(SingleNumber(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 4, 1, 2, 1, 2, 4, 0 };
            int expected = 0;
            Assert.That(SingleNumber(nums), Is.EqualTo(expected));
        }

        // a XOR 0 == a
        // a XOR a == 0
        // a XOR b XOR a == a XOR a XOR b == 0 XOR b == b 
        public int SingleNumber(int[] nums)
        {
            int single = 0;
            foreach (int num in nums)
            {
                single = single ^ num;
            }
            return single;
        }

            public int SingleNumberHashTable(int[] nums)
        {
            var hashTable = new Dictionary<int, int>();

            foreach(int num in nums)
            {
                hashTable[num] = hashTable.ContainsKey(num) ? hashTable[num] + 1 : 0;              
            }

            foreach(int key in hashTable.Keys)
            {
                if (hashTable[key] == 0)
                {
                    return key;
                }
            }

            return -1;
        }
    }
}
