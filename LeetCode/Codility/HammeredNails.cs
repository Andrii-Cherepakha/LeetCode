using NUnit.Framework;
using System;

namespace LeetCode.Codility
{
    public class HammeredNails
    {
        [Test]
        public void Test1()
        {
            var arr = new[] { 1, 1, 3, 3, 3, 4, 5, 5, 5, 5 };
            int K = 2;
            var r1 = Solution(arr, K);
            var r2 = SolutionStackOverflow(arr, K);
            Console.WriteLine($"My solution: {r1} StackOverflow: {r2}");
            Assert.That(r1, Is.EqualTo(5));
        }

        [Test]
        public void Test0()
        {
            var arr = new[] { 1, 1, 3, 3, 3, 4, 5, 5, 5, 5 };
            int K = 0;
            var r1 = Solution(arr, K);
            var r2 = SolutionStackOverflow(arr, K);
            Console.WriteLine($"My solution: {r1} StackOverflow: {r2}");
            Assert.That(r1, Is.EqualTo(4));
        }

        [Test]
        public void Test10()
        {
            var arr = new[] { 1, 1, 3, 3, 3, 4, 5, 5, 5, 5 };
            int K = 10;
            var r1 = Solution(arr, K);
            var r2 = SolutionStackOverflow(arr, K);
            Console.WriteLine($"My solution: {r1} StackOverflow: {r2}");
            Assert.That(r1, Is.EqualTo(10));
        }

        [Test]
        public void Test2()
        {
            var arr = new[] { 1, 1, 2, 3, 3, 3, 3, 3, 3, 3 };
            int K = 3;
            var r1 = Solution(arr, K);
            var r2 = SolutionStackOverflow(arr, K);
            Console.WriteLine($"My solution: {r1} StackOverflow: {r2}");
            Assert.That(r1, Is.EqualTo(7));
        }

        [Test]
        public void Test11()
        {
            var arr = new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int K = 3;
            var r1 = Solution(arr, K);
            var r2 = SolutionStackOverflow(arr, K);
            Console.WriteLine($"My solution: {r1} StackOverflow: {r2}");
            Assert.That(r1, Is.EqualTo(10));
        }

        [Test]
        public void Test22()
        {
            var arr = new[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2 };
            int K = 5;
            var r1 = Solution(arr, K);
            var r2 = SolutionStackOverflow(arr, K);
            Console.WriteLine($"My solution: {r1} StackOverflow: {r2}");
            Assert.That(r1, Is.EqualTo(10));
        }

        public int Solution(int[] A, int K)
        {
            int n = A.Length;
            int best = 0;
            int count = 1;
            for (int i = 0; i < n - K - 1; i++)
            {
                if (A[i] == A[i + 1])
                    count = count + 1;
                else
                    //count = 0;
                    count = 1; // current element

                //if (count > best)
                // best = count
                best = Math.Max(best, count + Math.Min(K, n - i - 1)); // if the best is found it does not mean it can be improved since there can be no nails left to the right. But if so, we can use any of nails left.
            }

            //int result = best + 1 + K;
            int result = Math.Max(best, K); // we always can hammer all of them down to 0

            return result;
        }

        // https://stackoverflow.com/questions/60953297/find-the-max-value-of-the-same-length-nails-after-hammered
        public int SolutionStackOverflow(int[] A, int K)
        {
            int best = 0;
            int start = 0;
            while (start < A.Length)
            {
                int end = start;
                while (end < A.Length && A[end] == A[start])
                {
                    ++end;
                }

                // array[start .. (end-1)] is now the subarray consisting of a
                // single value repeated (end-start) times.
                best = Math.Max(best, end - start + Math.Min(K, A.Length - end));

                start = end; // skip to the next distinct value
            }
            // assert best >= Math.min(y + 1, array.Length); // sanity-check
            return best;
        }
    }
}