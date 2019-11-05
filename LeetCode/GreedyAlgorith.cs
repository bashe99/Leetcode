using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class GreedyAlgorith
    {
        // 已知一些孩子和一些糖果，每个孩子有需求因子g，每个糖果有大小S，当某个糖果的大小S>=某个孩子的需求因子g时，代表该糖果可以满足该孩子；
        // 求使用这些糖果，最多能满足多少孩子？
        public static int FindContentChildren(List<int> gList, List<int> sList)
        {
            QuickSort(gList);
            QuickSort(sList);

            int result = 0, sIndex = 0, gIndex = 0;
            while (sIndex < sList.Count && gIndex < gList.Count)
            {
                if (gList[gIndex] < sList[sIndex])
                {
                    result++;
                    gIndex++;
                }

                sIndex++;
            }

            return result;
        }

        // 一个整数序列，如果两个相邻元素的差恰好正负交替出现，则该序列被称为摇摆序列。给一个随机序列，求这个序列满足摇摆序列定义的最长子序列的长度。
        public static int WiggleMaxLength(List<int> nums)
        {
            if (nums.Count < 2)
            {
                return nums.Count;
            }

            var result = nums[1] == nums[0] ? 1 : 2;
            int isIncrease = nums[1].CompareTo(nums[0]);
            for (int i = 1; i < nums.Count; i++)
            {
                int nowIsIncrease = nums[i].CompareTo(nums[i - 1]);
                if (nowIsIncrease == 0)
                {
                    continue;
                }
                else if (nowIsIncrease != isIncrease)
                {
                    result++;
                    isIncrease = nowIsIncrease;
                }
            }

            return result;
        }

        // 已知一个用字符串表示的非负整数num，将num中的k个数字移除，求移除k个数字后，可以获得的最小的可能的新数字
        public static string RemoveKDigits(string numStr, int k)
        {
            if (string.IsNullOrWhiteSpace(numStr))
            {
                return null;
            }

            var count = 0;
            var tempStack = new Stack<int>();
            for (int i = 0; i < numStr.Length; i++)
            {
                if (!int.TryParse(numStr[i].ToString(), out var num))
                {
                    return null;
                }

                while (tempStack.Count > 0 && tempStack.Peek() > num && count < k)
                {
                    tempStack.Pop();
                    count++;
                }

                if (tempStack.Count != 0 || num != 0)
                {
                    tempStack.Push(num);
                }
            }

            string result = null;
            while (count < k && tempStack.Count > 0)
            {
                tempStack.Pop();
                count++;
            }

            int stackCount = tempStack.Count;
            for (int i=0; i< stackCount; i++)
            {
                result = tempStack.Pop().ToString() + result;
            }

            return result == null ? "0" : result;
        }

        // 一个数组存储了非负整数数据，数组中的第i个元素a[i]，代表了可以从数组的第i个位置最多向前跳跃a[i]步；已知数组各元素的情况下，
        // 求是否可以从数组的第0个位置跳跃到数组的最后一个元素的位置
        public static bool CanJump(List<int> nums)
        {
            var tempNums = new List<int>(nums.Count);
            for (int i = 0; i < nums.Count; i++)
            {
                tempNums.Add(i + nums[i]);
            }

            int maxPosition = 0;
            int jump = 0;
            int searchPosition = nums[0];
            while (maxPosition < nums.Count - 1 && jump <= maxPosition)
            {
                if (tempNums[jump] > maxPosition)
                {
                    maxPosition = tempNums[jump];
                }

                jump++;
            }

            return maxPosition >= nums.Count - 1;
        }

        // 快速排序
        public static void QuickSort(List<int> nums)
        {
            QuickSort(nums, 0, nums.Count - 1);
        }

        private static void QuickSort(List<int> nums, int start, int end)
        {
            if (start > end)
            {
                return;
            }

            int position = Partition(nums, start, end);
            QuickSort(nums, start, position - 1);
            QuickSort(nums, position + 1, end);
        }

        private static int Partition(List<int> nums, int start, int end)
        {
            var pivot = nums[start];
            int position = start;
            for (int i = start; i <= end; i++)
            {
                if (nums[i] < pivot)
                {
                    position++;
                    Swap(nums, position, i);
                }
            }

            Swap(nums, position, start);
            return position;
        }

        private static void Swap(List<int> nums, int left, int right)
        {
            var temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
        }

        /// <summary>
        /// 找出不包含重复字符的最长子串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int LongestSubstringWithoutRepeatingCharacters(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            var tempMap = new HashSet<char>();
            var head = 0;
            var tail = 0;
            var result = 0;
            while(tail < str.Length)
            {
                if (!tempMap.Contains(str[tail]))
                {
                    tempMap.Add(str[tail]);
                    tail++;
                    result = Math.Max(result, tempMap.Count);
                }
                else
                {
                    tempMap.Remove(str[head]);
                    head++;
                }
            }

            return result;
        }
    }
}
