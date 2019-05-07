using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class HashTable
    {
        /// <summary>
        /// 已知一个只包括大小写字符的字符串，求用该字符串中的字符可以生成的最长回文字符串的长度。
        /// </summary>
        public static int LongestPalindrome(string str)
        {
            var charDict = new Dictionary<char, int>();
            foreach (var charItem in str)
            {
                if (charDict.ContainsKey(charItem))
                {
                    charDict[charItem]++;
                }
                else
                {
                    charDict.Add(charItem, 1);
                }
            }

            bool MidSingleCharAdded = false;
            int result = 0;
            foreach (var record in charDict)
            {
                if (record.Value % 2 == 0)
                {
                    result += record.Value;
                }
                else
                {
                    if (!MidSingleCharAdded)
                    {
                        result += record.Value;
                        MidSingleCharAdded = true;
                    }
                    else
                    {
                        result += record.Value - 1;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 已知字符串pattern与字符串str，确认str是否与pattern匹配。str与pattern匹配代表字符串str中的单词与pattern中的字符一一对应。
        /// str里面的单词使用空格分隔
        /// </summary>
        public static bool MatchWordPattern(string pattern, string str)
        {
            if (string.IsNullOrWhiteSpace(pattern) || string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            var patternToStr = new Dictionary<char, string>();
            var strToPattern = new Dictionary<string, char>();

            var words = str.Split(' ');
            if (words.Length != pattern.Length)
            {
                return false;
            }

            for (int index = 0; index < words.Length; index++)
            {
                var word = words[index];
                var charItem = pattern[index];

                if (!patternToStr.ContainsKey(charItem))
                {
                    patternToStr.Add(charItem, word);
                }
                else if (patternToStr[charItem] != word)
                {
                    return false;
                }

                if (!strToPattern.ContainsKey(word))
                {
                    strToPattern.Add(word, charItem);
                }
                else if (strToPattern[word] != charItem)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 已知一组字符串，将所有相同字符组成的字符串放到一起
        /// </summary>
        public static List<List<string>> GroupAnagrams(List<string> strs)
        {
            var stringContainer = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var strArray = str.ToCharArray();
                QuickSortString(strArray, 0, str.Length - 1);
                var keyword = ConvertCharArray(strArray);
                if (stringContainer.ContainsKey(keyword))
                {
                    stringContainer[keyword].Add(str);
                }
                else
                {
                    stringContainer.Add(keyword, new List<string> { str });
                }
            }

            var result = new List<List<string>>();
            foreach (var item in stringContainer)
            {
                result.Add(item.Value);
            }

            return result;
        }

        private static string ConvertCharArray(char[] items)
        {
            var result = string.Empty;
            foreach (var item in items)
            {
                result += item;
            }

            return result;
        }

        private static void QuickSortString(char[] str, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int mid = PartitionChar(str, start, end);
            QuickSortString(str, start, mid - 1);
            QuickSortString(str, mid + 1, end);
        }

        private static int PartitionChar(char[] str, int start, int end)
        {
            char pivot = str[start];
            int index = start;
            for (int i = start; i <= end; i++)
            {
                if (str[i] < pivot)
                {
                    index++;
                    var temp = str[index];
                    str[index] = str[i];
                    str[i] = temp;
                }
            }

            var temp2 = str[index];
            str[index] = str[start];
            str[start] = temp2;

            return index;
        }

        /// <summary>
        /// 已知一个字符串，求该字符串的无重复字符的最长子串的长度
        /// </summary>
        /// <param name="str"></param>
        public static int FindLongestSubStringNoDup(string str)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            var charDict = new HashSet<char>();
            int maxLength = 0;

            while (leftIndex <= rightIndex && rightIndex < str.Length)
            {
                if (!charDict.Contains(str[rightIndex]))
                {
                    charDict.Add(str[rightIndex]);
                    if (rightIndex - leftIndex + 1 > maxLength)
                    {
                        maxLength = rightIndex - leftIndex + 1;
                    }
                }
                else
                {
                    while (leftIndex < str.Length && charDict.Contains(str[rightIndex]))
                    {
                        charDict.Remove(str[leftIndex]);
                        leftIndex++;
                    }

                    charDict.Add(str[rightIndex]);
                }

                rightIndex++;
            }

            return maxLength;
        }

        /// <summary>
        /// 已知字符串str，求在str中的最小子串，使得这个子串包含了str中的所有字符
        /// </summary>
        public static int FindMinWindow(string str)
        {
            //1,找到所有字符的集合
            //2,使用charDict记录扫描过的char出现的次数
            //3,子字符串如果满足条件，判断是否更新minlength
            var charSet = new HashSet<char>();
            foreach (var s in str)
            {
                if (!charSet.Contains(s))
                {
                    charSet.Add(s);
                }
            }

            var charDict = new Dictionary<char, int>();
            int leftIndex = 0;
            int rightIndex = 0;
            int minLength = str.Length;

            while (rightIndex < str.Length && leftIndex <= rightIndex)
            {
                if (!charDict.ContainsKey(str[rightIndex]))
                {
                    charDict.Add(str[rightIndex], 1);
                }
                else
                {
                    charDict[str[rightIndex]]++;
                }

                if (ContainsAllChar(charSet, str, leftIndex, rightIndex))
                {
                    while (charDict.ContainsKey(str[leftIndex]) && charDict[str[leftIndex]] > 1 && leftIndex < rightIndex)
                    {
                        charDict[str[leftIndex]]--;
                        leftIndex++;
                    }

                    if (rightIndex - leftIndex + 1 < minLength)
                    {
                        minLength = rightIndex - leftIndex + 1;
                    }
                }

                rightIndex++;
            }

            return minLength;
        }

        private static bool ContainsAllChar(HashSet<char> charSet, string s, int leftIndex, int rightIndex)
        {
            if (leftIndex < 0 || leftIndex > rightIndex || rightIndex >= s.Length)
            {
                return false;
            }

            var subStr = s.Substring(leftIndex, rightIndex - leftIndex + 1);
            var result = true;
            foreach (var c in charSet)
            {
                if (subStr.IndexOf(c) <= -1)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
