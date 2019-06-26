using NUnit.Framework;
using System;

namespace LeetCode.LinkedList
{
    public class LinkedListHelper
    {
        public static void PrintList(ListNode head, string msg = "")
        {
            Console.WriteLine("");
            Console.Write(msg);
            while (head != null)
            {
                Console.Write(head.val + " -> ");
                head = head.next;
            }
        }

        public static void CheckSorted(ListNode head)
        {
            while (head != null && head.next != null)
            {
                Assert.That(head.val <= head.next.val);
                head = head.next;
            }
        }
    }
}