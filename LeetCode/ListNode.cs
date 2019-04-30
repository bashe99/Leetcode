using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class ListNodeMethod
    {
        public static string PrintListNode(ListNode head)
        {
            string result = string.Empty;
            while (head != null)
            {
                result += head.val.ToString();
                head = head.next;
            }

            return result;
        }

        public static string PrintListNode(RandomListNode head)
        {
            string result = string.Empty;
            while (head != null)
            {
                var randomStr = head.random != null ? head.random.val.ToString() : "";
                result = result + head.val.ToString() + "_" + randomStr + "=>";
                head = head.next;
            }

            return result;
        }

        // 已知链表头结点指针head，将链表逆序。
        public static ListNode ReverseListNode(ListNode head)
        {
            ListNode newHead = null;
            while (head != null)
            {
                var tempNode = head.next;
                head.next = newHead;
                newHead = head;
                head = tempNode;
            }

            return newHead;
        }

        // 已知链表头节点指针head，将链表从位置start到end逆序
        public static ListNode ReverseListNodeWithIndex(ListNode head, uint start, uint end)
        {
            ListNode result = head;
            var changeNode = end - start + 1;
            ListNode preHead = null;
            
            for (int i = 0; i < start - 1 && head != null; i++)
            {
                preHead = head;
                head = head.next;
            }

            ListNode modifyTail = head;
            ListNode newHead = null;
            while (head != null && changeNode > 0)
            {
                ListNode tempNext = head.next;
                head.next = newHead;
                newHead = head;
                head = tempNext;
                changeNode--;
            }

            modifyTail.next = head;
            if (preHead != null)
            {
                preHead.next = newHead;
            }
            else
            {
                result = newHead;
            }

            return result;
        }

        // 已知链表A的头节点headA，链表B的头节点headB，两个链表相交，求交点对应的节点
        public static int GetListNodeLength(ListNode head)
        {
            var result = 0;
            while (head != null)
            {
                result++;
                head = head.next;
            }

            return result;
        }

        public static ListNode GetIntersetionNode(ListNode headA, ListNode headB)
        {
            var lengthA = GetListNodeLength(headA);
            var lengthB = GetListNodeLength(headB);

            if (lengthA > lengthB)
            {
                for (int i = 0; i < lengthA - lengthB; i++)
                {
                    headA = headA.next;
                }
            }
            else
            {
                for (int i = 0; i < lengthB - lengthA; i++)
                {
                    headB = headB.next;
                }
            }

            while (headA != null && headB != null)
            {
                if (headA == headB)
                {
                    return headA;
                }
                else
                {
                    headA = headA.next;
                    headB = headB.next;
                }
            }

            return null;
        }

        // 已知链表中可能存在环，若有环，返回环入口节点，否则返回null
        public static ListNode DetectCycle(ListNode head)
        {
            // 快指针：每次走两步， 慢指针： 每次走一步。
            // 第一次相遇时，n为快指针多走了n圈，c为环的周长。有：a + b = slow; a + b + nc = fast = 2* slow; 可推得：a + b = nc = slow
            // 结合图可以看出，从相遇点M开始，再走a步，会回到环入口(a+b = nc)。从head出发，走a步，也会到达环入口。所以下次相遇时必在入口处。
            ListNode fast = head;
            ListNode slow = head;

            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;

                if (fast != null)
                {
                    fast = fast.next;
                }

                if (fast == slow)
                {
                    break;
                }
            }

            while (head != null && fast != null && head != fast)
            {
                fast = fast.next;
                head = head.next;
            }

            return head;
        }

        // 已知链表头指针head与数值value，将所有小于value的节点放在大于等于value的节点前，且保持这些节点原来的相对位置
        public static ListNode PartitionListNode(ListNode head, int value)
        {
            ListNode headSmaller = null;
            ListNode nodeSmaller = null;
            ListNode headBigger = null;
            ListNode nodeBigger = null;

            while (head != null)
            {
                if (head.val < value)
                {
                    if (headSmaller == null)
                    {
                        headSmaller = head;
                        nodeSmaller = head;
                    }
                    else
                    {
                        nodeSmaller.next = head;
                        nodeSmaller = head;
                    }
                }
                else
                {
                    if (headBigger == null)
                    {
                        headBigger = head;
                        nodeBigger = head;
                    }
                    else
                    {
                        nodeBigger.next = head;
                        nodeBigger = head;
                    }
                }

                head = head.next;
            }

            if (nodeSmaller != null)
            {
                nodeSmaller.next = headBigger;
            }

            if (nodeBigger != null)
            {
                nodeBigger.next = null;
            }

            return headSmaller != null ? headSmaller : headBigger;
        }

        // 已知一个复杂的链表，节点中有一个指向本链表任意某个节点的随机指针（可以为null），实现这个链表的深度拷贝
        public static RandomListNode DeepCloneRandomListNode(RandomListNode head)
        {
            RandomListNode tempNode = null;
            var nodeToIDMap = new Dictionary<RandomListNode, int>();
            int id = 0;
            tempNode = head;
            while (tempNode != null)
            {
                if (!nodeToIDMap.ContainsKey(tempNode))
                {
                    nodeToIDMap.Add(tempNode, id);
                    id++;
                }

                tempNode = tempNode.next;
            }

            var idToNodeMap = new Dictionary<int, RandomListNode>();
            id = 0;
            RandomListNode newHead = null;
            RandomListNode newNode = null;
            RandomListNode tempHeadNode = head;
            while (tempHeadNode != null)
            {
                tempNode = new RandomListNode(tempHeadNode.val, null, null);
                if (newHead == null)
                {
                    newHead = tempNode;
                }
                else
                {
                    newNode.next = tempNode;
                }

                newNode = tempNode;
                if (!idToNodeMap.ContainsKey(id))
                {
                    idToNodeMap.Add(id, tempNode);
                    id++;
                }

                tempHeadNode = tempHeadNode.next;
            }

            tempNode = newHead;
            while (tempNode != null && head != null)
            {
                if (head.random == null)
                {
                    tempNode.random = null;
                }
                else
                {
                    var currentId = nodeToIDMap[head.random];
                    tempNode.random = idToNodeMap[currentId];
                }

                head = head.next;
                tempNode = tempNode.next;
            }

            return newHead;
        }

        // 已知k个已经排好序的链表头节点指针，将这k个链表合并，合并后仍然是有序的，返回合并后的头节点
        public static ListNode MergeListNodes(List<ListNode> headers)
        {
            ListNode newHead = null;
            ListNode newTempNode = null;
            int doneNumber = 0;

            while (doneNumber < headers.Count -1)
            {
                ListNode smallestNode = null;
                int smallestValue = int.MaxValue;
                int iFlag = int.MinValue;
                for (int i = 0; i < headers.Count; i++)
                {
                    if (smallestNode == null && headers[i] != null)
                    {
                        smallestNode = headers[i];
                        smallestValue = headers[i].val;
                        iFlag = i;
                    }
                    else if (headers[i]?.val < smallestValue)
                    {
                        smallestNode = headers[i];
                        smallestValue = headers[i].val;
                        iFlag = i;
                    }
                }

                if (newHead == null)
                {
                    newHead = smallestNode;
                }
                else
                {
                    newTempNode.next = smallestNode;
                }

                newTempNode = smallestNode;
                headers[iFlag] = headers[iFlag].next;
                if (headers[iFlag] == null)
                {
                    doneNumber++;
                }

                smallestNode = null;
                smallestValue = int.MaxValue;
                iFlag = int.MinValue;
            }

            foreach (var header in headers)
            {
                if (header != null)
                {
                    newTempNode.next = header;
                }
            }

            return newHead;
        }
    }
}
