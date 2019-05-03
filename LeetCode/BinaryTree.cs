using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class BinaryTree
    {
        /// <summary>
        /// 给定一个二叉树和整数sum，找出所有从根节点到叶节点的路径，这些路径上的节点的值累加和为sum
        /// </summary>
        /// <param name="root">根节点</param>
        /// <param name="sum">累加和</param>
        public static List<List<int>> PathSum(TreeNode root, int sum)
        {
            var result = new List<List<int>>();
            var path = new List<int>();
            FindPathSum(root, sum, result, path);
            return result;
        }

        private static void FindPathSum(TreeNode root, int sum, List<List<int>> result, List<int> path)
        {
            if (root == null)
            {
                return;
            }

            path.Add(root.value);
            if (root.left == null && root.right == null && root.value == sum)
            {
                result.Add(new List<int>(path));
            }

            if (root.left != null && sum > root.value)
            {
                FindPathSum(root.left, sum - root.value, result, path);
            }

            if (root.right != null && sum > root.value)
            {
                FindPathSum(root.right, sum - root.value, result, path);
            }
            path.Remove(root.value);
        }

        /// <summary>
        /// 已知二叉树，求二叉树中给定的两个节点的最近公共祖先。
        /// </summary>
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var path1 = new List<TreeNode>();
            var finish1 = false;
            FindPathToNode(root, p, path1, ref finish1);

            var path2 = new List<TreeNode>();
            var finish2 = false;
            FindPathToNode(root, q, path2, ref finish2);

            int index = 0;
            while (index < path1.Count && index < path2.Count && path1[index] == path2[index])
            {
                index++;
            }

            return index == 0 ? null : path1[index - 1];
        }

        private static void FindPathToNode(TreeNode root, TreeNode p, List<TreeNode> result, ref bool finish)
        {
            if (root == p)
            {
                result.Add(p);
                finish = true;
                return;
            }
            else
            {
                result.Add(root);
                if (root.left != null)
                {
                    FindPathToNode(root.left, p, result, ref finish);
                    if (finish)
                    {
                        return;
                    }
                }

                if (root.right != null)
                {
                    FindPathToNode(root.right, p, result, ref finish);
                    if (finish)
                    {
                        return;
                    }
                }
                result.Remove(root);
            }

            return;
        }

        /// <summary>
        /// 给定一个二叉树，将该二叉树就地转换为单链表，单链表中节点顺序为二叉树前序遍历顺序
        /// </summary>
        /// <param name="root"></param>
        public static void Flatten(TreeNode root)
        {
            TreeNode last = null;
            FlattenCore(root, ref last);
        }

        private static void FlattenCore(TreeNode node, ref TreeNode last)
        {
            if (node == null)
            {
                return;
            }

            if (node.left == null && node.right == null)
            {
                last = node;
                return;
            }

            TreeNode leftLast = null;
            TreeNode rightLast = null;
            var tempLeft = node.left;
            var tempRight = node.right;
            if (node.left != null)
            {
                FlattenCore(node.left, ref leftLast);
                last = leftLast;
                node.left = null;
                node.right = tempLeft;
            }

            if (tempRight != null)
            {
                FlattenCore(tempRight, ref rightLast);
                last = rightLast;
                if (leftLast != null)
                {
                    leftLast.right = tempRight;
                }
            }
        }

        /// <summary>
        /// 二叉树宽度优先遍历（层次遍历），按数的层次依次访问树的节点
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<int> BFSBinaryTree(TreeNode root)
        {
            var result = new List<int>();
            var nodeStore = new Queue<TreeNode>();
            nodeStore.Enqueue(root);

            while (nodeStore.Count > 0)
            {
                var node = nodeStore.Dequeue();
                if (node != null)
                {
                    result.Add(node.value);
                    if (node.left != null)
                    {
                        nodeStore.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        nodeStore.Enqueue(node.right);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 给定一个二叉树，假设从该二叉树的右侧观察他，将观察到的节点按照从上到下的顺序输出
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<int> RightSideView(TreeNode root)
        {
            var layerResult = new Dictionary<int,int>();
            var nodeStore = new Queue<Tuple<TreeNode, int>>();
            var rootTuple = new Tuple<TreeNode, int>(root, 0);
            nodeStore.Enqueue(rootTuple);

            while (nodeStore.Count > 0)
            {
                var nodeTuple = nodeStore.Dequeue();
                var layer = nodeTuple.Item2;
                var node = nodeTuple.Item1;
                if (layerResult.ContainsKey(layer))
                {
                    layerResult[layer] = node.value;
                }
                else
                {
                    layerResult.Add(layer, node.value);
                }

                if (node.left != null)
                {
                    nodeStore.Enqueue(new Tuple<TreeNode, int>(node.left, layer + 1));
                }

                if (node.right != null)
                {
                    nodeStore.Enqueue(new Tuple<TreeNode, int>(node.right, layer + 1));
                }
            }

            var result = new List<int>();
            int layerIndex = 0;
            while (layerResult.ContainsKey(layerIndex))
            {
                result.Add(layerResult[layerIndex]);
                layerIndex++;
            }

            return result;
        }
    }
}
