using System;
using NUnit.Framework;

namespace LeetCode.Trees
{
    public class CountCompleteTreeNodesSolution
    {
        [Test]
        public void TestNull()
        {
            var cnt = CountNodes(null);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(0));
        }

        [Test]
        public void TestOneNode()
        {
            var root = new TreeNode(1);
            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(1));
        }

        [Test]
        public void TestTwoLevels1()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);

            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(2));
        }

        [Test]
        public void TestTwoLevels2()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(3));
        }

        [Test]
        public void TestThreeLevels4()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(4);

            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(4));
        }

        [Test]
        public void TestThreeLevels5()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);

            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(5));
        }

        [Test]
        public void TestThreeLevels6()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);

            root.right.left = new TreeNode(6);

            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(6));
        }

        [Test]
        public void TestThreeLevels7()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);

            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(7));
        }

        public int CountNodes(TreeNode root)
        {
            _leavesNum = 0;
            _maxLevel = 0;
            PreOrder(root, 0);
            return (int)Math.Pow(2, _maxLevel) - 1 + _leavesNum;
        }

        private int _leavesNum;
        private int _maxLevel;

        private bool PreOrder(TreeNode node, int level)
        {
            if (node == null)
            {
                return true;
            }

            if (node.left == null && node.right == null && _maxLevel == 0)
            {
                _maxLevel = level;
            }
            
            if (node.left == null && node.right == null && _maxLevel == level)
            {
                _leavesNum++;
                return false;
            }

            return PreOrder(node.left, level + 1) || PreOrder(node.right, level + 1);
        }
    }
}