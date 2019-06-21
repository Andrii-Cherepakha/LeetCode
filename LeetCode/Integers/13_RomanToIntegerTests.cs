using System;
using NUnit.Framework;

namespace LeetCode.Integers
{
    public class RomanToIntegerTests
    {
        //private RomanToIntegerRecursion _solution = new RomanToIntegerRecursion();
        private RomanToIntegerLinear _solution = new RomanToIntegerLinear();

        [Test]
        public void Test1()
        {
            string roman = "I";
            int expected = 1;

            //Console.WriteLine(_solution.FindMostSignificant(roman));
            Assert.That(_solution.RomanToInt(roman), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            string roman = "III";
            int expected = 3;

            //Console.WriteLine(_solution.FindMostSignificant(roman));
            Assert.That(_solution.RomanToInt(roman), Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            string roman = "IV";
            int expected = 4;

            //Console.WriteLine(_solution.FindMostSignificant(roman));
            Assert.That(_solution.RomanToInt(roman), Is.EqualTo(expected));
        }

        [Test]
        public void Test9()
        {
            string roman = "IX";
            int expected = 9;

            //Console.WriteLine(_solution.FindMostSignificant(roman));
            Assert.That(_solution.RomanToInt(roman), Is.EqualTo(expected));
        }

        [Test]
        public void Test45()
        {
            string roman = "XLV";
            int expected = 45;

            //Console.WriteLine(_solution.FindMostSignificant(roman));
            Assert.That(_solution.RomanToInt(roman), Is.EqualTo(expected));
        }
        
        [Test]
        public void Test48()
        {
            string roman = "XLVIII";
            int expected = 48;

            //Console.WriteLine(_solution.FindMostSignificant(roman));
            Assert.That(_solution.RomanToInt(roman), Is.EqualTo(expected));
        }

        [Test]
        public void Test49()
        {
            string roman = "XLIX";
            int expected = 49;

            //Console.WriteLine(_solution.FindMostSignificant(roman));
            Assert.That(_solution.RomanToInt(roman), Is.EqualTo(expected));
        }

        [Test]
        public void Test58()
        {
            string roman = "LVIII";
            int expected = 58;

            //Console.WriteLine(_solution.FindMostSignificant(roman));
            Assert.That(_solution.RomanToInt(roman), Is.EqualTo(expected));
        }
        
        [Test]
        public void Test1994()
        {
            string roman = "MCMXCIV";
            int expected = 1994;

            //Console.WriteLine(_solution.FindMostSignificant(roman));
            Assert.That(_solution.RomanToInt(roman), Is.EqualTo(expected));
        }

        [Test]
        public void Test3999()
        {
            string roman = "MMMCMXCIX";
            int expected = 3999;

            //Console.WriteLine(_solution.FindMostSignificant(roman));
            Assert.That(_solution.RomanToInt(roman), Is.EqualTo(expected));
        }
    }
}