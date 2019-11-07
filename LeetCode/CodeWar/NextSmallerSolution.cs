using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.CodeWar
{
    public static class NextSmallerSolution
    {
        /*
         Write a function that takes a positive integer and returns the next smaller positive integer containing the same digits.

For example:

nextSmaller(21) == 12
nextSmaller(531) == 513
nextSmaller(2071) == 2017
Return -1 (for Haskell: return Nothing, for Rust: return None), when there is no smaller number that contains the same digits. Also return -1 when the next smaller number with the same digits would require the leading digit to be zero.

nextSmaller(9) == -1
nextSmaller(111) == -1
nextSmaller(135) == -1
nextSmaller(1027) == -1 // 0721 is out since we don't write numbers with leading zeros
some tests will include very large numbers.
test data only employs positive integers.
The function you write for this challenge is the inverse of this kata: "Next bigger number with the same digits."
         */

        public static long BetterNextSmaller(long n)
        {
            // Strategy = go from right to left and find the first digit with a number greater to the left
            // eg 285123 - find the '1' because there's a greater number beside
            // Find the biggest number to the right, and switch the two
            // eg 285123 - switch the 5 and the 3 = 283125
            // Then, sort everything to the right of the index in descending order
            // eg 283125 -> 283521

            var str = n.ToString().ToCharArray();
            for (int i = str.Length-1; i >= 0; i--)
            {
                var nowChar = str[i];
                for(int j = str.Length - 1; j > i; j--)
                {
                    if (nowChar > str[j])
                    {
                        if (str[j] == '0' && i == 0)
                        {
                            continue;
                        }

                        var tempChar = str[j];
                        str[j] = str[i];
                        str[i] = tempChar;
                        var newCharList = new char[str.Length - i - 1];
                        Array.Copy(str, i + 1, newCharList, 0, str.Length - i -1);
                        var sortedList = newCharList.ToList();
                        sortedList.Sort((a, b) => -1 * a.CompareTo(b));
                        var result = string.Empty;
                        for(int k=0; k<= i; k++)
                        {
                            result+=str[k];
                        }

                        for(int k=i + 1; k < str.Length; k++)
                        {
                            result+=sortedList[k - i -1];
                        }

                        return long.Parse(result);
                    }
                }
            }

            return -1;
        }

        public static long NextSmaller(long n)
        {
            if (!HasNextSmallerNumber(n))
            {
                return -1;
            }

            var id = IdForLong(n);
            
            while (n >= 0)
            {
                n--;
                if (IdForLong(n) == id)
                {
                    return n;
                }
            }

            return -1;
        }

        public static string IdForLong(long n)
        {
            var temp = n.ToString();
            return String.Concat(temp.OrderBy(c => c));
        }

        public static bool HasNextSmallerNumber(long n)
        {
            var str = n.ToString();
            var temp = str.ToCharArray();
            var leastChar = temp[0];
            var nonZeroNums = 0;
            for (int i=1; i< str.Length; i++)
            {
                var c = temp[i];
                if (c == '0')
                {
                    if (nonZeroNums > 1)
                    {
                        continue;
                    }
                }
                else if (nonZeroNums <= 1)
                {
                    nonZeroNums++;
                }

                if (c < leastChar)
                {
                    return true;
                }
                else
                {
                    leastChar = c;
                }
            }

            return false;
        }
    }
}
