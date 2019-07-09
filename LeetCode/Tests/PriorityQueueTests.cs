using LeetCode.DataStructure;
using NUnit.Framework;
using System;

namespace LeetCode.Tests
{
    class PriorityQueueTests
    {

        [Test]
        public void PriorityQueuePush1()
        {
            var queue = new BinaryHeapMax(7); // PriorityQueue
            queue.Push(1);
            queue.Push(2);
            queue.Push(3);
            queue.Push(4);
            queue.Push(5);
            queue.Push(6);
            queue.Push(7);

            var arr = queue.Array;
        }

        [Test]
        public void PriorityQueuePush2()
        {
            var queue = new BinaryHeapMax(7); // PriorityQueue
            queue.Push(7);
            queue.Push(6);
            queue.Push(5);
            queue.Push(4);
            queue.Push(3);
            queue.Push(2);
            queue.Push(1);

            var arr = queue.Array;
        }

        [Test]
        public void PriorityQueuePop1()
        {
            var queue = new BinaryHeapMax(7);  // PriorityQueue
            queue.Push(1);
            queue.Push(2);
            queue.Push(3);
            queue.Push(4);
            queue.Push(5);
            queue.Push(6);
            queue.Push(7);

            // pop
            while (!queue.IsEmpty)
            {
                int top = queue.Pop();
                var arr = queue.Array;
                Console.WriteLine(top);
            }
        }

        [Test]
        public void PriorityQueuePop2()
        {
            var queue = new BinaryHeapMax(7);  // PriorityQueue
            queue.Push(7);
            queue.Push(6);
            queue.Push(5);
            queue.Push(4);
            queue.Push(3);
            queue.Push(2);
            queue.Push(1);

            // pop
            while (!queue.IsEmpty)
            {
                int top = queue.Pop();
                var arr = queue.Array;
                Console.WriteLine(top);
            }
        }

        [Test]
        public void PriorityQueuePop3()
        {
            var queue = new BinaryHeapMax(9);  // PriorityQueue
            queue.Push(1);
            queue.Push(12);
            queue.Push(3);
            queue.Push(15);
            queue.Push(5);
            queue.Push(17);
            queue.Push(7);
            queue.Push(19);
            queue.Push(9);

            // pop
            while (!queue.IsEmpty)
            {
                int top = queue.Pop();
                var arr = queue.Array;
                Console.WriteLine(top);
            }
        }

        [Test]
        public void PriorityQueuePop4()
        {
            var queue = new BinaryHeapMax(9);  // PriorityQueue
            queue.Push(1);
            queue.Push(2);
            queue.Push(3);
            queue.Push(4);
            queue.Push(5);
            queue.Push(100);
            queue.Push(50);
            queue.Push(40);
            queue.Push(20);

            // pop
            while (!queue.IsEmpty)
            {
                int top = queue.Pop();
                var arr = queue.Array;
                Console.WriteLine(top);
            }
        }
    }
}
