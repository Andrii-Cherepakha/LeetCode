using System;
using NUnit.Framework;

namespace LeetCode.Strings
{
    public class StringToIntegerTests
    {
        //private StringToInteger _solution = new StringToInteger();
        private StringToIntegerLeetCode _solution = new StringToIntegerLeetCode();

        [Test]
        public void Test42()
        {
            string str = "42";
            int expected = 42;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test42Minus45()
        {
            string str = "42-45";
            int expected = 42;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test42Plus45()
        {
            string str = "42+45";
            int expected = 42;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test42_45()
        {
            string str = "  42 45";
            int expected = 42;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestPlus()
        {
            string str = "    +";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestPlusSpaceNumber()
        {
            string str = "    + 42";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestPlusWord()
        {
            string str = "    +word";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestMinus()
        {
            string str = "      -";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestMinusWord()
        {
            string str = "      -word";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestMinusSpaceNumber()
        {
            string str = "    - 42";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestEmpty()
        {
            string str = "";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TesNull()
        {
            string str = null;
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestSpaces()
        {
            string str = "        ";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestWord()
        {
            string str = "    word    ";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_42()
        {
            string str = "   -42";
            int expected = -42;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test__42()
        {
            string str = "   --42";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_minus_plus_42()
        {
            string str = "   -+42";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_plus_42()
        {
            string str = "   +42";
            int expected = 42;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_plus_plus_42()
        {
            string str = "   ++42";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_plus_minus_42()
        {
            string str = "   +-42";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test4193_with_words()
        {
            string str = "4193 with words";
            int expected = 4193;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test4193Words()
        {
            string str = "4193words";
            int expected = 4193;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_words_and_987()
        {
            string str = "words and 987";
            int expected = 0;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test91283472332()
        {
            string str = "91283472332";
            int expected = Int32.MaxValue;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_91283472332()
        {
            string str = "-91283472332";
            int expected = Int32.MinValue;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test2147483657()
        {
            string str = "2147483657";
            int expected = 2147483647;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test2147483647()
        {
            string str = "2147483647";
            int expected = 2147483647;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test2147483648()
        {
            string str = "2147483648";
            int expected = 2147483647;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_2147483647()
        {
            string str = "  -2147483647";
            int expected = -2147483647;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_2147483657()
        {
            string str = "  -2147483657";
            int expected = int.MinValue;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_2147483648()
        {
            string str = "  -2147483648";
            int expected = -2147483648;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_2147483649()
        {
            string str = "  -2147483649";
            int expected = -2147483648;
            int actual = _solution.MyAtoi(str);
            //Console.WriteLine($"{str} -> {ExtractNumber(str)}");
            Console.WriteLine($"{str} -> {actual}");
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}