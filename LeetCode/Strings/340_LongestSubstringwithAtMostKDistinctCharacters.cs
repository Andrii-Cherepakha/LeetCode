using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace LeetCode.Strings
{
    public class LongestSubstringwithAtMostKDistinctCharacters
    {
        [Test]
        public void Test1()
        {
            var r = Get("aabbbccccabcbbbxaabb", 2);
            Console.WriteLine(r);
        }

        [Test]
        public void Test2()
        {
            var r = Get("aabbbccccabcbbbxaabb", 3);
            Console.WriteLine(r);
        }

        [Test]
        public void Test3()
        {
            var r = Get("aaabbbbcccccxbbb", 3);
            Console.WriteLine(r);
        }

        [Test]
        public void Test4()
        {
            var r = Get("aaabbbbcccccxbbb", 30);
            Console.WriteLine(r);
        }

        [Test]
        public void Test5()
        {
            var r = Get("aaabbbbcccccxbbb", 4);
            Console.WriteLine(r);
        }

        [Test]
        public void Test6()
        {
            var r = Get("qwertyuiop", 5);
            Console.WriteLine(r);
        }

        public string Get(string str, int k)
        {
            if (string.IsNullOrEmpty(str)) return str;

            var dict = new Dictionary<char, int>();
            int start = 0;
            int max = 0;
            int maxStart = 0;
            int maxEnd = str.Length - 1;

            for (int i=0; i < str.Length; i++)
            {
                char ch = str[i];

                dict[ch] = dict.ContainsKey(ch) ? dict[ch] + 1 : 1;

                if (dict.Keys.Count > k)
                {
                    if (i - start > max)
                    {
                        max = i - start;
                        maxStart = start;
                        maxEnd = i - 1;
                    }
                    
                    while (start < i && dict.Keys.Count > k)
                    {
                        dict[str[start]]--;
                        if (dict[str[start]] == 0) dict.Remove(str[start]);
                        start++;
                    }
                }
            }

            return str.Substring(maxStart,  maxEnd - maxStart + 1);
        }
    }
}
