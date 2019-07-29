using NUnit.Framework;

namespace LeetCode.Mathematics
{
    public class ArrangingCoinsSolution
    {
        [Test]
        public void Test1()
        {
            int n = 1804289383;
            int expected = 60070;
            Assert.That(ArrangeCoins(n), Is.EqualTo(expected));
        }

        public int ArrangeCoins(int n)
        {
            return (int)(-1 + System.Math.Sqrt(1 + 8 * (double) n)) / 2;
        }
    }
}