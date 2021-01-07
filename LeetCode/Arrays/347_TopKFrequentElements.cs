using System.Collections.Generic;

namespace LeetCode.Arrays
{
    class _347_TopKFrequentElements
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            var result = new int[k];

            if (nums == null || nums.Length == 0) return result;

            var dict = new Dictionary<int, int>();

            foreach (var num in nums) 
            {
                dict[num] = dict.ContainsKey(num) ? dict[num] + 1 : 1;
            }
             
            while (k > 0 && dict.Count > 0)
            {
                int max = 0;
                int key = 0;

                foreach (var num in dict.Keys)
                {
                    if (dict[num] > max)
                    {
                        max = dict[num];
                        key = num;
                    }
                }

                result[result.Length - k] = key;
                dict.Remove(key);

                k--;
            }

            return result;
        }
    }
}
