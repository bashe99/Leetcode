using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LeetcodeTest
{
    [TestClass]
    public class BinarySearchUtilTests
    {
        [TestMethod]
        public void TestBinarySearch()
        {
            int[] a = new int[] { 1, 3, 4, 4, 4, 5, 6, 7 };
            var result = BinarySearchUtil.BinarySearch(a, 2);
            Assert.AreEqual(-1, result);

            result = BinarySearchUtil.BinarySearch(a, 4);
            Assert.AreEqual(3, result);

            result = BinarySearchUtil.BinarySearch(a, 3);
            Assert.AreEqual(1, result);

            result = BinarySearchUtil.BinarySearch(a, 7);
            Assert.AreEqual(7, result);

            result = BinarySearchUtil.BinarySearch(a, 1);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestBinarySearchRecursive()
        {
            int[] a = new int[] { 1, 3, 4, 4, 4, 5, 6, 7 };
            var result = BinarySearchUtil.BinarySearchRecursive(a, 2);
            Assert.AreEqual(-1, result);

            result = BinarySearchUtil.BinarySearchRecursive(a, 4);
            Assert.AreEqual(3, result);

            result = BinarySearchUtil.BinarySearchRecursive(a, 3);
            Assert.AreEqual(1, result);

            result = BinarySearchUtil.BinarySearchRecursive(a, 7);
            Assert.AreEqual(7, result);

            result = BinarySearchUtil.BinarySearchRecursive(a, 1);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestSearchInsert()
        {
            int[] a = new int[] { 1, 3, 5, 6 };
            var result = BinarySearchUtil.SearchInsert(a, 0);
            Assert.AreEqual(0, result);

            result = BinarySearchUtil.SearchInsert(a, 1);
            Assert.AreEqual(0, result);

            result = BinarySearchUtil.SearchInsert(a, 2);
            Assert.AreEqual(1, result);

            result = BinarySearchUtil.SearchInsert(a, 6);
            Assert.AreEqual(3, result);

            result = BinarySearchUtil.SearchInsert(a, 7);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestSearchRange()
        {
            int[] a = new int[] { 5, 7, 7, 8, 8, 8, 8, 10 };
            var result = BinarySearchUtil.SearchRange(a, 8);
            Assert.AreEqual(3, result[0]);
            Assert.AreEqual(6, result[1]);

            result = BinarySearchUtil.SearchRange(a, 6);
            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(-1, result[1]);

            result = BinarySearchUtil.SearchRange(a, 10);
            Assert.AreEqual(7, result[0]);
            Assert.AreEqual(7, result[1]);

            result = BinarySearchUtil.SearchRange(a, 11);
            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(-1, result[1]);
        }

        [TestMethod]
        public void TestSearchReverseNums()
        {
            int[] a = new int[] { 20, 1, 3, 6, 7, 8, 12, 15 };
            var result = BinarySearchUtil.SearchInReverseNums(a, 1);
            Assert.AreEqual(1, result);

            result = BinarySearchUtil.SearchInReverseNums(a, 20);
            Assert.AreEqual(0, result);

            result = BinarySearchUtil.SearchInReverseNums(a, 12);
            Assert.AreEqual(6, result);

            result = BinarySearchUtil.SearchInReverseNums(a, 15);
            Assert.AreEqual(7, result);

            result = BinarySearchUtil.SearchInReverseNums(a, 2);
            Assert.AreEqual(-1, result);

            a = new int[] { 6, 7, 8, 12, 15, 20, 1, 3 };
            result = BinarySearchUtil.SearchInReverseNums(a, 1);
            Assert.AreEqual(6, result);

            result = BinarySearchUtil.SearchInReverseNums(a, 20);
            Assert.AreEqual(5, result);

            result = BinarySearchUtil.SearchInReverseNums(a, 12);
            Assert.AreEqual(3, result);

            result = BinarySearchUtil.SearchInReverseNums(a, 6);
            Assert.AreEqual(0, result);

            result = BinarySearchUtil.SearchInReverseNums(a, 2);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestBSTInsert()
        {
            var a = new TreeNode(8);
            BSTUtil.BSTInsert(a, 3);
            BSTUtil.BSTInsert(a, 10);
            BSTUtil.BSTInsert(a, 1);
            BSTUtil.BSTInsert(a, 6);
            BSTUtil.BSTInsert(a, 15);

            Assert.AreEqual(3, a.left.value);
            Assert.AreEqual(1, a.left.left.value);
            Assert.AreEqual(6, a.left.right.value);
            Assert.AreEqual(10, a.right.value);
            Assert.AreEqual(15, a.right.right.value);
        }

        [TestMethod]
        public void TestSerialize()
        {
            var a = new TreeNode(8);
            var b = new TreeNode(3);
            var c = new TreeNode(10);
            var d = new TreeNode(1);
            var e = new TreeNode(6);
            var f = new TreeNode(15);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.right = f;

            var result = BSTUtil.Deserialize(BSTUtil.Serialize(a));
            Assert.AreEqual(8, result.value);
            Assert.AreEqual(3, result.left.value);
            Assert.AreEqual(10, result.right.value);
            Assert.AreEqual(1, result.left.left.value);
            Assert.AreEqual(6, result.left.right.value);
            Assert.AreEqual(15, result.right.right.value);
        }
    }
}
