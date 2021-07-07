using System.Collections.Generic;

namespace LeetCode.DataStructure
{
    public class TimeMap
    {

        /** Initialize your data structure here. */
        public TimeMap()
        {
            storage = new Dictionary<string, SortedList<int, string>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (!storage.ContainsKey(key))
            {
                var sd = new SortedList<int, string>();
                storage[key] = sd;
                sd[timestamp] = value;
            }
            else
            {
                var sd = storage[key];
                sd[timestamp] = value;
            }
        }

        public string Get(string key, int timestamp)
        {

            SortedList<int, string> sd;
            storage.TryGetValue(key, out sd);

            if (sd == null) return "";

            if (sd.ContainsKey(timestamp)) return sd[timestamp];

            int start = 0;
            int end = sd.Count - 1;

            if (sd.Keys[0] > timestamp) return "";
            if (sd.Keys[end] < timestamp) return sd.Values[end];

            while (start < end)
            {
                int mid = start + (end - start) / 2;
                int ts = sd.Keys[mid];

                if (timestamp > ts)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid;
                }
            }

            return sd.Values[start];
        }

        private Dictionary<string, SortedList<int, string>> storage;
    }


    public class TimeMap_Limit
    {

        /** Initialize your data structure here. */
        public TimeMap_Limit()
        {
            storage = new Dictionary<string, SortedDictionary<int, string>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (!storage.ContainsKey(key))
            {
                var sd = new SortedDictionary<int, string>();
                storage[key] = sd;
                sd[timestamp] = value;
            }
            else
            {
                var sd = storage[key];
                sd[timestamp] = value;
            }
        }

        public string Get(string key, int timestamp)
        {

            var sd = storage[key];

            if (sd == null) return "";

            if (sd.ContainsKey(timestamp)) return sd[timestamp];

            string value = "";

            foreach (var k in sd.Keys)
            {
                if (k > timestamp) break;
                value = sd[k];
            }

            return value;
        }

        private Dictionary<string, SortedDictionary<int, string>> storage;
    }
}
