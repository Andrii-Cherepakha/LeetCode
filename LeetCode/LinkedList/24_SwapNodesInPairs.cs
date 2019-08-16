
namespace LeetCode.LinkedList
{
    class SwapNodesInPairs
    {

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode current = head;
            head = head.next;
            ListNode previous = null;

            while (current != null && current.next != null)
            {
                ListNode tmp = current.next.next;
                current.next.next = current;
                if (previous != null) previous.next = current.next;
                current.next = tmp;
                previous = current;
                current = tmp;
            }

            return head;
        }
    }
}
