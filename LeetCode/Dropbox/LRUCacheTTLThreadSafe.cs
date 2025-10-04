namespace LeetCode.Dropbox
{
    public class LRUCacheTTLThreadSafe
    {
        private class Data
        {
            public int Key { get; private set; }
            public int Value { get; set; }
            private DateTime ExpiresAt { get; set; }
            public bool Expired => ExpiresAt < DateTime.UtcNow;


            public Data(int key, int value, DateTime expiresAt)
            {
                Key = key;
                Value = value;
                ExpiresAt = expiresAt;
            }
        }

        public LRUCacheTTLThreadSafe(int capacity)
        {
            _capacity = capacity;
        }

        private readonly int _capacity;
        private readonly Dictionary<int, LinkedListNode<Data>> dict = new Dictionary<int, LinkedListNode<Data>>();
        private readonly LinkedList<Data> list = new LinkedList<Data>();
        private readonly object _lock = new object();

        public int Get(int key)
        {
            lock (_lock)
            {
                if (!dict.ContainsKey(key))
                {
                    return -1;
                }

                var node = dict[key];

                // remove expired, return -1
                if (node.Value.Expired)
                {
                    dict.Remove(key);
                    list.Remove(node);
                    return -1;
                }

                // Update TTL?
                list.Remove(node);
                list.AddFirst(node);
                return node.Value.Value;
            }
        }

        public void Put(int key, int value, TimeSpan ttl)
        {
            lock (_lock)
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
        }


        private void RemoveExpired()
        {
            var node = list.Last;
            while (node != null)
            {
                if (node.Value.Expired)
                {
                    list.Remove(node);
                    dict.Remove(node.Value.Key);
                }
                node = node.Previous;
            }
        }
    }
}
