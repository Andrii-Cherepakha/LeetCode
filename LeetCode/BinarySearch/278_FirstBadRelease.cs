using NUnit.Framework;

namespace LeetCode.BinarySearch
{
    public class FirstBadRelease
    {
        [Test]
        public void Test1()
        {
            _versions = new bool[] { true };
            int expected = 1;
            Assert.That(FirstBadVersion(1), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            _versions = new bool[] {false, true};
            int expected = 2;
            Assert.That(FirstBadVersion(2), Is.EqualTo(expected));
        }

        [Test]
        public void TestEnd()
        {
            _versions = new bool[] { false, false, false, false, false, true };
            int expected = 6;
            Assert.That(FirstBadVersion(6), Is.EqualTo(expected));
        }

        [Test]
        public void Test8()
        {
            _versions = new bool[] { false, false, false, false, false, true, true, true, true, true };
            int expected = 6;
            Assert.That(FirstBadVersion(10), Is.EqualTo(expected));
        }

        // you have n versions [1, 2, ..., n] 
        private bool[] _versions;

        public int FirstBadVersion(int n)
        {
            int start = 1;
            int end = n;
            while (start < end)
            {
                int position = start + (end - start) / 2;
                if (IsBadVersion(position))
                {
                    end = position;
                }
                else
                {
                    start = position + 1;
                }
            }

            return start;
        }

        // The isBadVersion API is defined in the parent class VersionControl. 
        private bool IsBadVersion(int version)
        {
            return _versions[version - 1];
        }
    }
}