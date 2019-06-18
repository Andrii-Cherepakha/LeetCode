using NUnit.Framework;

namespace LeetCode.LinkedList
{
    // Hint: add faked head to handle previous element
    public class RemoveLinkedListElements
    {
        [Test]
        public void TestNull()
        {
            RemoveElements(null, 6);
        }

        [Test]
        public void TestOneDelete()
        {
            var head = new ListNode(6);
            LinkedListHelper.PrintList(head, "Original: ");
            head = RemoveElements(head, 6);
            LinkedListHelper.PrintList(head, "Removed: ");
        }

        [Test]
        public void TestOneNoDelete()
        {
            var head = new ListNode(1);
            LinkedListHelper.PrintList(head, "Original: ");
            head = RemoveElements(head, 6);
            LinkedListHelper.PrintList(head, "Removed: ");
        }

        [Test]
        public void TestTwoDelete()
        {
            var head = new ListNode(6);
            head.next = new ListNode(6);
            LinkedListHelper.PrintList(head, "Original: ");
            head = RemoveElements(head, 6);
            LinkedListHelper.PrintList(head, "Removed: ");
        }

        [Test]
        public void TestDeleteAtStartMiddleEnd()
        {
            // 1->2->6->3->4->5->6
            var head = new ListNode(6);
            head.next = new ListNode(6);
            head.next.next = new ListNode(6);
            head.next.next.next = new ListNode(3);
            head.next.next.next.next = new ListNode(6);
            head.next.next.next.next.next = new ListNode(6);
            head.next.next.next.next.next.next = new ListNode(6);

            LinkedListHelper.PrintList(head, "Original: ");
            head = RemoveElements(head, 6);
            LinkedListHelper.PrintList(head, "Removed: ");
        }

        [Test]
        public void TestExample()
        {
            // 1->2->6->3->4->5->6
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(6);
            head.next.next.next = new ListNode(3);
            head.next.next.next.next = new ListNode(4);
            head.next.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next.next = new ListNode(6);

            LinkedListHelper.PrintList(head, "Original: ");
            head = RemoveElements(head, 6);
            LinkedListHelper.PrintList(head, "Removed: ");
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            // Hint: add faked head to handle previous element
            var fakedHead = new ListNode(-1);
            fakedHead.next = head;

            ListNode previous = fakedHead;
            ListNode current = head;

            while (current != null)
            {
                if (current.val == val)
                {
                    previous.next = current.next;
                }
                else
                {
                    previous = current;
                }
                current = current.next;
            }
            
            return fakedHead.next;
        }


        public ListNode RemoveElements1(ListNode head, int val) // handle head
        {
            ListNode previous = null;
            ListNode current = head;

            while (current != null)
            {
                if (current.val == val)
                {
                    if (previous == null) // need to delete a node at head
                    {
                        head = current.next;
                    }
                    if (previous != null)
                    {
                        previous.next = current.next;
                    }
                }
                else
                {
                    previous = current;
                }
                current = current.next;
            }

            return head;
        }
    }
}