using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class BinarySearchUtil
    {
        /// <summary>
        /// binary search
        /// </summary>
        /// <returns>index of the target, -1 if not found</returns>
        public static int BinarySearch(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (target == nums[mid])
                {
                    return mid;
                }
                else if (target > nums[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// binary search
        /// </summary>
        /// <returns>index of the target, -1 if not found</returns>
        public static int BinarySearchRecursive(int[] nums, int target)
        {
            return BinarySearchRecursiveCore(nums, target, 0, nums.Length - 1);
        }

        private static int BinarySearchRecursiveCore(int[] nums, int target, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = (start + end) / 2;
            if (target == nums[mid])
            {
                return mid;
            }
            else if (target > nums[mid])
            {
                return BinarySearchRecursiveCore(nums, target, mid + 1, end);
            }
            else
            {
                return BinarySearchRecursiveCore(nums, target, start, mid - 1);
            }
        }

        /// <summary>
        /// 给定一个排序数组nums（无重复元素）与目标值target，如果target在nums里，则返回target所在的下标，如果target在nums里未出现，则返回target应该插入位置的
        /// 数组下标，使得target插入nums后，数组仍然有序
        /// </summary>
        /// <returns></returns>
        public static int SearchInsert(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (target == nums[mid])
                {
                    return mid;
                }
                else if (target > nums[mid])
                {
                    if (mid == nums.Length - 1 || target < nums[mid + 1])
                    {
                        return mid + 1;
                    }

                    start = mid + 1;
                }
                else
                {
                    if (mid == 0 || target > nums[mid - 1])
                    {
                        return mid;
                    }

                    end = mid - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// 给定一个排序数组nums（nums中有重复元素）与目标值target，如果target在nums里出现，则返回target所在区间的左右端点下标，如果未出现，返回[-1,-1]
        /// </summary>
        public static int[] SearchRange(int[] nums, int target)
        {
            int leftIndex = SearchLeftRange(nums, target);
            int rightIndex = SearchRightRange(nums, target);

            return new int[] { leftIndex, rightIndex };
        }

        private static int SearchLeftRange(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    if (mid == 0 || nums[mid - 1] != target)
                    {
                        return mid;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
                else if (target > nums[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }

        private static int SearchRightRange(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    if (mid == nums.Length - 1 || nums[mid + 1] != target)
                    {
                        return mid;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else if (target > nums[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }
        
        /// <summary>
        /// 1，给定一个排序数组（无重复元素）
        /// 2，对数组以某个未知下标旋转
        /// 3，给定目标值target
        /// 4，返回target的下标，如果不存在返回-1
        /// </summary>
        public static int SearchInReverseNums(int[] nums, int target)
        {
            //根据start和end元素的大小，判断旋转下标是否在此区间，然后根据这个情况更新start和end
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (target > nums[mid])
                {
                    if (nums[start] < nums[mid])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        if (target == nums[end])
                        {
                            return end;
                        }
                        else if (target < nums[end])
                        {
                            start = mid + 1;
                        }
                        else
                        {
                            end = mid - 1;
                        }
                    }
                }
                else
                {
                    if (nums[mid] < nums[end])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        if (target == nums[start])
                        {
                            return start;
                        }
                        else if (target > nums[start])
                        {
                            end = mid - 1;
                        }
                        else
                        {
                            start = mid + 1;
                        }
                    }
                }
            }

            return -1;
        }
    }

    public static class BSTUtil
    {
        public static void BSTInsert(TreeNode root, int value)
        {
            if (root.value > value)
            {
                if (root.left != null)
                {
                    BSTInsert(root.left, value);
                }
                else
                {
                    TreeNode newNode = new TreeNode(value);
                    root.left = newNode;
                }
            }
            else
            {
                if (root.right != null)
                {
                    BSTInsert(root.right, value);
                }
                else
                {
                    TreeNode newNode = new TreeNode(value);
                    root.right = newNode;
                }
            }
        }

        /// <summary>
        /// 给定一个二叉树，实现编码和解码，编码：二叉树=》数组；解码：数组=》二叉树
        /// </summary>
        /// <param name="nodeList"></param>
        /// <returns></returns>
        public static List<int> Serialize(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            var result = new List<int>();
            SerializeCore(root, result);
            return result;
        }

        private static void SerializeCore(TreeNode node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            result.Add(node.value);
            SerializeCore(node.left, result);
            SerializeCore(node.right, result);
        }

        public static TreeNode Deserialize(List<int> nodeList)
        {
            if (nodeList == null || nodeList.Count == 0)
            {
                return null;
            }

            var root = new TreeNode(nodeList[0]);
            for (int i = 1; i < nodeList.Count; i++)
            {
                BSTInsert(root, nodeList[i]);
            }

            return root;
        }
    }
}
