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
            var input = new (int, int)[] { (1, 2), (2, 6), (6, 55) };
            Assert.AreEqual(54, SumOfInterval.SumIntervals(input));
        }
    }
}
