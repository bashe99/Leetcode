﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val, ListNode next)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class RandomListNode
    {
        public int val;
        public RandomListNode next;
        public RandomListNode random;

        public RandomListNode(int val, RandomListNode next, RandomListNode random)
        {
            this.val = val;
            this.next = next;
            this.random = random;
        }
    }

    public class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val)
        {
            this.value = val;
            this.left = null;
            this.right = null;
        }
    }
}
