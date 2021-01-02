using NUnit.Framework;

namespace LeetCode.Mathematics
{
    class _7_ReverseInteger
    {
        [Test]
        public void Test0()
        {
            Assert.That(Reverse(0), Is.EqualTo(0));
        }

        [Test]
        public void Test1()
        {
            Assert.That(Reverse(1), Is.EqualTo(1));
        }

        [Test]
        public void Test12()
        {
            Assert.That(Reverse(12), Is.EqualTo(21));
        }

        [Test]
        public void Test123()
        {
            Assert.That(Reverse(123), Is.EqualTo(321));
        }

        [Test]
        public void Test120()
        {
            Assert.That(Reverse(120), Is.EqualTo(21));
        }

        [Test]
        public void Test_1()
        {
            Assert.That(Reverse(-1), Is.EqualTo(-1));
        }

        [Test]
        public void Test_12()
        {
            Assert.That(Reverse(-12), Is.EqualTo(-21));
        }

        [Test]
        public void Test_123()
        {
            Assert.That(Reverse(-123), Is.EqualTo(-321));
        }

        [Test]
        public void Test_120()
        {
            Assert.That(Reverse(-120), Is.EqualTo(-21));
        }

        [Test]
        public void Test_IntMax()
        {
            Assert.That(Reverse(int.MaxValue), Is.EqualTo(0));
        }

        [Test]
        public void Test_IntMax_1()
        {
            Assert.That(Reverse(int.MaxValue - 1), Is.EqualTo(0));
        }

        [Test]
        public void Test_IntMin()
        {
            Assert.That(Reverse(int.MinValue), Is.EqualTo(0));
        }

        [Test]
        public void Test_IntMin_1()
        {
            Assert.That(Reverse(int.MinValue + 1), Is.EqualTo(0));
        }

        public int Reverse(int x)
        {
            //int y = x % 10;
            //x = x / 10;
            int y = 0;

            while (x != 0)
            {
                if (y > int.MaxValue / 10 || (y == int.MaxValue / 10 && x % 10 > 7)) return 0;
                if (y < int.MinValue / 10 || (y == int.MinValue / 10 && x % 10 < -8)) return 0;
                
                y = y * 10 + x % 10;
                x = x / 10;
            }

            return y;
        }
    }
}
