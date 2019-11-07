using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.CodeWar
{
    public class StripCommentsSolution
    {
        /*
         Complete the solution so that it strips all text that follows any of a set of comment markers passed in. Any whitespace at the end of the line should also be stripped out.

Example:

Given an input string of:

apples, pears # and bananas
grapes
bananas !apples
The output expected would be:

apples, pears
grapes
bananas
The code would be called like so:

string stripped = StripCommentsSolution.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new [] { "#", "!" })
// result should == "apples, pears\ngrapes\nbananas"
         */
        public static string StripComments(string text, string[] commentSymbols)
        {
            var commentsMap = new HashSet<string>(commentSymbols);
            var textList = text.Split('\n');
            var resultList = new List<string>();
            foreach (var line in textList)
            {
                var templine = string.Empty;
                var added = false;
                foreach(var c in line)
                {
                    if (commentsMap.Contains(c.ToString()))
                    {
                        resultList.Add(templine.TrimEnd());
                        added = true;
                        break;
                    }
                    else
                    {
                        templine += c;
                    }
                }

                if (!added)
                {
                    resultList.Add(templine.TrimEnd());
                }
            }

            return String.Join('\n', resultList);
        }
    }
}
