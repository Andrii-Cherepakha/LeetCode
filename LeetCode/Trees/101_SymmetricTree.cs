using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Trees
{
    class SymmetricTree
    {

        [Test]
        public void Test()
        {
            var root = new TreeNode(1);

            root.left = new TreeNode(2);
            root.right = new TreeNode(2);

            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);

            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(3); // time limit

            IsSymmetric(root);
        }


        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);

            while (queue.Count > 0)
            {
                var n1 = queue.Dequeue();
                var n2 = queue.Dequeue();
                if (n1 == null && n2 == null) continue;
                if (n1 == null || n2 == null) return false;
                if (n1.val != n2.val) return false;

                queue.Enqueue(n1.left);
                queue.Enqueue(n2.right);
                queue.Enqueue(n1.right);
                queue.Enqueue(n2.left);
            }

            return true;
        }

            public bool IsSymmetricMy(TreeNode root)
        {
            if (root == null) return true;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);            

            while (queue.Count > 0)
            {
                int cnt = queue.Count;
                var list = new List<TreeNode>();

                for (int i = 0; i < cnt; i++)
                {
                    var node = queue.Dequeue();
                    list.Add(node);

                    if (node != null)
                    {
                        queue.Enqueue(node.left);
                        queue.Enqueue(node.right);
                    }
                }

                int r = -1, l = list.Count;
                while (r < l)
                {
                    r++; l--;
                    if (list[r] == null && list[l] == null) continue;
                    if (list[r] == null || list[l] == null) return false;
                    if (list[r].val != list[l].val) return false;
                }
            }

            return true;
        }
    }
}
