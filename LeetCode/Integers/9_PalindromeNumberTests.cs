using NUnit.Framework;

namespace LeetCode.Integers
{
    public class PalindromeNumberTests
    {
        //private PalindromeNumberString _solution = new PalindromeNumberString();
        //private PalindromeNumber _solution = new PalindromeNumber();
        private PalindromeNumberLeetCode _solution = new PalindromeNumberLeetCode();

        [Test]
        public void TestNegative()
        {
            int x = -100;
            bool expected = false;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test0()
        {
            int x = 0;
            bool expected = true;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            int x = 5;
            bool expected = true;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test55()
        {
            int x = 55;
            bool expected = true;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test555()
        {
            int x = 555;
            bool expected = true;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test1001()
        {
            int x = 1001;
            bool expected = true;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test10001()
        {
            int x = 10001;
            bool expected = true;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test12521()
        {
            int x = 12521;
            bool expected = true;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test125521()
        {
            int x = 125521;
            bool expected = true;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test10()
        {
            int x = 10;
            bool expected = false;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test15()
        {
            int x = 15;
            bool expected = false;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test100()
        {
            int x = 100;
            bool expected = false;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test152()
        {
            int x = 152;
            bool expected = false;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test12522()
        {
            int x = 12522;
            bool expected = false;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test12531()
        {
            int x = 12531;
            bool expected = false;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test125522()
        {
            int x = 125522;
            bool expected = false;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test125421()
        {
            int x = 125421;
            bool expected = false;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

        [Test]
        public void Test1345605431()
        {
            int x = 1345605431;
            bool expected = false;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }
        

        [Test]
        public void TestMaxValue()
        {
            int x = int.MaxValue;
            bool expected = false;
            Assert.That(_solution.IsPalindrome(x), Is.EqualTo(expected));
        }

    }
}
