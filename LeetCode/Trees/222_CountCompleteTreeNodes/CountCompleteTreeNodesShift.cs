namespace LeetCode.Trees._222_CountCompleteTreeNodes
{
    public class CountCompleteTreeNodesShift : ICountCompleteTreeNodes
    {
        // 1. Вычислили высоту дерева h
        // 2. Посчитали высоту правого поддерева
        // 3.1 Если высота правого поддерева на единицу меньше высоты дерева, то 
        //      3.2.1 последняя нода находится в ПРАВОМ поддереве.
        //      3.2.2 ЛЕВОЕ подерево полное, его высота h-1, у него 2^h - 1 элементов.

        // 3.2 Если нет (высота правого поддерева на двойку меньше высоты дерева), то
        //      3.2.1 последняя нода находится в ЛЕВОМ поддереве.
        //      3.2.2 ПРАВОЕ подерево полное, его высота h-2, у него 2^(h-1)-1 элементов.


        // Otherwise check whether the height of the right subtree is just one less than that of the whole tree,
        // meaning left and right subtree have the same height.

        // * If yes, then the last node on the last tree row is in the right subtree and the left subtree is a full tree of height h-1.
        // So we take the 2^h-1 nodes of the left subtree plus the 1 root node plus recursively the number of nodes in the right subtree.

        // * If no, then the last node on the last tree row is in the left subtree and the right subtree is a full tree of height h-2.
        // So we take the 2^(h-1)-1 nodes of the right subtree plus the 1 root node plus recursively the number of nodes in the left subtree.

        // Since I halve the tree in every recursive step, I have O(log(n)) steps.
        // Finding a height costs O(log(n)). So overall O(log(n)^2).

        public int CountNodes(TreeNode root)
        {
            int h = Height(root);

            //if (h < 0)
            //{
            //    return 0;
            //}

            //var rightH = Height(root.right);
            //int shift;

            //if (rightH == h - 1)
            //{
            //    shift = 1 << h;
            //    return shift + CountNodes(root.right);
            //}
            //else
            //{
            //    shift = 1 << h - 1;
            //    return shift + CountNodes(root.left);
            //}

            return h < 0 ? 0 :
                Height(root.right) == h - 1
                    ? (1 << h) + CountNodes(root.right)
                    : (1 << h - 1) + CountNodes(root.left);
        }

        // The height of a tree can be found by just going left.
        // Let a single node tree have height 0. Find the height h of the whole tree.
        // If the whole tree is empty, i.e., has height -1, there are 0 nodes.
        private int Height(TreeNode root)
        {
            return root == null ? -1 : 1 + Height(root.left);
        }
    }
}