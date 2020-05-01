using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.Dynamic
{
    public class MakeChange
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(0).Returns(0);
                yield return new TestCaseData(1).Returns(1);
                yield return new TestCaseData(2).Returns(2);
                yield return new TestCaseData(3).Returns(3);
                yield return new TestCaseData(4).Returns(4);
                yield return new TestCaseData(5).Returns(1);
                yield return new TestCaseData(6).Returns(2);
                yield return new TestCaseData(9).Returns(5);
                yield return new TestCaseData(10).Returns(1);
                yield return new TestCaseData(11).Returns(2);
                yield return new TestCaseData(49).Returns(7);
                yield return new TestCaseData(50).Returns(2);
                yield return new TestCaseData(51).Returns(3);
                yield return new TestCaseData(52).Returns(4);
                yield return new TestCaseData(53).Returns(5);
                yield return new TestCaseData(54).Returns(6);
                yield return new TestCaseData(55).Returns(3);
            }
        }

        [TestCaseSource("TestCases")]
        public int MakeChangeTest(int amount)
        {
            return MakeChangeFunc(amount);
        }

        public static IEnumerable TestCasesCoins
        {
            get
            {
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 0).Returns(0);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 1).Returns(1);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 2).Returns(2);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 3).Returns(3);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 4).Returns(4);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 5).Returns(1);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 6).Returns(2);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 9).Returns(5);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 10).Returns(1);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 11).Returns(2);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 49).Returns(7);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 50).Returns(2);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 51).Returns(3);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 52).Returns(4);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 53).Returns(5);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 54).Returns(6);
                yield return new TestCaseData(new List<int> { 1, 5, 10, 25 }, 55).Returns(3);
                yield return new TestCaseData(new List<int> { 1, 6, 10 }, 12).Returns(2);
                yield return new TestCaseData(new List<int> { 1, 6, 10 }, 10).Returns(1);
                yield return new TestCaseData(new List<int> { 1, 6, 10 }, 7).Returns(2);
                yield return new TestCaseData(new List<int> { 1, 6, 10 }, 11).Returns(2);
                yield return new TestCaseData(new List<int> { 1, 6, 10 }, 16).Returns(2);
                yield return new TestCaseData(new List<int> { 1, 6, 10 }, 18).Returns(3);
                yield return new TestCaseData(new List<int> { 1, 6, 10 }, 17).Returns(3);
                yield return new TestCaseData(new List<int> { 1, 6, 10 }, 19).Returns(4);
                yield return new TestCaseData(new List<int> { 1, 6, 10 }, 24).Returns(4);
            }
        }

        [TestCaseSource("TestCasesCoins")]
        public int MakeChangeTestCoins(List<int> coins, int amount)
        {
            return MakeChangeFunc(coins, amount);
        }

        [TestCaseSource("TestCasesCoins")]
        public int MakeChangeTestCoinsWithCache(List<int> coins, int amount)
        {
            return MakeChangeFuncWithCache(coins, amount);
        }


        private int MakeChangeFuncWithCache(List<int> coins, int amount)
        {
            int[] cache = new int[amount + 1];
            for(int i = 0; i < cache.Length; i++) { cache[i] = -1; }
            cache[0] = 0;

            return MakeChangeFuncWithCache(coins, amount, cache);
        }

        // O(c * n), O(c) space
        private int MakeChangeFuncWithCache(List<int> coins, int amount, int[] cache)
        {
            if (cache[amount] >= 0) return cache[amount];

            int minCoins = int.MaxValue;
            foreach (var coin in coins)
            {
                if (amount >= coin)
                {
                    int d = amount / coin;
                    int r = amount % coin;
                    int count = d + MakeChangeFunc(coins, r);
                    if (count < minCoins) minCoins = count;
                }
            }

            cache[amount] = minCoins;

            return minCoins;
        }

        // O(c^n)
        // tree will have a maximum height of c and branch n different ways at each level, 
        // where n is the number of different coins.
        private int MakeChangeFunc(List<int> coins, int amount)
        {
            if (amount == 0) return 0;

            int minCoins = int.MaxValue;
            foreach (var coin in coins)
            {
                if (amount >= coin)
                {
                    int d = amount / coin;
                    int r = amount % coin;
                    int count = d + MakeChangeFunc(coins, r);
                    if (count < minCoins) minCoins = count;
                }   
            }

            return minCoins;
        }

        // greedy algorithm: doesn’t work for arbitrary combinations of coins 
        // (consider 1¢, 6¢, and 10¢ coins and using a greedy algorithm to compute makeChange(12)). 
        private int MakeChangeFunc(int amount)
        {
            if (amount >= 25) return 1 + MakeChangeFunc(amount - 25);
            if (amount >= 10) return 1 + MakeChangeFunc(amount - 10);
            if (amount >= 5) return 1 + MakeChangeFunc(amount - 5);
            if (amount >= 1) return 1 + MakeChangeFunc(amount - 1);
            return 0;
        }
    }
}