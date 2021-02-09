using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.AmazonTop
{
    class _295_FindMedianfromDataStream
    {
        [Test]
        public void TestAdd()
        {
            AddNum(6);
            AddNum(10);
            AddNum(2);
        }

        [Test]
        public void TestAdd2()
        {
            AddNum(6);
            AddNum(10);
            AddNum(2);
            AddNum(6);
            AddNum(5);
        }

        public void AddNum(int num)
        {
            int p = 0;
            while (_storage.Count > p && _storage.ElementAt(p) < num)
            {
                p++;
            }

            _storage.Insert(p, num);
        }

        public double FindMedian()
        {
            int size = _storage.Count;
            if (size % 2 == 1)
            {
                return _storage.ElementAt(size / 2);
            }
            else
            {
                return ((double)_storage.ElementAt(size / 2 - 1) + (double)_storage.ElementAt(size / 2)) / 2;
            }
        }

        private List<int> _storage = new List<int>();
    }
}
