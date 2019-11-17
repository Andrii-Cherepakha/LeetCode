using System.Collections.Generic;

namespace LeetCode.Trees
{
    class SameTree
    {

        public bool IsSameTreeDFT(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null && q != null) return false;
            if (p != null && q == null) return false;

            var pStack = new Stack<TreeNode>();
            var qStack = new Stack<TreeNode>();

            pStack.Push(p);
            qStack.Push(q);

            while (pStack.Count > 0 && qStack.Count > 0)
            {
                var pNode = pStack.Pop();
                var qNode = qStack.Pop();

                if (pNode.val != qNode.val) return false;

                if ((pNode.left != null && qNode.left == null) || (pNode.left == null && qNode.left != null))
                    return false;

                if ((pNode.right != null && qNode.right == null) || (pNode.right == null && qNode.right != null))
                    return false;

                if (pNode.left != null) pStack.Push(pNode.left);
                if (qNode.left != null) qStack.Push(qNode.left);

                if (pNode.right != null) pStack.Push(pNode.right);
                if (qNode.right != null) qStack.Push(qNode.right);
            }

            if (pStack.Count > 0 || qStack.Count > 0) return false;

            return true;
        }

        public bool IsSameTreeBFT(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null && q != null) return false;
            if (p != null && q == null) return false;

            var pQueue = new Queue<TreeNode>();
            var qQueue = new Queue<TreeNode>();

            pQueue.Enqueue(p);
            qQueue.Enqueue(q);

            while (pQueue.Count > 0 && qQueue.Count > 0)
            {
                int pl = pQueue.Count;
                int ql = qQueue.Count;

                if (pl != ql) return false; // different count on the same level

                for (int i = 0; i < pl; i++)
                {
                    TreeNode pNode = pQueue.Dequeue();
                    TreeNode qNode = qQueue.Dequeue();

                    if (pNode.val != qNode.val) return false;

                    if ((pNode.left != null && qNode.left == null) || (pNode.left == null && qNode.left != null))
                        return false;

                    if ((pNode.right != null && qNode.right == null) || (pNode.right == null && qNode.right != null))
                        return false;

                    if (pNode.left != null) pQueue.Enqueue(pNode.left);
                    if (qNode.left != null) qQueue.Enqueue(qNode.left);

                    if (qNode.right != null) qQueue.Enqueue(qNode.right);
                    if (pNode.right != null) pQueue.Enqueue(pNode.right);
                }
            }

            if (pQueue.Count > 0 || qQueue.Count > 0) return false;

            return true;
        }

        public bool IsSameTreeBFTOneQueue(TreeNode p, TreeNode q)
        {
            //if (p == null && q == null) return true;
            //if (p == null || q == null) return false;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(p);
            queue.Enqueue(q);

            while (queue.Count > 0)
            {
                var pNode = queue.Dequeue();
                var qNode = queue.Dequeue();

                if (pNode == null && qNode == null) continue;
                if (pNode == null || qNode == null) return false;
                if (pNode.val != qNode.val) return false;

                queue.Enqueue(pNode.left);
                queue.Enqueue(qNode.left);

                queue.Enqueue(pNode.right);
                queue.Enqueue(qNode.right);
            }

            return true;
        }
    }
}