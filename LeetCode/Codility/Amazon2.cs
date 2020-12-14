using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Codility
{
    public class Amazon2
    {

        public class Tree
        {
            public int x;
            public Tree l;
            public Tree r;
        }

        [Test]
        public void Test1()
        {
            Tree root = new Tree();

            int expected = 0;
            var actual = solution(null);
            Assert.That(actual, Is.EqualTo(expected));
        }


        public int solution(Tree T)
        {
            if (T == null) return 0;
            if (T.r == null && T.l == null) return 1;

            var dist = new HashSet<int>();
            return solution(T, dist); 
        }

        private int solution(Tree T, HashSet<int> dist)
        {
            if (T == null)
            {
                return dist.Count();
            }

            if (dist.Add(T.x))
            {
                int left = solution(T.l, dist);
                int right = solution(T.r, dist);
                dist.Remove(T.x);
                return Math.Max(left, right);
            }

            return dist.Count();
        }
    }
}
