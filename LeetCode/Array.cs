using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class ArrayUtil
    {
        /// <summary>
        /// 寻找数组的局部最小元素。给定一个数组，数组中的数字各不相同，返回一个局部最小值的位置，a[i]小于a[i-1] 并且 a[i]小于a[i+1]
        /// </summary>
        public static int FindPeakNumber(int[] nums)
        {
            var start = 0;
            var end = nums.Length - 1;
            while (start <= end)
            {
                var mid = (start + end) / 2;
                if ((mid - 1 < 0 || nums[mid] < nums[mid - 1]) && (mid + 1 >= nums.Length || nums[mid] < nums[mid + 1]))
                {
                    return mid;
                }
                else if (mid + 1 >= nums.Length || nums[mid] < nums[mid + 1])
                {
                    end = mid - 1;
                }
                else if (mid - 1 < 0 || nums[mid] < nums[mid - 1])
                {
                    start = mid + 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// 给定一个整数数组，求把这些整数表示在数轴上，相邻两个数差的最大值
        /// </summary>
        public static int MaxSpace(int[] nums)
        {
            //扫描数组，取得最大值和最小值
            //放置到n+1个桶区间里面，每个桶的区间长度是(max-min)/(n+1)
            //这么放置后肯定存在空桶，所以result的值肯定大于桶区间长度
            //扫描桶集合，result出现在其中一个桶的最大值和下一个非空的桶的最小值
            if (nums == null || nums.Length <= 1)
            {
                return 0;
            }

            int maxValue = int.MinValue;
            int minValue = int.MaxValue;
            foreach (var num in nums)
            {
                if (num > maxValue)
                {
                    maxValue = num;
                }

                if (num < minValue)
                {
                    minValue = num;
                }
            }

            var containerSet = new List<NumContainer>();
            for (int i = 0; i < nums.Length + 1; i++)
            {
                containerSet.Add(new NumContainer());
            }

            containerSet[nums.Length].addValue(maxValue);
            var interval = (double)(maxValue - minValue) / nums.Length;
            foreach (var num in nums)
            {
                if (num == maxValue)
                {
                    continue;
                }

                var index = (int)((num - minValue) / interval);
                containerSet[index].addValue(num);
            }

            var lastMax = containerSet[0].minValue;
            var result = 0;
            for (var i = 0; i < nums.Length + 1; i++)
            {
                if (containerSet[i].isEmpty)
                {
                    continue;
                }

                if (containerSet[i].minValue - lastMax > result)
                {
                    result = containerSet[i].minValue - lastMax;
                }

                lastMax = containerSet[i].maxValue;
            }

            return result;
        }

        private class NumContainer
        {
            public bool isEmpty = true;
            public int maxValue = int.MinValue;
            public int minValue = int.MaxValue;

            public void addValue(int value)
            {
                this.isEmpty = false;
                if (value > maxValue)
                {
                    maxValue = value;
                }

                if (value < minValue)
                {
                    minValue = value;
                }
            }
        }

        /// <summary>
        /// 把一个数组从p位置隔开，使得a[0]+a[1]+...+a[p-1]与a[p]+a[p+1]+...+a[n-1]的差值最小，求p
        /// </summary>
        public static int SeperateArray(int[] nums)
        {
            int sumOfNums = 0;
            foreach (var num in nums)
            {
                sumOfNums += num;
            }

            var minResult = int.MaxValue;
            var position = -1;
            var sumBeforeP = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (Math.Abs(sumOfNums - sumBeforeP * 2) < minResult)
                {
                    minResult = Math.Abs(sumOfNums - sumBeforeP * 2);
                    position = i;
                }

                sumBeforeP += nums[i];
            }

            return position;
        }

        /// <summary>
        /// 把一个非负的数组从p位置隔开，使得a[0]+a[1]+...+a[p-1]与a[p]+a[p+1]+...+a[n-1]的差值最小，求p
        /// </summary>
        public static int SeperateArray2(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            var start = 0;
            var end = nums.Length;
            var sumOfStart = 0;
            var sumOfEnd = 0;
            while (start < end)
            {
                if (sumOfStart < sumOfEnd)
                {
                    sumOfStart += nums[start];
                    start++;
                }
                else
                {
                    sumOfEnd += nums[end - 1];
                    end--;
                }
            }

            return start;
        }
    }
}
