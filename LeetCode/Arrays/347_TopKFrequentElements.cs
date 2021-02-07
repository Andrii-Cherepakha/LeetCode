using LeetCode.DataStructure;
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

        public int[] TopKFrequent_MaxHeap(int[] nums, int k)
        {

            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                dict[num] = dict.ContainsKey(num) ? dict[num] + 1 : 1;
            }

            var heap = new MaxHeap(nums.Length);

            foreach (var key in dict.Keys)
            {
                var node = new HeapNode(dict[key], key);
                heap.Push(node);
            }

            var res = new int[k];
            int i = 0;

            while (!heap.IsEmpty && i < k)
            {
                var node = heap.Pop();
                res[i] = node.Value;
                i++;
            }

            return res;
        }

        public int[] TopKFrequent_MinHeap(int[] nums, int k)
        {

            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                dict[num] = dict.ContainsKey(num) ? dict[num] + 1 : 1;
            }

            var heap = new MinHeap(k);
            int i = 0;

            foreach (var key in dict.Keys)
            {
                var node = new HeapNode(dict[key], key);

                if (i < k)
                {
                    heap.Push(node);
                }
                else
                {
                    var head = heap.Peek();
                    if (dict[key] > head.Key)
                    {
                        heap.Pop();
                        heap.Push(node);
                    }
                }

                // dict.Remove(key);            
                i++;
            }

            var res = new int[k];
            i = 0;
            while (!heap.IsEmpty)
            {
                var node = heap.Pop();
                res[i] = node.Value;
                i++;
            }

            return res;
        }
    }
}
