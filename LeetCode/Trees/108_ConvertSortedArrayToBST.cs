namespace LeetCode.Trees
{
    public class _108_ConvertSortedArrayToBST
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            //if (nums == null) return null;

            //return AddNode(nums, 0, nums.Length - 1);
            if (nums == null) return null;

            return InOrder(nums, 0, nums.Length - 1);
        }

        private TreeNode AddNode(int[] nums, int start, int end)
        {
            if (start > end) return null;

            int mid = start + (end - start + 1) / 2; // +1 !!!
            //int mid = (start + end  + 1) / 2;

            TreeNode node = new TreeNode(nums[mid]);
            // node.val = nums[mid];
            node.left = AddNode(nums, start, mid - 1);
            node.right = AddNode(nums, mid + 1, end);

            return node;
        }

        private TreeNode InOrder(int[] nums, int start, int end)
        {
            if (start > end) return null;
            
            int mid = start + (end - start + 1) / 2;

            var left = InOrder(nums, start, mid - 1);

            var node = new TreeNode(nums[mid]);
            i++;

            var right = InOrder(nums, mid + 1, end);

            node.left = left;
            node.right = right;

            return node;
        }

        private int i = 0;
    }
}
