using LeetCode.CodeWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTest.CodeWar
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void EvaluatorTests()
        {
            Assert.AreEqual(9, Calculator.Evaluate("(1+2)*3"));
        }
    }
}
