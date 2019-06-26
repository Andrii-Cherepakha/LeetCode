using NUnit.Framework;

namespace LeetCode.LinkedList
{
    public class RemoveNthNodeFromEndofList
    {
        [Test]
        public void Test2()
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

            var result = RemoveNthFromEnd(head, 2);
        }

        [Test]
        public void Test1()
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

            var result = RemoveNthFromEnd(head, 1);
        }

        [Test]
        public void Test3()
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

            var result = RemoveNthFromEnd(head, 3);
        }

        [Test]
        public void Test4()
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

            var result = RemoveNthFromEnd(head, 4);
        }

        [Test]
        public void Test5()
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

            var result = RemoveNthFromEnd(head, 5);
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode current = head;
            ListNode nBehind = head;

            for (int i = 0; i < n; i++)
            {
                // Given n will always be valid. No need this IF
                if (current == null)
                {
                    break;
                }
                current = current.next;
            }

            if (current == null)
            {
                return head.next;
            }

            // go till the end
            while (current.next != null)
            {
                current = current.next;
                nBehind = nBehind.next;
            }

            // delete node
            nBehind.next = nBehind.next.next;

            return head;
        }
    }
}