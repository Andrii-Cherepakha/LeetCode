using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LeetCode.Dropbox.InMemoryDb
{
    // Generic, several tables
    public class InMemoryDb2<T>
    {
        private Dictionary<string, Dictionary<string, T>> storage = new Dictionary<string, Dictionary<string, T>>();


        public void Set(string name, string key, T value)
        {
            if (!storage.ContainsKey(name))
            {
                storage[name] = new Dictionary<string, T>();
            }
            var table = storage[name];
            table[key] = value;
        }

        public T Get(string name, string key)
        {
            if(!storage.ContainsKey(name))
            {
                return default(T);
            }

            var table = storage[name];

            return table.TryGetValue(key, out var v) ? v : default(T);
            // return table.ContainsKey(key) ? table[key] : default(T);
        }

        public bool Delete(string name, string key)
        {
            return storage.TryGetValue(name, out var table) && table.Remove(key);

            /*
            Dictionary<string, T> table;
            storage.TryGetValue(name, out table);
            if (table == null)
            {
                return false;
            }

            return table.Remove(key);
            */
        }
    }

    public class InMemoryDb2Test
    {
        [Test]
        public void Test()
        {
            var db = new InMemoryDb2<int>();
            db.Get("table1", "key1");
            db.Delete("table2", "key2");
            db.Set("table3", "key0", 10);
            Console.WriteLine(db.Get("table3", "key0"));
        }
    }
}
