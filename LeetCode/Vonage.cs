using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Vonage
    {
        [Test]
        public void Vonage1()
        {
            //int a = solution(553);
            //int a2 = solution(1234);
            //int a3 = solution(9876);
            //int a6 = solution(1426);
            //int a4 = solution(100);
            //int a5 = solution(10000);
            //int a7 = solution(1122);

            int s2 = solution(new[] { 0, 3, 3, 7, 5, 3, 11, 1 });
        }

        public int solution(int N)
        {
            // get numerics
            List<int> numerics = new List<int>();
            while (N > 0)
            {
                int numeric = N % 10;
                numerics.Add(numeric); // we can add it and sort at the same moment with log(N) time. Let;s make it simple for now
                N = N / 10;
            }

            numerics = numerics.OrderByDescending(i => i).ToList(); // N log (N). Can avoid if add and sort at the same time

            int max = 0;
            foreach (int numeric in numerics)
            {
                max = max * 10 + numeric;
            }

            return max;
        }
        
        // Find minimum distance between values in array.
        public int solution(int[] A)
        {
            var dict = new Dictionary<int, int>();
            foreach (int number in A)
            {
                if (!dict.ContainsKey(number))
                {
                    dict[number] = 0;
                }
            }

            int minDistance = int.MaxValue;
            bool adjacentExists = false;

            for (int p = 0; p < A.Length; ++p)
            {
                for (int q = p + 1; q < A.Length; ++q)
                {
                    int start, end;
                    if (A[p] > A[q])
                    {
                        start = A[q] + 1;
                        end = A[p] - 1;
                    }
                    else
                    {
                        start = A[p] + 1;
                        end = A[q] - 1;
                    }

                    if (start <= end)
                    {
                        bool adjacent = true;
                        foreach (int key in dict.Keys)
                        {
                            if (key >= start && key <= end)
                            {
                                adjacent = false;
                                break;
                            }
                        }
                        if (!adjacent)
                        {
                            continue;
                        }
                    }

                    adjacentExists = true;
                    minDistance = Math.Min(minDistance, Math.Abs(A[p] - A[q]));
                }
            }

            if (minDistance > 100000000)
            {
                minDistance = -1;
            }

            if (!adjacentExists)
            {
                minDistance = -2;
            }

            return minDistance;
        }

        [Test]
        public void Vonage2()
        {
            //int s2 = solution(new[] { 0, 3, 3, 7, 5, 3, 11, 1 });
            //int s2 = solution(new[] { -2147483648, 2147483647 });
            int s2 = solution(new[] { -2147483648, 2147483647, 0 });
        }
    }
}
