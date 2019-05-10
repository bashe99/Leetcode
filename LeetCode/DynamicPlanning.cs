using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class DynamicPlanning
    {
        /// <summary>
        /// 在爬楼梯时，每次可以向上走1级或两级台阶，问n级楼梯有多少种上楼方式
        /// </summary>
        public static int ClimbStairs(int n)
        {
            var results = new int[n+3];
            results[0] = 0;
            results[1] = 1;
            results[2] = 2;

            if (n < 3)
            {
                return results[n];
            }

            for (int i = 3; i <= n; i++)
            {
                results[i] = results[i - 1] + results[i - 2];
            }

            return results[n];
        }

        /// <summary>
        /// 在一条直线上，有n个房屋，每个房屋中有数量不等的财宝，一个小偷希望从房屋中偷取财宝，由于房间有报警器，如果同时从相邻的
        /// 两个房屋中盗取财宝就会触发警报。问小偷最多能偷取多少财宝
        /// </summary>
        public static int Rob(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            else if (nums.Length == 2)
            {
                return Math.Max(nums[1], nums[0]);
            }

            var results = new int[nums.Length + 2];
            results[0] = nums[0];
            results[1] = Math.Max(nums[1], nums[0]);

            for (int i = 2; i < nums.Length; i++)
            {
                results[i] = Math.Max(results[i - 2] + nums[i], results[i - 1]);
            }

            return results[nums.Length - 1];
        }

        /// <summary>
        /// 给定一个数组，求这个数组的连续子数组中，最大的那一段的和
        /// </summary>
        public static int MaxSubArray(int[] nums)
        {
            int result = int.MinValue;
            int tempResult = 0;
            foreach (var num in nums)
            {
                tempResult += num;
                if (tempResult > result)
                {
                    result = tempResult;
                }

                if (tempResult < 0)
                {
                    tempResult = 0;
                }
            }

            return result;
        }

        public static int MaxSubArray2(int[] nums)
        {
            var result = new int[nums.Length]; // result[i]代表以nums[i]结尾的结果
            var max = nums[0];
            result[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                result[i] = Math.Max(result[i - 1] + nums[i], nums[i]);
                if (result[i] > max)
                {
                    max = result[i];
                }
            }

            return max;
        }

        /// <summary>
        /// 已知不同面值的钞票，求如何用最少数量的钞票组成某个金额，求可以使用的最少钞票数量，如果无法组成返回-1
        /// </summary>
        public static int CoinChange(int[] coins, int amount)
        {
            var results = new int[amount + 1];
            results[0] = 0;
            for (int i = 1; i < results.Length; i++)
            {
                results[i] = -1;
            }

            for (int i = 1; i <= amount; i++)
            {
                var min = int.MaxValue;
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i >= coins[j] && results[i - coins[j]] != -1 && results[i - coins[j]] < min)
                    {
                        min = results[i - coins[j]];
                    }
                }

                results[i] = min == int.MaxValue ? -1 : min + 1;
            }

            return results[amount];
        }

        /// <summary>
        /// 给定一个二维数组，保存了一个数字三角形，求从数字三角形顶端到低端各数字和最小的路径之和，每次可以向下走相邻的两个位置
        /// </summary>
        public static int MinimumTotal(List<List<int>> triangle)
        {
            // 从顶部到底部
            var result = new List<List<int>>();
            result.Add(new List<int> { triangle[0][0] });

            for (int i = 1; i < triangle.Count; i++)
            {
                var tempResult = new List<int>();
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    var leftValue = int.MaxValue;
                    var rightValue = int.MaxValue;
                    if (j > 0)
                    {
                        leftValue = result[i - 1][j - 1];
                    }

                    if (j < result[i - 1].Count)
                    {
                        rightValue = result[i - 1][j];
                    }

                    var minValue = Math.Min(leftValue, rightValue) + triangle[i][j];
                    tempResult.Add(minValue);
                }

                result.Add(tempResult);
            }

            int index = result.Count - 1;
            int minResult = result[index][0];
            for (int i = 0; i < result[index].Count; i++)
            {
                if (result[index][i] < minResult)
                {
                    minResult = result[index][i];
                }
            }

            return minResult;
        }

        public static int MinimumTotal2(List<List<int>> triangle)
        {
            // 从底部到顶部
            var result = new List<List<int>>(triangle);
            for (int i = result.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < result[i].Count; j++)
                {
                    result[i][j] = Math.Min(result[i + 1][j], result[i + 1][j + 1]) + result[i][j];
                }
            }

            return result[0][0];
        }

        /// <summary>
        /// 已知一个未排序的数组，求这个数组的最长上升子序列的长度
        /// </summary>
        public static int LengthOfLIS(int[] nums)
        {
            var result = new int[nums.Length]; // result[i]代表以nums[i]结尾的结果
            result[0] = 1;
            int maxResult = 1;

            for (int index = 1; index < nums.Length; index++)
            {
                var current = nums[index];
                int tempMax = 1;
                for (int j = 0; j < index; j++)
                {
                    if (current > nums[j] && result[j] + 1 > tempMax)
                    {
                        tempMax = result[j] + 1;
                    }
                }

                result[index] = tempMax;
                if (tempMax > maxResult)
                {
                    maxResult = tempMax;
                }
            }

            return maxResult;
        }
    }
}
