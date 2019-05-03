using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTest
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void TestPathSum()
        {
            var a = MockBinaryTree();

            var result = BinaryTree.PathSum(a, 22);
            Assert.AreEqual(5, result[0][0]);
            Assert.AreEqual(4, result[0][1]);
            Assert.AreEqual(11, result[0][2]);
            Assert.AreEqual(2, result[0][3]);

            Assert.AreEqual(5, result[1][0]);
            Assert.AreEqual(8, result[1][1]);
            Assert.AreEqual(4, result[1][2]);
            Assert.AreEqual(5, result[1][3]);
        }

        [TestMethod]
        public void TestLowestCommonAncestor()
        {
            var a = new TreeNode(3);
            var b = new TreeNode(5);
            var c = new TreeNode(1);
            var d = new TreeNode(6);
            var e = new TreeNode(2);
            var f = new TreeNode(0);
            var x = new TreeNode(8);
            var y = new TreeNode(7);
            var z = new TreeNode(4);
 

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.left = f;
            c.right = x;
            e.left = y;
            e.right = z;

            var result1 = BinaryTree.LowestCommonAncestor(a, d, z);
            Assert.AreEqual(b, result1);

            var result2 = BinaryTree.LowestCommonAncestor(a, d, x);
            Assert.AreEqual(a, result2);
        }

        [TestMethod]
        public void TestFlatten()
        {
            var a = MockBinaryTree();
            BinaryTree.Flatten(a);

            Assert.IsNull(a.left);
            Assert.AreEqual(4, a.right.value);
        }

        [TestMethod]
        public void TestBFSBinaryTree()
        {
            var a = MockBinaryTree();
            var result = BinaryTree.BFSBinaryTree(a);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(4, result[1]);
            Assert.AreEqual(8, result[2]);
            Assert.AreEqual(11, result[3]);
            Assert.AreEqual(13, result[4]);
            Assert.AreEqual(4, result[5]);
            Assert.AreEqual(7, result[6]);
            Assert.AreEqual(2, result[7]);
            Assert.AreEqual(5, result[8]);
            Assert.AreEqual(1, result[9]);
        }

        [TestMethod]
        public void TestRightSideView()
        {
            var a = MockBinaryTree();
            var result = BinaryTree.RightSideView(a);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(8, result[1]);
            Assert.AreEqual(4, result[2]);
            Assert.AreEqual(1, result[3]);
        }

        private static TreeNode MockBinaryTree()
        {
            var a = new TreeNode(5);
            var b = new TreeNode(4);
            var c = new TreeNode(8);
            var d = new TreeNode(11);
            var e = new TreeNode(13);
            var f = new TreeNode(4);
            var g = new TreeNode(7);
            var h = new TreeNode(2);
            var x = new TreeNode(5);
            var y = new TreeNode(1);

            a.left = b;
            a.right = c;
            b.left = d;
            c.left = e;
            c.right = f;
            d.left = g;
            d.right = h;
            f.left = x;
            f.right = y;

            return a;
        }
    }
}
