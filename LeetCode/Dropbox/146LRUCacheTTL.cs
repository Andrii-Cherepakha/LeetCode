using NUnit.Framework;

namespace LeetCode.Dropbox
{
    public class LRUCacheTTL
    {
        private class Data
        {
            public int Key {get; private set;}
            public int Value { get; set; }
            public DateTime TTL { get; set; }

            public Data(int key, int value, DateTime ttl)
            {
                Key = key;
                Value = value;
                TTL = ttl;
            }
        }

        public LRUCacheTTL(int capacity)
        {
            _capacity = capacity;
        }

        private readonly int _capacity;
        private Dictionary<int, LinkedListNode<Data>> dict = new Dictionary<int, LinkedListNode<Data>>();
        private LinkedList<Data> list = new LinkedList<Data>();

        public int Get(int key)
        {
            if (!dict.ContainsKey(key))
            {
                return -1;
            }
            
            var node = dict[key];

            // remove expired, return -1
            if (node.Value.TTL < DateTime.UtcNow)
            {
                dict.Remove(key);
                list.Remove(node);
                return - 1;
            }

            // Update TTL?
            list.Remove(node);
            list.AddFirst(node);
            return node.Value.Value;
        }

        public void Put(int key, int value, TimeSpan ttl)
        {
            // Update the value of the key if the key exists.
            if (dict.ContainsKey(key))
            {
                var node = dict[key];
                node.Value.Value = value;
                list.Remove(node);
                list.AddFirst(node);
                return;
            }

            // If the number of keys exceeds the capacity from this operation, evict the least recently used key.
            if (list.Count + 1 > _capacity)
            {
                RemoveExpired(); // O(n)
            }                

            if (list.Count + 1 > _capacity)
            {
                var lastNode = list.Last;
                dict.Remove(lastNode.Value.Key);
                list.RemoveLast();
            }

            // Add value
            var data = new Data(key, value, DateTime.UtcNow + ttl);
            list.AddFirst(data);
            dict[key] = list.First;
        }


        private void RemoveExpired()
        {
            var node = list.Last;
            while (node != null)
            {
                if (node.Value.TTL < DateTime.UtcNow)
                {
                    list.Remove(node);
                    dict.Remove(node.Value.Key);
                }
                node = node.Previous;
            }
        }
    }

    public class LRUCacheTTLTest
    {
        [Test]
        public void test1()
        {
            var cache = new LRUCacheTTL(3);
            cache.Get(0);
            cache.Put(1, 10, TimeSpan.FromMicroseconds(10));
            cache.Put(2, 20, TimeSpan.FromMicroseconds(20));
            cache.Put(3, 30, TimeSpan.FromMicroseconds(30));
            cache.Get(1);
            cache.Get(3);
            cache.Put(4, 40, TimeSpan.FromMicroseconds(40));
            cache.Put(5, 50, TimeSpan.FromMicroseconds(50));
        }
    }
}
