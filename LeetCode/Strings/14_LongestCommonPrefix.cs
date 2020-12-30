using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Strings
{
    class _14_LongestCommonPrefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
            
            var result = new StringBuilder();
            
            int length = int.MaxValue;
            foreach (var str in strs)
            {
                length = Math.Min(length, str.Length);
            }

            for (int i = 0; i < length; i++)
            {
                var ch = strs[0][i];
                var theSame = true;
                for (int j = 1; j < strs.Length; j++)
                {
                    theSame = theSame & ch == strs[j][i];
                }

                if (theSame) result.Append(ch); else break;
            }

            return result.ToString();
        }
    }
}
