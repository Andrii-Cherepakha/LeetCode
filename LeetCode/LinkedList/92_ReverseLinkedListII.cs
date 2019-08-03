using NUnit.Framework;

namespace LeetCode.LinkedList
{
    class ReverseLinkedListII
    {
        [Test]
        public void Example1()
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            LinkedListHelper.PrintList(head);
            var result = ReverseBetween(head, 2, 4);
            LinkedListHelper.PrintList(result);
        }

        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null || m == n)
            {
                return head;
            }

            ListNode fakeHead = new ListNode(-1);
            fakeHead.next = head;

            int index = 0;
            ListNode cur = fakeHead;
            ListNode m_1 = null;
            ListNode next = null;
            ListNode prev = null;

            while (cur != null)
            {
                if (index == m - 1)
                {
                    m_1 = cur;
                    cur = cur.next;
                }
                else if (index >= m && index <= n)
                {
                    next = cur.next;
                    cur.next = prev;
                    prev = cur;
                    cur = next;
                }
                else if (index == n + 1)
                {
                    break;
                }
                else
                {
                    cur = cur.next;
                }

                index++;
            }

            m_1.next.next = cur;
            m_1.next = prev;

            return fakeHead.next;
        }
    }
}
