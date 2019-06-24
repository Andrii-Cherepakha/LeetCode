using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCode.LinkedList
{
    public class LinkedListCycle
    {
        [Test]
        public void ListCycled()
        {
            var head = new ListNode(3);

            var node1 = new ListNode(2);
            head.next = node1;

            var node2 = new ListNode(0);
            node1.next = node2;

            var node3 = new ListNode(-1);
            node2.next = node3;


            node3.next = node1; // Cycle

            bool expected = true;
            bool actual = HasCycle(head);

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

            bool expected = false;
            bool actual = HasCycle(head);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ListOneNode()
        {
            var head = new ListNode(3);

            bool expected = false;
            bool actual = HasCycle(head);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ListTwoNodesNotCycled()
        {
            var head = new ListNode(3);

            var node1 = new ListNode(2);
            head.next = node1;

            bool expected = false;
            bool actual = HasCycle(head);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ListTwoNodesCycled()
        {
            var head = new ListNode(3);

            var node1 = new ListNode(2);
            head.next = node1;

            node1.next = head; // cycle

            bool expected = true;
            bool actual = HasCycle(head);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // considering two pointers at different speed - a slow pointer and a fast pointer.
        // The slow pointer moves one step at a time while the fast pointer moves two steps at a time.
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (fast == slow)
                {
                    return true;
                }
            }

            return false;

            //if (head == null || head.next == null)
            //{
            //    return false;
            //}

            //ListNode slow = head;
            //ListNode fast = head.next.next;

            //while (slow != fast)
            //{
            //    if (fast == null || fast.next == null)
            //    {
            //        return false;
            //    }

            //    slow = slow.next;
            //    fast = fast.next.next;
            //}


            //return true;
        }
        
        // O(N) additional space
        public bool HasCycleHashTable(ListNode head) // HashTable
        {
            var nodes = new Dictionary<ListNode, int>();

            while (head != null)
            {
                if (nodes.ContainsKey(head))
                {
                    return true;
                }
                else
                {
                    nodes.Add(head, 1);
                }

                head = head.next;
            }

            return false;
        }
    }
}