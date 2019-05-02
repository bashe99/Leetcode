using System;
using System.Collections.Generic;
using System.Text;
using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetcodeTest
{
    [TestClass]
    public class RecursiveBacktrackingTests
    {
        [TestMethod]
        public void TestFindSubsets()
        {
            var nums = new List<int> { 1, 2, 3 };
            var results = RecursiveBacktracking.FindSubsets(nums);
            Assert.AreEqual(8, results.Count);
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int>()));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 2 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 3 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1, 2 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1, 3 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 2, 3 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1, 2, 3 }));
        }

        [TestMethod]
        public void TestFindSubsets2()
        {
            var nums = new List<int> { 1, 2, 3 };
            var results = RecursiveBacktracking.FindSubsets2(nums);
            Assert.AreEqual(8, results.Count);
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int>()));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 2 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 3 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1, 2 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1, 3 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 2, 3 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1, 2, 3 }));
        }

        [TestMethod]
        public void TestFindSubsetsInDupList()
        {
            var nums = new List<int> { 2, 1, 2, 2 };
            var results = RecursiveBacktracking.FindSubsetsInDupList(nums);
            Assert.AreEqual(8, results.Count);
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int>()));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1, 2 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1, 2, 2 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1, 2, 2, 2 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 2 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 2, 2 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 2, 2, 2 }));
        }

        [TestMethod]
        public void TestFindSubsetsWithTargetSum()
        {
            var nums = new List<int> { 10, 1, 2, 7, 6, 1, 5 };
            var results = RecursiveBacktracking.FindSubsetsWithTargetSum(nums, 8);
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1, 7 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1, 2, 5 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 6, 2 }));
            Assert.IsTrue(RecursiveBacktracking.ContainsSubset(results, new List<int> { 1, 1, 6 }));
        }

        [TestMethod]
        public void TestGenerateParenthesis()
        {
            var results = RecursiveBacktracking.GenerateParenthesis(3);
            Assert.AreEqual(5, results.Count);
            Assert.IsTrue(results.Contains("((()))"));
            Assert.IsTrue(results.Contains("(()())"));
            Assert.IsTrue(results.Contains("(())()"));
            Assert.IsTrue(results.Contains("()(())"));
            Assert.IsTrue(results.Contains("()()()"));
        }

        //[TestMethod]
        //public void TestCountSmaller()
        //{
        //    var nums = new List<int> { 5, 2, 6, 1 };
        //    var expectedResult = new int[] { 2, 1, 1, 0 };
        //    this.TestCountSmallerCore(nums, expectedResult);

        //    nums = new List<int> { 5, -7, 9, 1, 3, 5, -2, 1 };
        //    expectedResult = new int[] { 5, 0, 5, 1, 2, 2, 0, 0 };
        //    this.TestCountSmallerCore(nums, expectedResult);
        //}

        //private void TestCountSmallerCore(List<int> nums, int[] expectedResult)
        //{
        //    var result = RecursiveBacktracking.CountSmaller(nums);
        //    for (int i = 0; i < expectedResult.Length; i++)
        //    {
        //        Assert.AreEqual(expectedResult[i], result[i]);
        //    }
        //}

        //[TestMethod]
        //public void TestSolveNQueens()
        //{
        //    var results = RecursiveBacktracking.SolveNQueens(4);
        //    Assert.AreEqual(2, results.Count);

        //    Assert.AreEqual(".Q..", results[0][0]);
        //    Assert.AreEqual("...Q", results[0][1]);
        //    Assert.AreEqual("Q...", results[0][2]);
        //    Assert.AreEqual("..Q.", results[0][3]);

        //    Assert.AreEqual("..Q.", results[1][0]);
        //    Assert.AreEqual("Q...", results[1][1]);
        //    Assert.AreEqual("...Q", results[1][2]);
        //    Assert.AreEqual(".Q..", results[1][3]);
        //}
    }
}
