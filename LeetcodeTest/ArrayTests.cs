using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTest
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void TestFindPeakNumber()
        {
            int[] test = new int[] { 2, 1, 3, 4, 5, 6, 11, 14, 8, 25 };
            int index = ArrayUtil.FindPeakNumber(test);
            Assert.IsFalse(index == -1);
            Assert.IsTrue((index - 1 < 0 || test[index] < test[index - 1]) && (index + 1 >= test.Length || test[index] < test[index + 1]));

            test = new int[] { 1 };
            index = ArrayUtil.FindPeakNumber(test);
            Assert.IsFalse(index == -1);
            Assert.IsTrue((index - 1 < 0 || test[index] < test[index - 1]) && (index + 1 >= test.Length || test[index] < test[index + 1]));

            test = new int[] { 2, 1 };
            index = ArrayUtil.FindPeakNumber(test);
            Assert.IsFalse(index == -1);
            Assert.IsTrue((index - 1 < 0 || test[index] < test[index - 1]) && (index + 1 >= test.Length || test[index] < test[index + 1]));

            test = new int[] { 1, 2, 6, 5, 9, 7, 4 };
            index = ArrayUtil.FindPeakNumber(test);
            Assert.IsFalse(index == -1);
            Assert.IsTrue((index - 1 < 0 || test[index] < test[index - 1]) && (index + 1 >= test.Length || test[index] < test[index + 1]));
        }

        [TestMethod]
        public void TestMaxSpace()
        {
            int[] test = new int[]{ 1 };
            var result = ArrayUtil.MaxSpace(test);
            Assert.AreEqual(0, result);

            test = new int[] { 1 ,1 ,1 };
            result = ArrayUtil.MaxSpace(test);
            Assert.AreEqual(0, result);

            test = new int[] { 2, 6, 5, 7, 9 };
            result = ArrayUtil.MaxSpace(test);
            Assert.AreEqual(3, result);

            test = new int[] { 2, 3, 4, 5, 6 };
            result = ArrayUtil.MaxSpace(test);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestSeperateArray()
        {
            int[] test = new int[] { 1 };
            var result = ArrayUtil.SeperateArray(test);
            Assert.AreEqual(0, result);

            test = new int[] { };
            result = ArrayUtil.SeperateArray(test);
            Assert.AreEqual(-1, result);

            test = new int[] { 1, 2, 5, 8, 0 };
            result = ArrayUtil.SeperateArray(test);
            Assert.AreEqual(3, result);

            test = new int[] { 1, 2, -5, 8, -2, 4 };
            result = ArrayUtil.SeperateArray(test);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestSeperateArray2()
        {
            int[] test = new int[] { 1 };
            var result = ArrayUtil.SeperateArray2(test);
            Assert.AreEqual(0, result);

            test = new int[] { };
            result = ArrayUtil.SeperateArray2(test);
            Assert.AreEqual(-1, result);

            test = new int[] { 1, 2, 5, 8, 0 };
            result = ArrayUtil.SeperateArray2(test);
            Assert.AreEqual(3, result);

            test = new int[] { 3, 5, 8, 1 };
            result = ArrayUtil.SeperateArray2(test);
            Assert.AreEqual(2, result);

            test = new int[] { 0, 8, 0, 8 };
            result = ArrayUtil.SeperateArray2(test);
            Assert.AreEqual(2, result);

            test = new int[] { 0, 0, 0, 0 };
            result = ArrayUtil.SeperateArray2(test);
            Assert.AreEqual(0, result);
        }
    }
}
