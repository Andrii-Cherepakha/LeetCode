using NUnit.Framework;

namespace LeetCode.LinkedList
{
    class MergeTwoSortedLists
    {
        [Test]
        public void Test1()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);

            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);

            ListNode result = MergeTwoLists(l1, l2);

            LinkedListHelper.PrintList(result);
            LinkedListHelper.CheckSorted(result);
        }

        [Test]
        public void Test2()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);

            ListNode l2 = null;
            ListNode result = MergeTwoLists(l1, l2);

            LinkedListHelper.PrintList(result);
            LinkedListHelper.CheckSorted(result);
        }

        [Test]
        public void Test3()
        {
            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(2);
            l2.next.next = new ListNode(4);

            ListNode l1 = null;
            ListNode result = MergeTwoLists(l1, l2);

            LinkedListHelper.PrintList(result);
            LinkedListHelper.CheckSorted(result);
        }

        [Test]
        public void Test4()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);
            l1.next.next.next = new ListNode(12);

            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);
            l2.next.next.next = new ListNode(5);
            l2.next.next.next.next = new ListNode(7);

            ListNode result = MergeTwoLists(l1, l2);

            LinkedListHelper.PrintList(result);
            LinkedListHelper.CheckSorted(result);
        }

        [Test]
        public void Test5()
        {
            ListNode l1 = new ListNode(25);
            l1.next = new ListNode(26);
            l1.next.next = new ListNode(42);
            l1.next.next.next = new ListNode(51);

            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);
            l2.next.next.next = new ListNode(5);
            l2.next.next.next.next = new ListNode(26);
            l2.next.next.next.next.next = new ListNode(37);

            ListNode result = MergeTwoLists(l1, l2);

            LinkedListHelper.PrintList(result);
            LinkedListHelper.CheckSorted(result);
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode l3 = new ListNode(-1);
            ListNode start = l3;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    l3.next = l1;
                    l3 = l3.next;
                    l1 = l1.next;
                }
                else
                {
                    l3.next = l2;
                    l3 = l3.next;
                    l2 = l2.next;
                }
            }

            if (l1 != null)
            {
                l3.next = l1;
            }
            else
            {
                l3.next = l2;
            }

            return start.next;
        }
    }
}
