using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTest
{
    [TestClass]
    public class DynamicPlanningTests
    {
        [TestMethod]
        public void TestClimbStairs()
        {
            var result = DynamicPlanning.ClimbStairs(3);
            Assert.AreEqual(3, result);

            result = DynamicPlanning.ClimbStairs(4);
            Assert.AreEqual(5, result);

            result = DynamicPlanning.ClimbStairs(2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestRob()
        {
            var test = new int[] { 5, 2, 6, 3, 1, 7 };
            var result = DynamicPlanning.Rob(test);
            Assert.AreEqual(18, result);

            test = new int[] { 5 };
            result = DynamicPlanning.Rob(test);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestMaxSubArray()
        {
            var test = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var result = DynamicPlanning.MaxSubArray(test);
            Assert.AreEqual(6, result);

            result = DynamicPlanning.MaxSubArray2(test);
            Assert.AreEqual(6, result);

            test = new int[] { -2 };
            result = DynamicPlanning.MaxSubArray(test);
            Assert.AreEqual(-2, result);

            result = DynamicPlanning.MaxSubArray2(test);
            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void TestCoinChange()
        {
            var coins = new int[] { 1, 2, 3, 7, 10 };
            var result = DynamicPlanning.CoinChange(coins, 14);
            Assert.AreEqual(2, result);

            coins = new int[] { 1, 2, 5 };
            result = DynamicPlanning.CoinChange(coins, 11);
            Assert.AreEqual(3, result);

            coins = new int[] { 2 };
            result = DynamicPlanning.CoinChange(coins, 3);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMinimumTotal()
        {
            var test = new List<List<int>>()
            {
                new List<int>{ 2},
                new List<int>{ 3,4},
                new List<int>{ 6,5,7},
                new List<int>{ 4,1,8,3}
            };

            var result = DynamicPlanning.MinimumTotal(test);
            Assert.AreEqual(11, result);

            result = DynamicPlanning.MinimumTotal2(test);
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void TestLengthOfLIS()
        {
            var test = new int[] { 1, 3, 2, 3, 1, 4, 1 };
            var result = DynamicPlanning.LengthOfLIS(test);
            Assert.AreEqual(4, result);

            test = new int[] { 1, 1, 1 };
            result = DynamicPlanning.LengthOfLIS(test);
            Assert.AreEqual(1, result);

            test = new int[] { 1 };
            result = DynamicPlanning.LengthOfLIS(test);
            Assert.AreEqual(1, result);
        }
    }
}
