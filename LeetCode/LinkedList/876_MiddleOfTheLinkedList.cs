namespace LeetCode.LinkedList
{
    class MiddleOfTheLinkedList
    {

        public ListNode MiddleNode(ListNode head)
        {
            ListNode turtle = head;
            ListNode hare = head;

            while (hare != null && hare.next != null)
            {
                turtle = turtle.next;
                hare = hare.next.next;
            }

            return turtle;
        }
            public ListNode MiddleNode1(ListNode head)
        {
            var fake = new ListNode(-1);
            fake.next = head;

            ListNode turtle = fake;
            ListNode hare = fake;

            while (hare != null)
            {
                turtle = turtle.next;
                hare = hare.next;
                if (hare != null)
                {
                    hare = hare.next;
                }
            }

            return turtle;
        }
    }
}
