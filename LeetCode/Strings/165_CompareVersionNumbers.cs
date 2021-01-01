using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Strings
{
    public class _165_CompareVersionNumbers
    {
        public int CompareVersion(string version1, string version2)
        {
            //if (string.IsNullOrEmpty(version1) && string.IsNullOrEmpty(version2)) return 0;
            //if (string.IsNullOrEmpty(version1) && !string.IsNullOrEmpty(version2)) return -1;
            //if (!string.IsNullOrEmpty(version1) && string.IsNullOrEmpty(version2)) return 1;

            var v1 = version1.Split('.').ToList();
            var v2 = version2.Split('.').ToList();

            List<string> listToAddZeros = null;
            int add = Math.Abs(v1.Count - v2.Count);

            if (v1.Count > v2.Count)
            {
                //add = v1.Count - v2.Count;
                listToAddZeros = v2;
            }

            if (v2.Count > v1.Count)
            {
                //add = v2.Count - v1.Count;
                listToAddZeros = v1;
            }

            for (int i = 0; i < add; i++)
            {
                listToAddZeros.Add("0");
            }

            int length = Math.Min(v1.Count, v2.Count);

            for (int i = 0; i < length; i++)
            {
                int i1 = int.Parse(v1[i]);
                int i2 = int.Parse(v2[i]);

                if (i1 < i2) return -1;
                if (i1 > i2) return 1;
            }

            //if (v1.Length == v2.Length) return 0;

            if (v1.Count < v2.Count) return -1;
            if (v1.Count > v2.Count) return 1;

            return 0;
        }
    }
}
