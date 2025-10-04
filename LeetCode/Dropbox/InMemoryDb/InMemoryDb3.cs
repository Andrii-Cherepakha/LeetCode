using System.Collections.Concurrent;
using NUnit.Framework;


namespace LeetCode.Dropbox.InMemoryDb
{
    // concurrent
    public class InMemoryDb3<T>
    {
        private ConcurrentDictionary<string, ConcurrentDictionary<string, T>> storage = new ConcurrentDictionary<string, ConcurrentDictionary<string, T>>();

        public void Set(string name, string key, T value)
        {
            /*
            storage.AddOrUpdate(name,
                (k) => {
                    var table = new ConcurrentDictionary<string, T>();
                    table[key] = value;
                    return table;
                },
                (k, table) => {
                    table[key] = value;
                    return table;
                }
                );
            */

            var tab = storage.GetOrAdd(name, _ => new ConcurrentDictionary<string, T>());
            tab[key] = value;
        }

        public T Get(string name, string key)
        {
            ConcurrentDictionary<string, T> table;
            storage.TryGetValue(name, out table);

            if (table == null)
            {
                return default(T);
            }

            return table.TryGetValue(key, out var value) ? value : default(T);
        }

        public bool Delete(string name, string key)
        {
            return storage.TryGetValue(name, out var table) && table.TryRemove(key, out var v);
        }


        public IEnumerable<KeyValuePair<string, T>> Query(string name, Func<string, T, bool> predicate)
        {
            var result = new List<KeyValuePair<string, T>>();

            if (storage.TryGetValue(name, out var table))
            {
                result = table.Where(kv => predicate(kv.Key, kv.Value)).ToList();
            }

            return result;
        }
    }

    public class InMemoryDb3Test
    {
        [Test]
        public void Test()
        {
            var db = new InMemoryDb3<int>();

            Parallel.For(0, 10,
                i => {
                    db.Set("TABLE1", "KEY1", i);
                });

            Console.WriteLine(db.Get("TABLE1", "KEY1"));
        }

        [Test]
        public void TestQuery()
        {
            var db = new InMemoryDb3<int>();
            db.Set("TABLE1", "KEY10", 0);
            db.Set("TABLE1", "KEY11", 1);
            db.Set("TABLE1", "KEY12", 2);
            db.Set("TABLE1", "KEY13", 3);
            db.Set("TABLE1", "KEY14", 4);
            db.Set("TABLE1", "KEY15", 5);
            db.Set("TABLE1", "KEY20", 0);
            db.Set("TABLE1", "KEY21", 2);
            db.Set("TABLE1", "KEY22", 3);
            db.Set("TABLE1", "KEY23", 7);
            db.Set("TABLE1", "KEY24", 8);
            var r = db.Query("TABLE1", (k, v) => v > 1 && v < 5);
            foreach (var i in r)
            {
                Console.WriteLine(i.Key + " " + i.Value);
            }
        }
    }
}
