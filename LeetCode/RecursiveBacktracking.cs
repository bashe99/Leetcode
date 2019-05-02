using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class RecursiveBacktracking
    {
        // 已知一组数（无重复的元素），求这组数可以组成的所有子集。结果中不可有重复的子集
        public static List<List<int>> FindSubsets(List<int> nums)
        {
            var result = new List<List<int>>();
            var item = new List<int>();
            result.Add(new List<int>(item));
            result = GenerateSubsets(0, nums, item, result);
            return result;
        }

        private static List<List<int>> GenerateSubsets(int index, List<int> nums, List<int> item, List<List<int>> result)
        {
            if (index >= nums.Count)
            {
                return result;
            }

            item.Add(nums[index]);
            result.Add(new List<int>(item));
            result = GenerateSubsets(index + 1, nums, item, result);
            item.Remove(nums[index]);
            result = GenerateSubsets(index + 1, nums, item, result);
            return result;
        }

        public static List<List<int>> FindSubsets2(List<int> nums)
        {
            // 利用按位与决定是否添加第index个元素，001代表添加第一个，010代表添加第二个。。。
            var result = new List<List<int>>();
            int subSetLength = 1 << nums.Count;
            for (int i = 0; i < subSetLength; i++)
            {
                var item = new List<int>();
                for (int index = 0; index < nums.Count; index++)
                {
                    if ((i & (1 << index)) != 0)
                    {
                        item.Add(nums[index]);
                    }
                }
                result.Add(item);
            }

            return result;
        }

        // 已知一组数（可能有重复元素），求这组数可以组成的所有子集。结果中无重复的子集，如[1,2,2]与[2,1,2]为重复子集
        public static List<List<int>> FindSubsetsInDupList(List<int> nums)
        {
            int searchSize = 1 << nums.Count;
            var result = new List<List<int>>();
            for (int current = 0; current < searchSize; current++)
            {
                var item = new List<int>();
                for (int index = 0; index < nums.Count; index++)
                {
                    if ((current & (1 << index)) != 0)
                    {
                        item.Add(nums[index]);
                    }
                }

                if (!ContainsSubset(result, item))
                {
                    result.Add(item);
                }
            }

            return result;
        }


        public static bool ContainsSubset(List<List<int>> nums, List<int> subset)
        {
            foreach (var set in nums)
            {
                var flag = true;
                var tempSet = new List<int>(set);
                foreach (var num in subset)
                {
                    if (!tempSet.Contains(num))
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        tempSet.Remove(num);
                    }
                }

                if (flag == true)
                {
                    return true;
                }
            }

            return false;
        }

        // 已知一组数（可能有重复元素），求这组数可以组成的所有子集中，子集中的各个元素和为证书target的子集，结果中无重复的子集
        public static List<List<int>> FindSubsetsWithTargetSum(List<int> nums, int target)
        {
            int searchSize = 1 << nums.Count;
            var result = new List<List<int>>();
            for (int current = 0; current < searchSize; current++)
            {
                var item = new List<int>();
                bool shouldSkip = false;
                int tempSum = 0;
                for (int index = 0; index < nums.Count; index++)
                {
                    if ((current & (1 << index)) != 0)
                    {
                        if (nums[index] > target || tempSum > target)
                        {
                            shouldSkip = true;
                            break;
                        }

                        tempSum += nums[index];
                        item.Add(nums[index]);
                    }
                }

                if (!shouldSkip && tempSum == target && !ContainsSubset(result, item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        /// <summary>
        /// 有n组括号，有多少组合法的组合可能
        /// </summary>
        public static List<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            GenerateParenthesisCore(string.Empty, n, n, result);
            return result;
        }

        /// <param name="item">目前生成的string</param>
        /// <param name="left">还可以放置多少个左括号</param>
        /// <param name="right">还可以放置多少个右括号</param>
        /// <param name="result">结果</param>
        private static void GenerateParenthesisCore(string item, int left, int right, List<string> result)
        {
            if (left == 0 && right == 0)
            {
                result.Add(item);
                return;
            }

            if (left > 0)
            {
                GenerateParenthesisCore(item + '(', left - 1, right, result);
            }

            if (left < right)
            {
                GenerateParenthesisCore(item + ')', left, right-1, result);
            }
        }

        /// <summary>
        /// 将N个皇后摆放在N*N的棋盘中，互相不可攻击，应该怎么摆放。皇后可以横竖斜线攻击。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<List<string>> SolveNQueens(int n)
        {
            var mark = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
            {
                var tempLine = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    tempLine.Add(0);
                }

                mark.Add(tempLine);
            }

            var result = new List<List<string>>();
            char[,] location = new char[n,n];
            SolveNQueensCore(0, n, location, result, mark);
            return result;
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="x">皇后的x坐标</param>
        /// <param name="y">皇后的y坐标</param>
        /// <param name="mark">棋盘，1为会受到攻击位置</param>
        private static void PutDownTheQueen(int x, int y, List<List<int>> mark)
        {
            var attackX = new List<int> { -1, 1, 0, 0, -1, -1, 1, 1 };
            var attackY = new List<int> { 0, 0, 1, -1, 1, -1, 1, -1 };
            mark[x][y] = 1;
            for (int i = 1; i < mark.Count; i++)
            {
                for (int attackIndex = 0; attackIndex < 8; attackIndex++)
                {
                    int newX = x + i * attackX[attackIndex];
                    int newY = y + i * attackY[attackIndex];
                    if (newX >= 0 && newY >= 0 && newX < mark.Count && newY < mark.Count)
                    {
                        mark[newX][newY] = 1;
                    }
                }
            }
        }

        /// <param name="k">放第k个皇后,每行一个，也代表目前正在处理的棋盘行数</param>
        /// <param name="n">总共需要放n个皇后</param>
        /// <param name="location">到目前为止的临时放置结果</param>
        /// <param name="result">结果</param>
        /// <param name="mark">棋盘，1为会受到攻击位置</param>
        private static void SolveNQueensCore(int k, int n, char[,] location, List<List<string>> result, List<List<int>> mark)
        {
            if (k == n - 1)
            {
                result.Add(ConvertCharList(location, n));
                return;
            }

            for (int i = 0; i < mark.Count; i++)
            {
                if (mark[k][i] == 0)
                {
                    var tempMark = new List<List<int>>(mark);
                    location[k,i] = 'Q';
                    PutDownTheQueen(k, i, mark);
                    SolveNQueensCore(k + 1, n, location, result, mark);
                    mark = tempMark;
                    location[k,i] = '.';
                }
            }
        }

        private static List<string> ConvertCharList(char[,] charLists, int rowSize)
        {
            var result = new List<string>();
            for (int i = 0; i < rowSize; i++)
            {
                var tempStr = string.Empty;
                for (int j = 0; j < rowSize; j++)
                {
                    tempStr += charLists[i, j];
                }

                result.Add(tempStr);
            }

            return result;
        }
    }
}
