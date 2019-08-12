using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.Strings
{
    public class MinimumWindowSubstring
    {
        [Test]
        public void Example1()
        {
            string s = "ADOBECODEBANC";
            string t = "ABC";
            string expected = "BANC";
            Assert.That(MinWindow(s,t),Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            string s = "AAAABBCCCC";
            string t = "AABBCCC";
            string expected = "AABBCCC";
            Assert.That(MinWindow(s, t), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            string s = "AAA";
            string t = "AABBCCC";
            string expected = "";
            Assert.That(MinWindow(s, t), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            string s = "AABBCCC";
            string t = "AABBCCC";
            string expected = "AABBCCC";
            Assert.That(MinWindow(s, t), Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            string s = "AAAABBCCCCССС";
            string t = "AABBCCC";
            string expected = "AABBCCC";
            Assert.That(MinWindow(s, t), Is.EqualTo(expected));
        }

        [Test]
        public void Test5()
        {
            string s = "AAZQFAABTYUBCRTCCGBHCGHJKUYTССС";
            string t = "AABBCCC";
            string expected = "AABTYUBCRTCC";
            Assert.That(MinWindow(s, t), Is.EqualTo(expected));
        }

        [Test]
        public void Test6()
        {
            string s = "AAZQFAABTYUBCRTGBHCGHJKUYT";
            string t = "AABBCCC";
            string expected = "";
            Assert.That(MinWindow(s, t), Is.EqualTo(expected));
        }


        public string MinWindow(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length)
            {
                return "";
            }

            var reference = new Dictionary<char, int>(); // dictionary with number of each character in t
            var work = new Dictionary<char, int>(); // dictionary with just needed characters from t

            foreach (var ch in t)
            {
                if (reference.ContainsKey(ch))
                {
                    reference[ch]++;
                }
                else
                {
                    reference.Add(ch, 1);
                    work.Add(ch, 0);
                }
            }

            int minLength = int.MaxValue;
            int minStart = 0; // start of the min window
            int minEnd = 0; // end of the min window
            int left = 0; // left pointer

            for (int i = 0; i < s.Length; i++) // go through S
            {
                if (work.ContainsKey(s[i])) // if we found needed character
                {
                    work[s[i]]++;
                }
                while (ContainsWindow(reference, work))
                {
                    int currentLength = i + 1 - left;
                    if (currentLength < minLength) // current window length is less that min so far
                    {
                        minLength = currentLength;
                        minStart = left;
                        minEnd = i;
                    }
                    if (work.ContainsKey(s[left])) // if 'left' character is from T
                    {
                        work[s[left]]--;
                    }
                    left++;
                }
            }

            return minLength == int.MaxValue ? "" : s.Substring(minStart, minEnd - minStart + 1);
        }

        private bool ContainsWindow(Dictionary<char, int> reference, Dictionary<char, int> work)
        {
            foreach (var key in reference.Keys)
            {
                if (work[key] < reference[key]) return false;
            }

            return true;
        }
    }
}