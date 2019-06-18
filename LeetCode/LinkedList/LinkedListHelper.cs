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

    }
}