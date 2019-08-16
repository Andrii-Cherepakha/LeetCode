using NUnit.Framework;

namespace LeetCode.Strings
{
    public class BullsAndCows
    {
        [Test]
        public void Example1()
        {
            string secret = "1807";
            string guess = "7810";
            string expected = "1A3B";
            Assert.That(GetHint(secret, guess), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            string secret = "1123";
            string guess = "0111";
            string expected = "1A1B";
            Assert.That(GetHint(secret, guess), Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            string secret = "1111";
            string guess = "1111";
            string expected = "4A0B";
            Assert.That(GetHint(secret, guess), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            string secret = "1";
            string guess = "1";
            string expected = "1A0B";
            Assert.That(GetHint(secret, guess), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            string secret = "1";
            string guess = "2";
            string expected = "0A0B";
            Assert.That(GetHint(secret, guess), Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            string secret = "12";
            string guess = "21";
            string expected = "0A2B";
            Assert.That(GetHint(secret, guess), Is.EqualTo(expected));
        }

        [Test]
        public void TestEmpty()
        {
            string secret = "";
            string guess = "";
            string expected = "0A0B";
            Assert.That(GetHint(secret, guess), Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            string secret = "88758";
            string guess = "78885";
            string expected = "1A4B";
            Assert.That(GetHint(secret, guess), Is.EqualTo(expected));
        }

        // You may assume that
        // the secret number and your friend's guess only contain digits,
        // and their lengths are always equal.
        public string GetHint(string secret, string guess)
        {
            if (secret == null || guess == null) return "0A0B";

            int bull = 0;
            int cows = 0;

            for (int i = guess.Length - 1; i >= 0; i--)
            {
                if (guess[i] == secret[i])
                {
                    bull++;
                    guess = guess.Remove(i,1);
                    secret = secret.Remove(i,1);
                }
            }

            foreach (var ch in guess)
            {
                int p = secret.IndexOf(ch);
                if (p >= 0)
                {
                    cows++;
                    secret = secret.Remove(p, 1);
                }
            }

            //foreach (var ch in guess.Distinct())
            //{
            //    if (secret.Contains(ch))
            //    {
            //        cows++;
            //    }
            //}

            //Console.WriteLine($"{bull}A{cows}B");

            return $"{bull}A{cows}B";
        }
    }
}