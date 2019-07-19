using NUnit.Framework;

namespace LeetCode.Arrays
{
    public class CanPlaceFlowersSolution
    {
        [Test]
        public void Example1()
        {
            int[] arr = {1, 0, 0, 0, 1};
            int n = 1;
            bool expected = true;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int[] arr = { 1, 0, 0, 0, 1 };
            int n = 2;
            bool expected = false;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void TestAllFlowered()
        {
            int[] arr = { 1, 1, 1, 1, 1 };
            int n = 1;
            bool expected = false;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void TestAllEmpty1True()
        {
            int[] arr = { 0 };
            int n = 1;
            bool expected = true;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void TestAllEmpty1False()
        {
            int[] arr = { 0 };
            int n = 2;
            bool expected = false;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void TestAllEmpty2True()
        {
            int[] arr = { 0, 0 };
            int n = 1;
            bool expected = true;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void TestAllEmpty2False()
        {
            int[] arr = { 0, 0 };
            int n = 2;
            bool expected = false;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void TestAllEmpty3True()
        {
            int[] arr = { 0, 0, 0 };
            int n = 2;
            bool expected = true;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void TestAllEmpty3False()
        {
            int[] arr = { 0, 0, 0 };
            int n = 3;
            bool expected = false;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void TestAllEmpty4True()
        {
            int[] arr = { 0, 0, 0, 0 };
            int n = 2;
            bool expected = true;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void TestAllEmpty4False()
        {
            int[] arr = { 0, 0, 0, 0 };
            int n = 3;
            bool expected = false;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void TestAllEmpty5True()
        {
            int[] arr = { 0, 0, 0, 0, 0 };
            int n = 3;
            bool expected = true;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void TestAllEmpty5False()
        {
            int[] arr = { 0, 0, 0, 0, 0 };
            int n = 4;
            bool expected = false;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            int[] arr = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
            int n = 1;
            bool expected = false;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void Test6()
        {
            int[] arr = { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 };
            int n = 1;
            bool expected = false;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void Test7True()
        {
            int[] arr = { 0, 0, 1, 0, 0 };
            int n = 2;
            bool expected = true;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void Test7False()
        {
            int[] arr = { 0, 0, 1, 0, 0 };
            int n = 3;
            bool expected = false;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void Test8True()
        {
            int[] arr = { 0, 0, 0, 1, 0, 0, 0 };
            int n = 2;
            bool expected = true;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void Test8False()
        {
            int[] arr = { 0, 0, 0, 1, 0, 0, 0 };
            int n = 3;
            bool expected = false;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void Test9True()
        {
            int[] arr = { 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            int n = 4;
            bool expected = true;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        [Test]
        public void Test9False()
        {
            int[] arr = { 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            int n = 5;
            bool expected = false;
            Assert.That(CanPlaceFlowers(arr, n), Is.EqualTo(expected));
        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (flowerbed == null || flowerbed.Length == 0)
            {
                return false;
            }

            if (n == 0)
            {
                return true;
            }

            int flowers = 0;

            if (flowerbed.Length == 1 && flowerbed[0] == 0 && n == 1)
            {
                return true;
            }

            if (flowerbed.Length >= 2 && flowerbed[0] == 0 && flowerbed[1] == 0)
            {
                flowerbed[0] = 1;
                flowers++;
            }

            if (flowerbed.Length >= 2 && flowerbed[flowerbed.Length - 1] == 0 && flowerbed[flowerbed.Length - 2] == 0)
            {
                flowerbed[flowerbed.Length - 1] = 1;
                flowers++;
            }

            int lengthOfEmptySpace = 0;
            foreach (var spot in flowerbed)
            {
                if (spot == 0)
                {
                    lengthOfEmptySpace++;
                }
                else if (spot == 1 && lengthOfEmptySpace > 0)
                {
                    flowers += (lengthOfEmptySpace + 1) / 2 - 1;
                    lengthOfEmptySpace = 0;
                }
            }

            return flowers >= n;
        }
    }
}