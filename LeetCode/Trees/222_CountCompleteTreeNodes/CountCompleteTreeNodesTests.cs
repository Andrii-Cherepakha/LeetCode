using System;
using NUnit.Framework;

namespace LeetCode.Trees._222_CountCompleteTreeNodes
{
    public class CountCompleteTreeNodesTests
    {
        //private ICountCompleteTreeNodes _solution = new CountCompleteTreeNodesSolution();
        //private ICountCompleteTreeNodes _solution = new CountCompleteTreeNodesRecursive();
        private ICountCompleteTreeNodes _solution = new CountCompleteTreeNodesShift();

        [Test]
        public void TestNull()
        {
            var cnt = _solution.CountNodes(null);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(0));
        }

        [Test]
        public void TestOneNode()
        {
            var root = new TreeNode(1);
            var cnt = _solution.CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(1));
        }

        [Test]
        public void TestTwoLevels1()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);

            var cnt = _solution.CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(2));
        }

        [Test]
        public void TestTwoLevels2()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            var cnt = _solution.CountNodes(root);
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

            var cnt = _solution.CountNodes(root);
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

            var cnt = _solution.CountNodes(root);
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

            var cnt = _solution.CountNodes(root);
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

            var cnt = _solution.CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(7));
        }
    }
}