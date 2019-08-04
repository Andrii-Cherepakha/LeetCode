using NUnit.Framework;
using System.Text;

namespace LeetCode.Integers
{
    class MaximumSwapSolution
    {
        [Test]
        public void Example1()
        {
            int init = 2736;
            int expected = 7236;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int init = 9973;
            int expected = 9973;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            int init = 8736;
            int expected = 8763;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        [Test]
        public void Test0()
        {
            int init = 0;
            int expected = 0;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            int init = 98765432;
            int expected = 98765432;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            int init = 12345678;
            int expected = 82345671;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            int init = 900070;
            int expected = 970000;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            int init = 27362736;
            int expected = 77362236;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        [Test]
        public void Test6()
        {
            int init = 21380936;
            int expected = 91380236;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        [Test]
        public void Test7()
        {
            int init = 12349876;
            int expected = 92341876;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        [Test]
        public void Test8()
        {
            int init = 98761234;
            int expected = 98764231;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        [Test]
        public void Test0_2()
        {
            int init = 1000;
            int expected = 1000;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        [Test]
        public void Test0_3()
        {
            int init = 10900;
            int expected = 90100;
            Assert.That(MaximumSwap(init), Is.EqualTo(expected));
        }

        public int MaximumSwap(int num) // 0 ... 10^8   https://leetcode.com/problems/maximum-swap/
        {
            StringBuilder str = new StringBuilder(num.ToString());

            int[] leftmost = new int[10]; // store position of first occurance
            int[] rightmost = new int[10]; // store position of last occurance

            for (int i = 0; i < 10; i++)
            {
                leftmost[i] = -1;
                rightmost[i] = -1;
            }

            for (int i = 0; i < str.Length; i++)
            {
                rightmost[ str[i] - '0'] = i;
                if (leftmost[str[i] - '0'] == -1)
                {
                    leftmost[str[i] - '0'] = i;
                }
            }

            for (int i = 9; i >= 0; i--) // among rightmost starting from the biggest digit
            {
                if (rightmost[i] == -1) continue; // no such digit in the number
                int position = rightmost[i];
                int digit = -1;

                for (int j = 0; j < i; j ++)
                {
                    if (leftmost[j] == -1) continue; // no such digit in the number

                    // find first the left most digit that less than current (right most)                    
                    if (leftmost[j] < position)
                    {
                        position = leftmost[j];
                        digit = j;
                    }
                }

                if (digit >= 0)
                {
                    // swap
                    str[leftmost[digit]] = (char)(i + '0');//Convert.ToChar(i);
                    str[rightmost[i]] = (char)(digit + '0');// Convert.ToChar(j);
                    return int.Parse(str.ToString());
                }
            }

            return num;
            //return int.Parse(str.ToString());
        }
    }
}
