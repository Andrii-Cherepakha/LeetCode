using NUnit.Framework;

namespace LeetCode.Dropbox.InMemoryDb
{
    public class InMemoryDb1
    {
        private Dictionary<string, string> storage = new Dictionary<string, string>();

        public void Add(string key, string value)
        {
            storage[key] = value;
        }

        public void Update(string key, string value)
        {
            if (storage.ContainsKey(key))
            {
                storage[key] = value;
            }            
        }

        public void Remove(string key)
        {
            storage.Remove(key);
        }

        public string Get(string key)
        {
            string str;
            storage.TryGetValue(key, out str);
            return str;
        }
    }

    public class InMemoryDb1Test
    {
        [Test]
        public void Test1()
        {
            var db = new InMemoryDb1();
            db.Add("KEY1", "1000");
            var v = db.Get("KEY2");
            Console.WriteLine(v);
            v = db.Get("KEY1");
            Console.WriteLine(v);
        }
    }

}
