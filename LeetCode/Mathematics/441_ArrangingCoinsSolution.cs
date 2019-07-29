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
            // (x * (x+1)) / 2 = n
            // x*x + x - 2n = 0
            // D = b*b - 4ac = 1 + 8n
            // x = (-b + SQRT(D) ) / 2a = (-1 + SQRT(1 + 8n)) / 2
            return (int)(-1 + System.Math.Sqrt(1 + 8 * (double) n)) / 2;
        }
    }
}