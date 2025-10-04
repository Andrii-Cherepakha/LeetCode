using System;
using System.Collections.Concurrent;
using NUnit.Framework;

namespace LeetCode
{
    public class DataTypes
    {
        public void Data()
        {
            // List<T> Add(T) Remove(T) Find(i => i == 5) Contains(T) Clear()
            var list = new List<int>();
            list.Add(5);
            // list.AddRange();
            list.Remove(5);
            list.Find(i => i == 5);
            list.Contains(5);
            list.Clear();

            // LinkedList<T> AddFirst() AddLast() First Last RemoveFirst() RemoveLast()
            // LinkedListNode<T> Previous Next Value
            var ll = new LinkedList<int>();
            ll.AddFirst(1);
            ll.AddLast(1);
            var i = ll.First;
            i = ll.Last;
            ll.RemoveFirst();
            ll.RemoveLast();
            LinkedListNode<int> n;
            // n.Previous;
            var p = ll.First.Previous;
            var nx = ll.First.Next;

            // Dictionary<int, int> Add(key, value) Remove(key) ContainsKey(key) ContainsValue(value) Keys Values Clear()
            int key = 0; int value = 0;
            var dict = new Dictionary<int, int>();
            dict[key] = value;
            dict.Add(key, value);
            dict.ContainsKey(key);
            dict.Remove(key);
            dict.ContainsValue(value);
            var keys = dict.Keys;
            var Values = dict.Values;
            dict.Clear();

            // HashSet<int> Add(1) Remove(1) Contains(1) Clear()
            // UnionWith(list) IntersectWith(list) ExceptWith(list)
            // IsSubsetOf(list) Overlaps(list) SetEquals(list)
            var set = new HashSet<int>();
            set.Add(1);
            set.Remove(1);
            set.Contains(1);
            set.UnionWith(list);
            set.IntersectWith(list);
            set.ExceptWith(list);
            set.IsSubsetOf(list);
            set.Overlaps(list);
            set.SetEquals(list);
            set.Clear();

            var kvp = KeyValuePair.Create(1, 1);
            var k = kvp.Key;
            var v = kvp.Value;
        }

        [Test]
        public void testPQ()
        {
            // PriorityQueue<TElement,TPriority>
            var pq = new PriorityQueue<int, int>();
            int element = 1; int priority = 1;
            pq.Enqueue(element, priority);
            pq.Enqueue(element, priority);
            pq.Dequeue();
            pq.Peek();
            pq.Remove(1, out element, out priority);
            pq.TryPeek(out element, out priority);
            pq.TryDequeue(out element, out priority);

            int v;
            var q = new Queue<int>();
            q.Enqueue(1);
            q.Dequeue();
            q.Contains(1);
            q.Peek();
            q.TryPeek(out v);
            q.TryDequeue(out v);            
        }

        [Test]
        public void Concurrent()
        {
            // using System.Collections.Concurrent;
            var cd = new ConcurrentDictionary<int, int>();
            var b = cd.ContainsKey(1);

            // operations are atomic and are thread-safe
            cd[1] = 5;
            cd.TryAdd(1,1); // false if the key already exists.
            cd.TryUpdate(1, 2, 1); // true if the value with key was equal to comparisonValue and was replaced with newValue; otherwise, false.

            // the code executed by these delegates is not subject to the atomicity of the operation.
            int key = 1; int addValue = 2;
            cd.AddOrUpdate(key, (key) => addValue, (key, oldValue) => oldValue + 1);
            cd.AddOrUpdate(key, addValue, (key, oldValue) => oldValue + 1); // Add if key does not exist, Update if exists
            cd.AddOrUpdate(key, addValue, (k, v) => v + 1); // Add if key does not exist, Update if exists

            cd.GetOrAdd(key, addValue); // Adds if the key does not already exist. Returns the new value, or the existing value if the key exists.
        }

        [Test]
        public void ConcurrentDictExample()
        {
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>();

            // cd[1] = 1;
            Parallel.For(0, 10000, i =>
            {
                // Initial call will set cd[1] = 1.
                // Ensuing calls will set cd[1] = cd[1] + 1
                cd.AddOrUpdate(1, 1, (k, v) => v + 1);
                // cd[1] = cd[1] + 1; // == 2513
            });

            Console.WriteLine("After 10000 AddOrUpdates, cd[1] = {0}, should be 10000", cd[1]);


            // Should return 100, as key 2 is not yet in the dictionary
            int value = cd.GetOrAdd(2, (key) => 100);
            Console.WriteLine("After initial GetOrAdd, cd[2] = {0} (should be 100). cd[2] = {1}", value, cd[2]);

            // Should return 100, as key 2 is already set to that value
            value = cd.GetOrAdd(2, 10000);
            Console.WriteLine("After second GetOrAdd, cd[2] = {0} (should be 100). cd[2] = {1}", value, cd[2]);
        }

        [Test]
        public void ConcurrentBagEx()
        {
            var b = new ConcurrentBag<int>(); // unlike sets, bags support duplicates
            int v;
            bool r;
            b.Add(5);
            b.Add(7);
            r = b.TryPeek(out v);
            Console.WriteLine(r + " " + v);
            r = b.TryTake(out v);
            Console.WriteLine(r + " " + v);
        }

        [Test]
        public void ConcurrentQueueEx()
        {
            int v;
            var cq = new ConcurrentQueue<int>();
            cq.Enqueue(1);
            cq.TryPeek(out v);
            cq.TryDequeue(out v);
        }

        [Test]
        public void TimeDiff()
        {
            //  using System
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now.AddDays(-1);
            Console.WriteLine(dt1 > dt2);
        }
    }
}
