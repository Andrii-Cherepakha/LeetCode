// similar to 129, 1022

namespace LeetCode.Trees
{
    class _988_SmallestStringStartingFromLeaf
    {
        public string SmallestFromLeaf(TreeNode root)
        {
            SmallestFromLeaf(root, "");
            return smallest;
        }

        private string smallest = null;

        private void SmallestFromLeaf(TreeNode node, string str)
        {
            if (node == null) return;

            str = (char)(97 + node.val) + str;

            if (node.left == null && node.right == null)
            {
                smallest = GetSmallest(smallest, str);
            }

            if (node.left != null) SmallestFromLeaf(node.left, str);
            if (node.right != null) SmallestFromLeaf(node.right, str);
        }

        private string GetSmallest(string str1, string str2)
        {
            if (str1 == null) return str2;
            if (str2 == null) return str1;

            string smallest = "";
            int l = 0;

            if (str1.Length < str2.Length)
            {
                l = str1.Length;
                smallest = str1;
            }
            else if (str2.Length <= str1.Length)
            {
                l = str2.Length;
                smallest = str2;
            }

            for (int i = 0; i < l; i++)
            {
                if (str1[i] == str2[i]) continue;
                if (str1[i] > str2[i]) return str2;
                return str1;
            }

            return smallest;
        }
    }
}
