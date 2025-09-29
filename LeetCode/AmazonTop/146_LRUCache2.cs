using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.AmazonTop
{
    public class LRUCache2
    {
        Dictionary<int, LinkedListNode<Data>> dict = new Dictionary<int, LinkedListNode<Data>>();

        // a doubly linked list
        // insertion and removal are O(1) 
        // getting the Count property is an O(1)
        // If the LinkedList<T> is empty, the First and Last properties contain null.
        LinkedList<Data> list = new LinkedList<Data>();

        private class Data 
        {
            public int Key;
            public int Value;

            public Data(int key, int value)
            {
                this.Key = key;
                this.Value = value;
            }
        }

        private readonly int capacity;

        public LRUCache2(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("LRU capacity should be positive number.");
            }
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            if (!dict.ContainsKey(key)) 
            {
                return -1;
            }

            var node = dict[key];
            list.Remove(node);
            list.AddFirst(node);

            return node.Value.Value;
        }

        public void Put(int key, int value)
        {
            // Update the value of the key if the key exists.
            if (dict.ContainsKey(key))
            {
                var existingNode = dict[key];
                existingNode.Value.Value = value;

                list.Remove(existingNode);
                list.AddFirst(existingNode);

                return;
            }

            //  If the number of keys exceeds the capacity from this operation, evict the least recently used key.
            if (list.Count+1 > capacity)
            {
                var lastNode = list.Last;
                dict.Remove(lastNode.Value.Key);
                list.RemoveLast();
            }

            // Otherwise, add the key - value pair to the cache.
            var data = new Data(key, value);
            var node = new LinkedListNode<Data>(data);

            dict[key] = node;
            list.AddFirst(node);
        }
    }

    public class LRUCache2Test {
        [Test]
        public void Case1()
        {
            var cache = new LRUCache2(2);
            // ["LRUCache","put","put","get","put","get","put","get","get","get"]
            //       [[2],[1, 1],[2, 2],[1],[3, 3],[2],[4, 4],[1],[3],[4]]
            cache.Put(1, 1);
            cache.Put(2, 2);
            Console.WriteLine(cache.Get(1));
            cache.Put(3, 3);
            Console.WriteLine(cache.Get(2));
            cache.Put(4, 4);
            Console.WriteLine(cache.Get(1));
            Console.WriteLine(cache.Get(3));
            Console.WriteLine(cache.Get(4));
        }
    }
}
