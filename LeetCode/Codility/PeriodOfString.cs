using NUnit.Framework;

namespace LeetCode.Codility
{
    public class PeriodOfString
    {
        [Test]
        public void Test1()
        {
            int N = 955;
            int expected = 4;
            int actual = solution(N);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            int N = 5;
            int expected = -1;
            int actual = solution(N);
            Assert.That(actual, Is.EqualTo(expected));
        }

        public int solution(int n)
        {
            int[] d = new int[30];
            int l = 0;
            int p;
            while (n > 0)
            {
                d[l] = n % 2;
                n /= 2;
                l++;
            }

            for (p = 1; p < 1 + l/2; ++p) // for (p = 1; p < 1 + l; ++p)
            {
                int i;
                bool ok = true;
                for (i = 0; i < l - p; ++i)
                {
                    if (d[i] != d[i + p])
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    return p;
                }
            }
            return -1;

        }
    }
}
