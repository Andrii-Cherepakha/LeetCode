
namespace LeetCode.Mathematics
{
    class _509_FibonacciNumber
    {
        public int Fib(int n)
        {
            if (n <= 1) return n;
            if (n == 2) return 2;

            int cur = 0;
            int prev1 = 1;
            int prev2 = 1;

            for (int i = 3; i <=n; i++)
            {
                cur = prev1 + prev2;
                prev2 = prev1;
                prev1 = cur;
            }

            return cur;
        }
    }
}
