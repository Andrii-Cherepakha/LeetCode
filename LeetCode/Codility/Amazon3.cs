using NUnit.Framework;

namespace LeetCode.Codility
{
    public class Amazon3 
    {
        [Test]
        public void Test1()
        {
            int i = 0;
            int expected = 55;
            var actual = solution("50552");
            Assert.That(actual, Is.EqualTo(expected));
        }

        public int solution(string S)
        {
            int result = 0;

            for (int i = 0; i < S.Length - 1; i++)
            {
                int d = int.Parse(S.Substring(i, 2));
                if (d > result)
                    result = d;
            }

            return result;
        }
    }
}
