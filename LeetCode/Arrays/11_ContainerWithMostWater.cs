using NUnit.Framework;
using System;

namespace LeetCode.Arrays
{
    public class ContainerWithMostWater
    {
        [Test]
        public void Print()
        {
            var arr = new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < arr.Length; j++)
                {
                    int width = j - i;
                    int height = Math.Min(arr[i], arr[j]);
                    Console.Write("     " + width * height);

                }
            }
        }

        [Test]
        public void Test()
        {
            var arr = new[] {1, 8, 6, 2, 5, 4, 8, 3, 7};
            int expected = 49;
            Assert.That(MaxArea(arr), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            var arr = new[] { 1, 8, 6, 50, 50, 4, 8, 3, 7 };
            int expected = 50;
            Assert.That(MaxArea(arr), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            var arr = new[] { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 20, 1, 6 };
            int expected = 60; // ???
            Assert.That(MaxArea(arr), Is.EqualTo(expected));
        }

        public int MaxArea(int[] height)
        {
            int i = 0;
            int j = height.Length - 1;
            int maxVolume = 0;
            while (i < j)
            {
                int volume = (j - i) * Math.Min(height[i], height[j]);
                maxVolume = Math.Max(maxVolume, volume);

                if (height[i] < height[j])
                {
                    // left line is lower than right line => go to the right
                    i++;
                }
                else
                {
                    // right line is lower than left line => go to the left
                    j--;
                }
            }

            return maxVolume;
        }
    }
}
