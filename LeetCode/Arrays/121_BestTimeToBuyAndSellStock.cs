using System;
using NUnit.Framework;

// #max_contiguous_subarray #kadanes_algorithm

namespace LeetCode.Arrays
{
    public class BestTimeToBuyAndSellStock
    {
        [Test]
        public void Test1()
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            int expected = 5;
            Assert.That(MaxProfit(prices), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            int[] prices = { 7, 6, 4, 3, 1 };
            int expected = 0;
            Assert.That(MaxProfit(prices), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            int[] prices = { 7, 8, 9, 10, 11 };
            int expected = 4;
            Assert.That(MaxProfit(prices), Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            int[] prices = { int.MaxValue, 1, 8, 9, 10, 11, int.MaxValue };
            int expected = int.MaxValue - 1;
            Assert.That(MaxProfit(prices), Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            int[] prices = { 100, 500 , 1, 201 };
            int expected = 400;
            Assert.That(MaxProfit(prices), Is.EqualTo(expected));
        }

        public int MaxProfit(int[] prices)
        {
            int maxSum = 0;
            int maxEndingHere = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                int difference = prices[i] - prices[i - 1];
                maxEndingHere = Math.Max(maxEndingHere + difference, difference);
                maxSum = Math.Max(maxSum, maxEndingHere);
            }

            return maxSum;
        }

        public int MaxProfitLeetCode(int[] prices)
        {
            int maxCur = 0, maxSoFar = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                maxCur = Math.Max(0, maxCur += prices[i] - prices[i - 1]);
                maxSoFar = Math.Max(maxCur, maxSoFar);
            }
            return maxSoFar;
        }

        public int MaxProfitN(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            int minPrice = prices[0];
            int maxPrice = prices[0];
            int maxProfit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i]; // found new minimum
                    maxPrice = prices[i]; // reset max price
                }

                if (prices[i] > maxPrice)
                {
                    maxPrice = prices[i];
                    maxProfit = Math.Max(maxProfit, maxPrice - minPrice);
                }
            }

            return maxProfit;
        }

        public int MaxProfitNN(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            int best = 0;

            for(int i = 0; i < prices.Length; i++)
            for (int j = i + 1; j < prices.Length; j++)
            {
                int profit = prices[j] - prices[i];
                if (profit > best)
                {
                    best = profit;
                }
            }

            return best;
        }
    }
}