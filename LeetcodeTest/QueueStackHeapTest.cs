using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTest
{
    [TestClass]
    public class QueueStackHeapTest
    {
        [TestMethod]
        public void TestMyStack()
        {
            var testObj = new MyStack();
            testObj.Push(0);
            testObj.Push(1);
            testObj.Push(2);

            Assert.IsFalse(testObj.Empty());
            Assert.AreEqual(2, testObj.Pop());

            testObj.Push(3);
            Assert.AreEqual(3, testObj.Pop());
            Assert.AreEqual(1, testObj.Pop());
            Assert.AreEqual(0, testObj.Pop());
        }

        [TestMethod]
        public void TestMyQueue()
        {
            var testObj = new MyQueue();
            testObj.Push(0);
            testObj.Push(1);
            testObj.Push(2);

            Assert.IsFalse(testObj.Empty());
            Assert.AreEqual(0, testObj.Pop());

            testObj.Push(3);
            Assert.AreEqual(1, testObj.Pop());
            Assert.AreEqual(2, testObj.Pop());
            Assert.AreEqual(3, testObj.Pop());
        }

        [TestMethod]
        public void TestMinStack()
        {
            var testObj = new MinStack();
            testObj.Push(3);
            Assert.AreEqual(3, testObj.GetMin());

            testObj.Push(4);
            Assert.AreEqual(3, testObj.GetMin());

            testObj.Push(1);
            Assert.AreEqual(1, testObj.GetMin());

            testObj.Pop();
            Assert.AreEqual(3, testObj.GetMin());
        }

        [TestMethod]
        public void TestIsStackSequence()
        {
            var testNumList = new List<int> { 3, 2, 5, 4, 1 };
            Assert.IsTrue(StackQueueHeapUtils.IsStackSequence(testNumList));

            testNumList = new List<int> { 3, 1, 2, 4, 5 };
            Assert.IsFalse(StackQueueHeapUtils.IsStackSequence(testNumList));
        }

        [TestMethod]
        public void TestFindKthNum()
        {
            var a = new List<int> { 3, 2, 1, 5, 5, 5, 6, 5, 6, 4 };
            Assert.AreEqual(6, StackQueueHeapUtils.FindKthNum(a, 1));
            Assert.AreEqual(6, StackQueueHeapUtils.FindKthNum(a, 2));
            Assert.AreEqual(5, StackQueueHeapUtils.FindKthNum(a, 3));
            Assert.AreEqual(5, StackQueueHeapUtils.FindKthNum(a, 4));
            Assert.AreEqual(5, StackQueueHeapUtils.FindKthNum(a, 5));
            Assert.AreEqual(5, StackQueueHeapUtils.FindKthNum(a, 6));
            Assert.AreEqual(2, StackQueueHeapUtils.FindKthNum(a, 9));
            Assert.AreEqual(1, StackQueueHeapUtils.FindKthNum(a, 10));
        }

        [TestMethod]
        public void TestFindMidNum()
        {
            var a = new List<int> { 3, 2, 1, 5, 4 };
            Assert.AreEqual(3, StackQueueHeapUtils.FindMidNum(a));

            a = new List<int> { 3, 2, 1, 5 };
            Assert.AreEqual(2.5, StackQueueHeapUtils.FindMidNum(a));
        }
    }
}
