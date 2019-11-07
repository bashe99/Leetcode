using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.CodeWar
{
    /*
     Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.

array = [[1,2,3],
         [4,5,6],
         [7,8,9]]
snail(array) #=> [1,2,3,6,9,8,7,4,5]
For better understanding, please follow the numbers of the next array consecutively:

array = [[1,2,3],
         [8,9,4],
         [7,6,5]]
snail(array) #=> [1,2,3,4,5,6,7,8,9]
This image will illustrate things more clearly:


NOTE: The idea is not sort the elements from the lowest value to the highest; the idea is to traverse the 2-d array in a clockwise snailshell pattern.

NOTE 2: The 0x0 (empty matrix) is represented as en empty array inside an array [[]].
         */
    public class SnailSolution
    {
        public static int[] Snail(int[][] array)
        {
            var result = new List<int>();
            int level = 0;
            int total = array[0].Length;
            while(level <= total -1 -level)
            {
                result = GoThoughSnail(array, level, total, result);
                level++;
            }

            return result.ToArray();
        }

        public static List<int> GoThoughSnail(int[][] array, int level, int total, List<int> lastResult)
        {
            for (int i=level; i<=total-1-level; i++)
            {
                lastResult.Add(array[level][i]);
            }

            for (int i = level+1; i<= total -1 -level; i++)
            {
                lastResult.Add(array[i][total - 1 - level]);
            }

            for (int i=total -2 -level; i >= level; i --)
            {
                lastResult.Add(array[total - 1 - level][i]);
            }

            for(int i= total-2-level; i> level; i--)
            {
                lastResult.Add(array[i][level]);
            }

            return lastResult;
        }
    }
}
