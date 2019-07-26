using NUnit.Framework;

namespace LeetCode.Other
{
    public class Factorial
    {
        [Test]
        public void Fact1()
        {
            Assert.That(Fact(1), Is.EqualTo(1));
        }

        [Test]
        public void Fact2()
        {
            Assert.That(Fact(2), Is.EqualTo(2));
        }

        [Test]
        public void Fact3()
        {
            Assert.That(Fact(3), Is.EqualTo(6));
        }

        [Test]
        public void Fact4()
        {
            Assert.That(Fact(4), Is.EqualTo(24));
        }

        [Test]
        public void Fact5()
        {
            Assert.That(Fact(5), Is.EqualTo(120));
        }

        [Test]
        public void Fact6()
        {
            Assert.That(Fact(6), Is.EqualTo(720));
        }

        [Test]
        public void Fact7()
        {
            Assert.That(Fact(7), Is.EqualTo(5040));
        }

        [Test]
        public void Fact8()
        {
            // 8! = 1 * 2 * 3 * 4 * 5 * 6 * 7 * 8
            // 8! = 1 * 8  * 2 * 7 * 3 * 6 * 4 * 5
            // 8! = 8 * 14 * 18 * 20
            // 8! = 8 * (8 + 6) * (14 + 4) * (18 + 2)

            Assert.That(Fact(8), Is.EqualTo(40320));
        }

        [Test]
        public void Fact9()
        {
            // 9! = 1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9
            // 9! = 1 * 9  * 2 * 8 * 3 * 7 * 4 * 6 * 5
            // 9! = 9 * 16 * 21 * 24 * 5
            // 9! = 9 * (9 + 7) * (16 + 5) * (21 + 3) * 5

            Assert.That(Fact(9), Is.EqualTo(362880));
        }

        [Test]
        public void Fact10()
        {
            Assert.That(Fact(10), Is.EqualTo(3628800));
        }

        public int Fact(int n)
        {
            if (n <= 0) return 0;

            int result = n;
            int sum = n;
            int addend = n - 2;

            while (addend > 1)
            {
                sum = sum + addend;
                result = result * sum;
                addend = addend - 2;
            }

            if (n % 2 != 0)
            {
                result = result * (n /2 + 1);
            }

            return result;
        }
    }
}