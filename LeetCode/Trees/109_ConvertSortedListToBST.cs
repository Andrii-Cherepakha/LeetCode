using LeetCode.LinkedList;

namespace LeetCode.Trees
{
    public class _109_ConvertSortedListToBST
    {
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null) return null;

            current = head;

            return InOrder(0, GetListLength(head) - 1);
        }

        private ListNode current;

        private TreeNode InOrder(int start, int end)
        {
            if (start > end) return null;

            int mid = start + (end - start + 1) / 2;

            var left = InOrder(start, mid - 1);

            var node = new TreeNode(current.val);
            current = current.next;

            var right = InOrder(mid + 1, end);

            node.left = left;
            node.right = right;

            return node;
        }

        private int GetListLength(ListNode head)
        {
            int l = 0;

            while (head != null)
            {
                l++;
                head = head.next;
            }

            return l;
        }

    }
}
