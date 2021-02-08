using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCode.Other
{
    public class _146_LRUCache
    {
        [Test]
        public void Test()
        {
            int r = 0;

            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(1, 1); // cache is {1=1}
            lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            r = lRUCache.Get(1);    // return 1
            lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            r = lRUCache.Get(2);    // returns -1 (not found)
            lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            r = lRUCache.Get(1);    // return -1 (not found)
            r = lRUCache.Get(3);    // return 3
            r = lRUCache.Get(4);    // return 4
        }

        [Test]
        public void Test2()
        {
            //  ["LRUCache","put","put","get","put","put","get"]
            //  [[2],       [2,1],[2,2],[2],[1,1],[4,1],[2]]

            int r = 0;

            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(2, 1);
            lRUCache.Put(2, 2);
            r = lRUCache.Get(2);
            lRUCache.Put(1, 1);
            lRUCache.Put(4, 1);
            r = lRUCache.Get(2);
        }
    }
    
    public class LRUCache
    {
        public LRUCache(int capacity)
        {
            _size = 0;
            _capacity = capacity;

            _head = new DoublyLinkedList();
            _tail = new DoublyLinkedList();

            _head.Value = -1000;  // for debug purpose
            _tail.Value = 1000; // for debug purpose

            _head.Next = _tail;
            _tail.Prev = _head;
        }

        public int Get(int key)
        {
            int res = -1;

            if (_storage.ContainsKey(key))
            {
                var node = _storage[key];
                res = node.Value;
                RemoveNode(node);
                AddNodeToHead(node);
                // TODO move node to head: remove node, add to head
            }

            return res;
        }

        public void Put(int key, int value)
        {
            if (_storage.ContainsKey(key))
            {
                var node = _storage[key];
                node.Value = value;
                RemoveNode(node);
                AddNodeToHead(node);
                // TODO move node to head: remove node, add to head         
            }
            else
            {
                if (_size + 1 > _capacity)
                {
                    RemoveNode(_tail.Prev);
                    // TODO remove last element
                }

                var node = new DoublyLinkedList();
                node.Key = key;
                node.Value = value;
                // TODO add the node to head
                AddNodeToHead(node);
                //_storage[key] = node;
            }
        }

        private void AddNodeToHead(DoublyLinkedList node)
        {
            node.Next = _head.Next;
            node.Prev = _head;
            _head.Next.Prev = node;
            _head.Next = node;
            _size++;
            _storage[node.Key] = node;
        }

        private void RemoveNode(DoublyLinkedList node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;

            //var prev = node.Prev;
            //var next = node.Next;

            //prev.Next = next;
            //next.Prev = prev;

            node.Next = null;
            node.Prev = null;
            _size--;
            _storage.Remove(node.Key);
        }

        private int _capacity;
        private int _size;
        private DoublyLinkedList _head;
        private DoublyLinkedList _tail;
        private Dictionary<int, DoublyLinkedList> _storage = new Dictionary<int, DoublyLinkedList>();
    }

    public class DoublyLinkedList
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public DoublyLinkedList Prev { get; set; }
        public DoublyLinkedList Next { get; set; }
    }

}
