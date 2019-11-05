using LeetCode.CodeWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTest.CodeWar
{
    [TestClass]
    public class SumOfIntervalTests
    {
        [TestMethod]
        public void ShouldAddOverlappingIntervals()
        {
            var input = new (int, int)[] { (1, 4), (7, 10), (3, 5) };
            Assert.AreEqual(7, SumOfInterval.SumIntervals(input));
        }
    }
}
