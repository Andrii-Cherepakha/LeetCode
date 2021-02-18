using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCode.AmazonTop
{
    class _692_TopKFrequentWords
    {
        [Test]
        public void Test4()
        {
            string[] words = new[] { "i", "love", "leetcode", "i", "love", "coding", "ii", "ii", "lovea", "lovea", "i", "love", "coding" };
            int k = 4;

            TopKFrequent(words, k);
        }

        
        public IList<string> TopKFrequent(string[] words, int k)
        {

            var dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                dict[word] = dict.ContainsKey(word) ? dict[word] + 1 : 1;
            }

            var heap = new MinHeap(k + 1);

            foreach (var key in dict.Keys)
            {
                var node = new HeapNodeWord();
                node.count = dict[key];
                node.word = key;

                heap.Push(node);

                if (heap.Count > k) heap.Pop();
            }

            var res = new List<string>();

            while (heap.Count > 0)
            {
                var node = heap.Pop();
                res.Insert(0, node.word);
                //res.Add(node.word);
            }

            return res;
        }
    }


    public class MinHeap
    {
        public MinHeap(int size)
        {
            arr = new HeapNodeWord[size];
        }

        public void Push(HeapNodeWord node)
        {
            if (++tail >= arr.Length)
                throw new Exception("Heap is full");

            arr[tail] = node;

            int currentIndex = tail;
            int parentIndex = GetParentIndex(currentIndex);

            while (parentIndex >= 0 && FirstIsGreater(arr[parentIndex], arr[currentIndex]))
            {
                arr[currentIndex] = arr[parentIndex];
                arr[parentIndex] = node;

                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        public HeapNodeWord Pop()
        {
            if (tail == -1)
                throw new Exception("Heap is empty");

            var top = arr[0];

            arr[0] = arr[tail];
            arr[tail] = null;
            tail--;

            int currentIndex = 0;

            while (LeftLeafExists(currentIndex))
            {
                int smallest = GetLeftLeafIndex(currentIndex);

                if (RightLeafExists(currentIndex))
                {
                    int ridx = GetRightLeafIndex(currentIndex);

                    if (FirstIsGreater(arr[smallest], arr[ridx]))
                    {
                        smallest = ridx;
                    }
                }

                if (FirstIsGreater(arr[smallest], arr[currentIndex]))
                {
                    break;
                }

                var tmp = arr[smallest];
                arr[smallest] = arr[currentIndex];
                arr[currentIndex] = tmp;

                currentIndex = smallest;
            }

            return top;
        }

        public HeapNodeWord Peek()
        {
            if (tail == -1)
                throw new Exception("Heap is empty");

            return arr[0];
        }

        public int Count => tail + 1;

        private int tail = -1;
        private HeapNodeWord[] arr;

        private int GetParentIndex(int i) => (i - 1) / 2;
        private int GetLeftLeafIndex(int i) => i * 2 + 1;
        private int GetRightLeafIndex(int i) => i * 2 + 2;
        private bool LeftLeafExists(int i) => GetLeftLeafIndex(i) <= tail;
        private bool RightLeafExists(int i) => GetRightLeafIndex(i) <= tail;

        private bool FirstIsGreater(HeapNodeWord node1, HeapNodeWord node2)
        {
            return (node1.count == node2.count) ?
                String.Compare(node1.word, node2.word) == -1 // -1  aaa < zzz
                : node1.count > node2.count;
        }
    }

    public class HeapNodeWord
    {
        public int count;
        public string word;
    }
}
