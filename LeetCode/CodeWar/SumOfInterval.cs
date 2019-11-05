using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.CodeWar
{
    public class Interval
    {
        public int min;
        public int max;
        public Interval(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }

    public static class SumOfInterval
    {
        private static bool HasOverlap(Interval i1, Interval i2)
        {
            if (i1.min == i1.max || i2.min == i2.max)
            {
                return false;
            }

            var overlap = false;
            if(i2.min < i1.min)
            {
                overlap = i2.max > i1.min;
            }
            else if (i2.min >= i1.min && i2.min < i1.max)
            {
                overlap = true;
            }
            else
            {
                overlap = false;
            }

            return overlap;
        }

        private static void UpdateInterval(List<Interval> iList, Interval i2)
        {
            var updateFlag = false;
            foreach (var i in iList)
            {
                if (HasOverlap(i, i2))
                {
                    updateFlag = true;
                    var updatedInterval = new Interval(Math.Min(i.min, i2.min), Math.Max(i.max, i2.max));
                    i.min = 0;
                    i.max = 0;
                    iList.Remove(i);
                    UpdateInterval(iList, updatedInterval);
                    break;
                }
            }

            if (!updateFlag)
            {
                iList.Add(i2);
            }
        }

        public static int SumIntervals((int, int)[] intervals)
        {
            var iList = new List<Interval>();
            foreach (var item in intervals)
            {
                var tempInterval = new Interval(item.Item1, item.Item2);
                UpdateInterval(iList, tempInterval);
            }

            var result = 0;
            foreach(var item in iList)
            {
                result += item.max - item.min;
            }

            return result;
        }
    }
}
