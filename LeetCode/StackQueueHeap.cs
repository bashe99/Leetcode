using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    // 设计一个栈，支持如下操作，栈的内部存储数据的结构为队列
    public class MyStack
    {
        private Queue<int> dataQueue = new Queue<int>();
        public void Push(int x)
        {
            var tempQueue = new Queue<int>();
            tempQueue.Enqueue(x);
            while (!this.Empty())
            {
                tempQueue.Enqueue(this.Pop());
            }

            while (tempQueue.Count > 0)
            {
                dataQueue.Enqueue(tempQueue.Dequeue());
            }
        }

        public int Pop()
        {
            return dataQueue.Dequeue();
        }

        public bool Empty()
        {
            return dataQueue?.Count <= 0;
        }
    }

    // 设计一个队列，支持如下操作，队列的内部存储数据的结构为栈
    public class MyQueue
    {
        private Stack<int> dataStack = new Stack<int>();
        public void Push(int x)
        {
            var tempStack = new Stack<int>();
            while (dataStack.Count > 0)
            {
                tempStack.Push(dataStack.Pop());
            }

            tempStack.Push(x);

            while (tempStack.Count > 0)
            {
                dataStack.Push(tempStack.Pop());
            }
        }

        public int Pop()
        {
            return dataStack.Pop();
        }

        public bool Empty()
        {
            return dataStack.Count <= 0;
        }
    }

    // 设计一个栈，支持如下操作，getMin()要求时间复杂度是O(1)
    public class MinStack
    {
        private Stack<int> dataStack = new Stack<int>();
        private Stack<int> minStack = new Stack<int>();
        public void Push(int x)
        {
            if (dataStack.Count > 0)
            {
                dataStack.Push(x);
                var currentMinValue = minStack.Peek();
                if (currentMinValue < x)
                {
                    minStack.Push(currentMinValue);
                }
                else
                {
                    minStack.Push(x);
                }
            }
            else
            {
                dataStack.Push(x);
                minStack.Push(x);
            }
        }

        public int Pop()
        {
            minStack.Pop();
            return dataStack.Pop();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }

    public static class StackQueueHeapUtils
    {
        // 已知从1至n的数字序列，按顺序入栈，每个数字入栈后即可出栈，也可以在栈中停留，等待后面的数字入栈出栈后，该数字再出栈，求该数字序列的出栈序列是否合法
        public static bool IsStackSequence(List<int> numList)
        {
            var tempStack = new Stack<int>();
            int index = 0;
            for (int i = 1; i <= numList.Count; i++)
            {
                tempStack.Push(i);
                while (tempStack.Count > 0 && tempStack.Peek() == numList[index])
                {
                    tempStack.Pop();
                    index++;
                }
            }

            return tempStack.Count == 0;
        }

        
        // 已知一个未排序的数组，求这个数组中第k大的数字
        public static int FindKthNum(List<int> numList, int k)
        {
            int startIndex = 0;
            int endIndex = numList.Count - 1;
            while (startIndex <= endIndex)
            {
                int pos = Partition(numList, startIndex, endIndex);
                if (pos == k - 1)
                {
                    return numList[pos];
                }
                else if (pos > k - 1)
                {
                    endIndex = pos;
                }
                else
                {
                    startIndex = pos + 1;
                }
            }

            return int.MinValue;
        }

        // 已知一个未排序的数组，求这个数组的中位数，若数据个数为奇数，返回排序后中间的数，否则返回排序后中间两个数的平均值
        public static double FindMidNum(List<int> numList)
        {
            if (numList.Count % 2 == 1)
            {
                return FindKthNum(numList, (numList.Count / 2) + 1);
            }
            else
            {
                var largeNum = FindKthNum(numList, numList.Count / 2);
                var lessNum = FindKthNum(numList, (numList.Count / 2) + 1);
                return (double)(largeNum + lessNum) / 2;
            }
        }

        private static int Partition(List<int> numList, int startIndex, int endIndex)
        {
            int value = numList[startIndex];
            int location = startIndex;
            var temp = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (numList[i] > value)
                {
                    location++;
                    temp = numList[i];
                    numList[i] = numList[location];
                    numList[location] = temp;
                }
            }

            temp = numList[startIndex];
            numList[startIndex] = numList[location];
            numList[location] = temp;

            return location;
        }
    }
}
