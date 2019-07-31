using System.Linq;
using NUnit.Framework;

namespace LeetCode.Strings
{
    public class ValidAnagram
    {
        [Test]
        public void Test1()
        {
            string s = "xaaaabbczy";
            string t = "yaaaabbczx";
            bool expected = true;
            Assert.That(IsAnagram(s,t), Is.EqualTo(expected));
        }

        public bool IsAnagram(string s, string t) //hash
        {
            if (s == null || t == null || s.Length != t.Length)
            {
                return false;
            }

            char[] hash = new char[26];

            for (int i = 0; i < s.Length; i++)
            {
                hash[s[i] - 'a']++;
                hash[t[i] - 'a']--;
            }

            foreach (var slot in hash)
            {
                if (slot != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsAnagramRemove(string s, string t) // remove Time Limit Exceeded

        {
            if (s == null || t == null || s.Length != t.Length)
            {
                return false;
            }

            foreach (var character in s)
            {
                int p = t.IndexOf(character);
                if (p < 0)
                {
                    return false;
                }

                t = t.Remove(p, 1);
            }

            return t.Length == 0;
        }

        public bool IsAnagramSort(string s, string t) // sort
        {
            if (s == null || t == null || s.Length != t.Length)
            {
                return false;
            }

            s = string.Concat(s.OrderBy(c => c));
            t = string.Concat(t.OrderBy(c => c));

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != t[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}