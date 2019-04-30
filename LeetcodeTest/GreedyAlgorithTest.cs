using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTest
{
    [TestClass]
    public class GreedyAlgorithTest
    {
        [TestMethod]
        public void TestQuickSort()
        {
            var a = new List<int> { 3, 2, 5, 6, 1, 4, 3, 2 };
            GreedyAlgorith.QuickSort(a);
            Assert.AreEqual("1;2;2;3;3;4;5;6;", PrintList(a));
        }

        [TestMethod]
        public void TestFindContentChildren()
        {
            var sList = new List<int> { 6, 1, 20, 3, 8 };
            var gList = new List<int> { 5, 10, 2, 9, 15, 9 };
            Assert.AreEqual(3, GreedyAlgorith.FindContentChildren(gList, sList));
        }

        [TestMethod]
        public void TestWiggleMaxLength()
        {
            var a = new List<int> { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 };
            Assert.AreEqual(7, GreedyAlgorith.WiggleMaxLength(a));

            a = new List<int> { 1, 1, 1, 1, 1, 1 };
            Assert.AreEqual(1, GreedyAlgorith.WiggleMaxLength(a));

            a = new List<int> { 1 };
            Assert.AreEqual(1, GreedyAlgorith.WiggleMaxLength(a));

            a = new List<int> { 1, 3, 5, 4, 4, 4, 3, 4, 3, 4, 3, 4 };
            Assert.AreEqual(8, GreedyAlgorith.WiggleMaxLength(a));
        }

        [TestMethod]
        public void TestRemoveKDigits()
        {
            var a = "14399919";
            Assert.AreEqual("1219", GreedyAlgorith.RemoveKDigits(a, 2));

            a = "100200";
            Assert.AreEqual("200", GreedyAlgorith.RemoveKDigits(a, 1));

            a = "12300005";
            Assert.AreEqual("0", GreedyAlgorith.RemoveKDigits(a, 5));

            a = "12300005";
            Assert.AreEqual("5", GreedyAlgorith.RemoveKDigits(a, 3));
        }

        [TestMethod]
        public void TestCanJump()
        {
            var nums = new List<int> { 2, 3, 1, 1, 4 };
            Assert.IsTrue(GreedyAlgorith.CanJump(nums));

            nums = new List<int> { 3, 2, 1, 0, 4 };
            Assert.IsFalse(GreedyAlgorith.CanJump(nums));
        }

        private static string PrintList(List<int> a)
        {
            var result = string.Empty;
            foreach (var item in a)
            {
                result += item.ToString() + ";";
            }

            return result;
        }
    }
}
