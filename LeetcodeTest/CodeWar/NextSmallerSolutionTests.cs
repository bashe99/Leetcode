using LeetCode.CodeWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTest.CodeWar
{
    [TestClass]
    public class NextSmallerSolutionTests
    {
        [TestMethod]
        public void NextSmallerTest()
        {
            long num = 907;
            var result = NextSmallerSolution.BetterNextSmaller(num);
            Assert.AreEqual(790, result);
        }
    }
}
