namespace LeetcodeTest
{
    using LeetCode;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListNodeTest
    {
        [TestMethod]
        public void TestReverseListNode()
        {
            // 3 => 2 => 1
            var a = new ListNode(1, null);
            var b = new ListNode(2, a);
            var c = new ListNode(3, b);

            var result = ListNodeMethod.PrintListNode(ListNodeMethod.ReverseListNode(c));
            Assert.AreEqual("123", result);
        }

        [TestMethod]
        public void TestReverseListNodeWithIndex()
        {
            // 5 => 4 => 3 => 2 => 1
            var a = new ListNode(1, null);
            var b = new ListNode(2, a);
            var c = new ListNode(3, b);
            var d = new ListNode(4, c);
            var e = new ListNode(5, d);

            var result = ListNodeMethod.PrintListNode(ListNodeMethod.ReverseListNodeWithIndex(e, 2, 4));
            Assert.AreEqual("52341", result);
        }

        [TestMethod]
        public void TestReverseListNodeWithIndex_StartWithOne()
        {
            // 5 => 4 => 3 => 2 => 1
            var a = new ListNode(1, null);
            var b = new ListNode(2, a);
            var c = new ListNode(3, b);
            var d = new ListNode(4, c);
            var e = new ListNode(5, d);

            var result = ListNodeMethod.PrintListNode(ListNodeMethod.ReverseListNodeWithIndex(e, 1, 3));
            Assert.AreEqual("34521", result);
        }

        [TestMethod]
        public void TestReverseListNodeWithIndex_SameStartAndEnd()
        {
            // 5 => 4 => 3 => 2 => 1
            var a = new ListNode(1, null);
            var b = new ListNode(2, a);
            var c = new ListNode(3, b);
            var d = new ListNode(4, c);
            var e = new ListNode(5, d);

            var result = ListNodeMethod.PrintListNode(ListNodeMethod.ReverseListNodeWithIndex(e, 3, 3));
            Assert.AreEqual("54321", result);
        }

        [TestMethod]
        public void TestReverseListNodeWithIndex_OutOfBoundary()
        {
            // 5 => 4 => 3 => 2 => 1
            var a = new ListNode(1, null);
            var b = new ListNode(2, a);
            var c = new ListNode(3, b);
            var d = new ListNode(4, c);
            var e = new ListNode(5, d);

            var result = ListNodeMethod.PrintListNode(ListNodeMethod.ReverseListNodeWithIndex(e, 3, 8));
            Assert.AreEqual("54123", result);
        }

        [TestMethod]
        public void TestGetIntersetionNode()
        {
            // 5 => 4 => 3 => 2 => 1
            // 0 => 1 =>             
            var a = new ListNode(1, null);
            var b = new ListNode(2, a);
            var c = new ListNode(3, b);
            var d = new ListNode(4, c);
            var e = new ListNode(5, d);

            var d2 = new ListNode(1, c);
            var e2 = new ListNode(0, d2);

            var result = ListNodeMethod.GetIntersetionNode(e, e2);
            Assert.AreEqual(3, result.val);
        }

        [TestMethod]
        public void TestDetectCycle()
        {
            // e => d => c => b => a => c           
            var a = new ListNode(1, null);
            var b = new ListNode(2, a);
            var c = new ListNode(3, b);
            var d = new ListNode(4, c);
            var e = new ListNode(5, d);
            a.next = c;

            var result = ListNodeMethod.DetectCycle(e);
            Assert.AreEqual(3, result.val);
        }

        [TestMethod]
        public void TestPartitionListNode()
        {
            // 5 => 4 => 3 => 2 => 1           
            var a = new ListNode(1, null);
            var b = new ListNode(2, a);
            var c = new ListNode(3, b);
            var d = new ListNode(4, c);
            var e = new ListNode(5, d);

            var result = ListNodeMethod.PrintListNode(ListNodeMethod.PartitionListNode(e, 3));
            Assert.AreEqual("21543", result);
        }

        [TestMethod]
        public void TestPartitionListNode_AllSmaller()
        {
            // 5 => 4 => 3 => 2 => 1           
            var a = new ListNode(1, null);
            var b = new ListNode(2, a);
            var c = new ListNode(3, b);
            var d = new ListNode(4, c);
            var e = new ListNode(5, d);

            var result = ListNodeMethod.PrintListNode(ListNodeMethod.PartitionListNode(e, 8));
            Assert.AreEqual("54321", result);
        }

        [TestMethod]
        public void TestPartitionListNode_AllBigger()
        {
            // 5 => 4 => 3 => 2 => 6           
            var a = new ListNode(6, null);
            var b = new ListNode(2, a);
            var c = new ListNode(3, b);
            var d = new ListNode(4, c);
            var e = new ListNode(5, d);

            var result = ListNodeMethod.PrintListNode(ListNodeMethod.PartitionListNode(e, 1));
            Assert.AreEqual("54326", result);
        }

        [TestMethod]
        public void TestDeepCloneRandomListNode()
        {
            var a = new RandomListNode(1, null, null);
            var b = new RandomListNode(2, a, null);
            var c = new RandomListNode(3, b, a);
            var d = new RandomListNode(4, c, null);
            d.random = d;
            var e = new RandomListNode(5, d, b);
            a.random = d;

            var expectedResult = ListNodeMethod.PrintListNode(e);
            var result = ListNodeMethod.PrintListNode(ListNodeMethod.DeepCloneRandomListNode(e));
            Assert.AreEqual(expectedResult, result);

            c.val = 9;
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestMergeListNodes()
        {
            // 1 => 2 => 3 => 4 => 5           
            var a = new ListNode(5, null);
            var b = new ListNode(4, a);
            var c = new ListNode(3, b);
            var d = new ListNode(2, c);
            var e = new ListNode(1, d);

            // 3 => 3 => 3 => 4 => 5           
            var a2 = new ListNode(5, null);
            var b2 = new ListNode(4, a2);
            var c2 = new ListNode(3, b2);
            var d2 = new ListNode(3, c2);
            var e2 = new ListNode(3, d2);

            // 8 => 9          
            var d3 = new ListNode(9, null);
            var e3 = new ListNode(8, d3);

            // 1 => 1          
            var d4 = new ListNode(1, null);
            var e4 = new ListNode(1, d4);

            var expectedResult = "11123333445589";
            var result = ListNodeMethod.PrintListNode(ListNodeMethod.MergeListNodes(new System.Collections.Generic.List<ListNode> { e, e2, e3, e4}));
            Assert.AreEqual(expectedResult, result);
        }
    }
}
