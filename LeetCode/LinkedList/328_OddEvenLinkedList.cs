namespace LeetCode.LinkedList
{
    class OddEvenLinkedList
    {
        public ListNode OddEvenListEvenHead(ListNode head)
        {
            if (head == null) return null;

            ListNode odd = head;
            ListNode even = head.next;
            ListNode evenHead = head.next;

            while (even != null && even.next != null)
            {
                // change links
                odd.next = even.next;
                even.next = even.next.next;
                // move forward
                odd = odd.next;
                even = even.next;
            }

            odd.next = evenHead;

            return head;
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) return null;

            ListNode lastOdd = head;
            ListNode lastEven = head.next;

            while (lastEven != null && lastEven.next != null)
            {
                ListNode nextOdd = lastEven.next;
                // swap
                lastEven.next = nextOdd.next; // now last even points to next even
                nextOdd.next = lastOdd.next; // now next odd points to first even
                lastOdd.next = nextOdd; // now prev odd points to last odd (last folows by prev)
                // move forward
                lastOdd = nextOdd; // now prev odd becomes next (or latest) odd
                lastEven = lastEven.next;
            }
            
            return head;
        }

        public ListNode OddEvenList1(ListNode head)
        {
            ListNode prevOdd = head;
            ListNode nextOdd = head;
            int cnt = 1; // 2

            while (true)
            {
                ListNode lastEven = prevOdd; // start with latest odd
                for (int i = 0; i < cnt; i++)
                {
                    if (lastEven == null) return head;
                    lastEven = lastEven.next; // find last even
                }

                if (lastEven == null || lastEven.next == null) return head;
                nextOdd = lastEven.next;

                // swap
                lastEven.next = nextOdd.next; // now last even points to next even
                nextOdd.next = prevOdd.next; // now next odd points to first even
                prevOdd.next = nextOdd; // now prev odd points to last odd (last foloows by prev)
                // move forward
                cnt++;
                prevOdd = nextOdd; // now prev odd becomes next (or latest) odd
            }            
        }
    }
}
