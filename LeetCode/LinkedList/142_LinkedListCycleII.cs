using NUnit.Framework;
using System;

namespace LeetCode.LinkedList
{
    class LinkedListCycleII
    {
        [Test]
        public void ListCycled3()
        {
            var head = new ListNode(3);

            var node1 = new ListNode(2);
            head.next = node1;

            var node2 = new ListNode(0);
            node1.next = node2;

            var node3 = new ListNode(-1);
            node2.next = node3;
            
            node3.next = node1; // Cycle

            ListNode expected = node1;
            ListNode actual = DetectCycle(head);

            Console.WriteLine($"expected: {expected.val} actual: {actual.val}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ListCycled4()
        {
            var head = new ListNode(1);

            var node1 = new ListNode(2);
            head.next = node1;

            var node2 = new ListNode(3);
            node1.next = node2;

            var node3 = new ListNode(4);
            node2.next = node3;

            var node4 = new ListNode(5);
            node3.next = node4;

            node4.next = node1; // Cycle

            ListNode expected = node1;
            ListNode actual = DetectCycle(head);

            Console.WriteLine($"expected: {expected.val} actual: {actual.val}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ListCycledTo2()
        {
            var head = new ListNode(1);

            var node1 = new ListNode(2);
            head.next = node1;

            var node2 = new ListNode(3);
            node1.next = node2;

            var node3 = new ListNode(4);
            node2.next = node3;

            var node4 = new ListNode(5);
            node3.next = node4;

            node4.next = node2; // Cycle

            ListNode expected = node2;
            ListNode actual = DetectCycle(head);

            Console.WriteLine($"expected: {expected.val} actual: {actual.val}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ListCycled5ToHead()
        {
            var head = new ListNode(1);

            var node1 = new ListNode(2);
            head.next = node1;

            var node2 = new ListNode(3);
            node1.next = node2;

            var node3 = new ListNode(4);
            node2.next = node3;

            var node4 = new ListNode(5);
            node3.next = node4;

            node4.next = head; // Cycle

            ListNode expected = head;
            ListNode actual = DetectCycle(head);

            Console.WriteLine($"expected: {expected.val} actual: {actual.val}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ListNotCycled()
        {
            var head = new ListNode(3);

            var node1 = new ListNode(2);
            head.next = node1;

            var node2 = new ListNode(0);
            node1.next = node2;

            var node3 = new ListNode(-1);
            node2.next = node3;

            ListNode expected = null;
            ListNode actual = DetectCycle(head);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ListOneNodeNotCycled()
        {
            var head = new ListNode(3);

            ListNode expected = null;
            ListNode actual = DetectCycle(head);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ListOneNodeCycled()
        {
            var head = new ListNode(3);
            head.next = head;

            ListNode expected = head;
            ListNode actual = DetectCycle(head);

            Console.WriteLine($"expected: {expected.val} actual: {actual.val}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ListTwoNodesCycled()
        {
            var head = new ListNode(3);

            var node1 = new ListNode(2);
            head.next = node1;

            node1.next = head; // cycle

            ListNode expected = head;
            ListNode actual = DetectCycle(head);

            Console.WriteLine($"expected: {expected.val} actual: {actual.val}");
            Assert.That(actual, Is.EqualTo(expected));
        }

        public ListNode DetectCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            // Find the point where fast meets slow if so (cycle)
            // A----- x1 ------- B ----- x2 --- C ----
            //                   |                   |
            //                   -------- x3 ---------
            // where A == head, B - start of the cycle, C - fast meets slow
            // x1 - distance between A and B
            // x2 - distance between B and C
            // x3 - distance between C and B
            do
            {
                if (fast == null || fast.next == null)
                {
                    return null; // no cycle
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            while (slow != fast);

            // Fast meets slow at node C
            // 1. What is the distance fast moved? x1 + x2 + x3 + x2
            // 2. What is the distance slow moved? x1 + x2
            // 3. What is the relation between those distances?
            // Since fast moved twice faster (2 steps ahead) x1 + x2 + x3 + x2 = 2 * (x1 + x2)
            // => x1 = x3
            // => Start again from the beginning (head) and the meet point. Since the distances x1 = x3
            // they will meet eventually at B (start of the cycle)

            ListNode p1 = head;
            ListNode p2 = slow;
            while (p1 != p2)
            {
                p1 = p1.next;
                p2 = p2.next;
            }

            return p1;
        }

    }
}
