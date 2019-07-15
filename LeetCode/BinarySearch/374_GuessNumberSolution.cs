using NUnit.Framework;

namespace LeetCode.BinarySearch
{
    public class GuessNumberSolution
    {
        [Test]
        public void Test10_6()
        {
            _guess = 6;
            int length = 10;
            Assert.That(guessNumber(length), Is.EqualTo(_guess));
        }

        [Test]
        public void Test100_25()
        {
            _guess = 25;
            int length = 100;
            Assert.That(guessNumber(length), Is.EqualTo(_guess));
        }

        [Test]
        public void Test1_1()
        {
            _guess = 1;
            int length = 1;
            Assert.That(guessNumber(length), Is.EqualTo(_guess));
        }

        private int _guess;

        // pick a number from 1 to n.
        int guessNumber(int n)
        {
            int start = 1;
            int end = n;

            int position = 1;
            while (start <= end)
            {
                position = start + (end - start) / 2;
                if (guess(position) == 0)
                {
                    break;
                }

                if (guess(position) == 1)
                {
                    start = position + 1;
                }

                if (guess(position) == -1)
                {
                    end = position - 1;
                }
            }

            return position;
        }

        // Forward declaration of guess API.
        // @param num, your guess
        // @return -1 if my number is lower, 1 if my number is higher, otherwise return 0
        int guess(int num)
        {
            if (_guess < num)
            {
                return -1;
            }

            if (_guess > num)
            {
                return 1;
            }

            return 0;
        }
    }
}