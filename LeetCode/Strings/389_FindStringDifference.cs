using NUnit.Framework;

namespace LeetCode.Strings
{
    class FindStringDifference
    {
        [Test]
        public void Test1()
        {
            string s = "abcd";
            string t = "abcde";
            char expected = 'e';

            Assert.That(FindTheDifference(s, t), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            string s = "abcde";
            string t = "abecde";
            char expected = 'e';

            Assert.That(FindTheDifference(s, t), Is.EqualTo(expected));
        }


        public char FindTheDifference(string s, string t)
        {
            string combined = s + t;

            int single = 0;
            foreach (char ch in combined)
            {
                single = single ^ (int) ch;
            }

            return (char) single;
        }
    }
}
