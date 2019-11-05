using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.CodeWar
{
    public class StripCommentsSolution
    {
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
