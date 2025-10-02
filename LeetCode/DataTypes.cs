
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
            var n = ll.First.Next;

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
        }
    }
}
