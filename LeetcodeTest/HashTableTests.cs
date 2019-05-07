using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTest
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void TestLongestPalindrome()
        {
            var test = "abccccddaa";
            var result = HashTable.LongestPalindrome(test);
            Assert.AreEqual(9, result);

            test = "ab";
            result = HashTable.LongestPalindrome(test);
            Assert.AreEqual(1, result);

            test = "aa";
            result = HashTable.LongestPalindrome(test);
            Assert.AreEqual(2, result);

            test = "aaa";
            result = HashTable.LongestPalindrome(test);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestMatchWordPattern()
        {
            var pattern = "abba";
            var words = "dog cat cat dog";
            Assert.IsTrue(HashTable.MatchWordPattern(pattern, words));

            pattern = "abba";
            words = "dog cat cat fish";
            Assert.IsFalse(HashTable.MatchWordPattern(pattern, words));

            pattern = "aaaa";
            words = "dog cat cat dog";
            Assert.IsFalse(HashTable.MatchWordPattern(pattern, words));

            pattern = "aaba";
            words = "dog dog dog dog";
            Assert.IsFalse(HashTable.MatchWordPattern(pattern, words));

            pattern = "a";
            words = "dog";
            Assert.IsTrue(HashTable.MatchWordPattern(pattern, words));
        }

        [TestMethod]
        public void TestGroupAnagrams()
        {
            var a = new List<string> { "eat", "tea", "tan", "ate", "nat", "bat" };
            var result = HashTable.GroupAnagrams(a);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void TestFindLongestSubStringNoDup()
        {
            var a = "abcabcbb";
            var result = HashTable.FindLongestSubStringNoDup(a);
            Assert.AreEqual(3, result);

            a = "bbbbb";
            result = HashTable.FindLongestSubStringNoDup(a);
            Assert.AreEqual(1, result);

            a = "pwwkew";
            result = HashTable.FindLongestSubStringNoDup(a);
            Assert.AreEqual(3, result);

            a = "abcbadab";
            result = HashTable.FindLongestSubStringNoDup(a);
            Assert.AreEqual(4, result);

            a = "abcdefg";
            result = HashTable.FindLongestSubStringNoDup(a);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void TestFindMinWindow()
        {
            var a = "adobecodebanc";
            var result = HashTable.FindMinWindow(a);
            Assert.AreEqual(7, result);

            a = "abce";
            result = HashTable.FindMinWindow(a);
            Assert.AreEqual(4, result);

            a = "aaaa";
            result = HashTable.FindMinWindow(a);
            Assert.AreEqual(1, result);

            a = "abcabcbb";
            result = HashTable.FindMinWindow(a);
            Assert.AreEqual(3, result);
        }
    }
}
