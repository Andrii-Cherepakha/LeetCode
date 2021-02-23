using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.AmazonTop
{
    class _380_InsertDeleteGetRandom
    {
        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (dict.ContainsKey(val)) return false;

            list.Add(val);
            dict.Add(val, list.Count - 1);
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!dict.ContainsKey(val)) return false;

            int lastKey = list.ElementAt(list.Count - 1);
            dict[lastKey] = dict[val];
            list[dict[lastKey]] = lastKey;

            list.RemoveAt(list.Count - 1);
            dict.Remove(val);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            int index = rand.Next(0, list.Count);
            return list.ElementAt(index);
        }

        private List<int> list = new List<int>();
        private Dictionary<int, int> dict = new Dictionary<int, int>(); // key, index
        private Random rand = new Random();
    }
}
