
using System.Collections.Generic;

namespace LeetCode.Dropbox
{
    public class LRUCache
    {
        private class Data
        {
            public int Key { get; private set; }
            public int Value { get; set; }

            public Data(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly int _capacity;
        private readonly Dictionary<int, LinkedListNode<Data>> dict = new Dictionary<int, LinkedListNode<Data>>(); // get == O(1)
        private readonly LinkedList<Data> list = new LinkedList<Data> (); // add, remove, count == O(1)

        public LRUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            // Return the value of the key if the key exists, otherwise return -1.
            if (!dict.ContainsKey(key))
            {
                return -1;
            }

            var data = dict[key];
            list.Remove(data);
            list.AddFirst(data);

            return data.Value.Value;
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

            // If the number of keys exceeds the capacity from this operation, evict the least recently used key.
            if (list.Count+1 > _capacity)
            {
                var lastKey = list.Last.Value.Key;
                dict.Remove(lastKey);
                list.RemoveLast();
            }

            var data = new Data(key, value);
            var node = new LinkedListNode<Data>(data);

            dict[key] = node;
            list.AddFirst(node);
        }
    }
}
