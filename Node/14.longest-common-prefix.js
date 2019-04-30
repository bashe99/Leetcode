/*
 * @lc app=leetcode id=14 lang=javascript
 *
 * [14] Longest Common Prefix
 *
 * https://leetcode.com/problems/longest-common-prefix/description/
 *
 * algorithms
 * Easy (32.94%)
 * Total Accepted:    405.6K
 * Total Submissions: 1.2M
 * Testcase Example:  '["flower","flow","flight"]'
 *
 * Write a function to find the longest common prefix string amongst an array
 * of strings.
 * 
 * If there is no common prefix, return an empty string "".
 * 
 * Example 1:
 * 
 * 
 * Input: ["flower","flow","flight"]
 * Output: "fl"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: ["dog","racecar","car"]
 * Output: ""
 * Explanation: There is no common prefix among the input strings.
 * 
 * 
 * Note:
 * 
 * All given inputs are in lowercase letters a-z.
 * 
 */
/**
 * @param {string[]} strs
 * @return {string}
 */
var longestCommonPrefix = function(strs) {
    let firstStr = strs[0];
    let prefix = "";
    if (firstStr) {
        let endIndex = firstStr.length;
        let midIndex = endIndex/2;
        while(midIndex < endIndex) {
            prefix = firstStr.slice(0, midIndex);
            if (matchPrefix(strs, prefix)) {
                midIndex = (endIndex + midIndex) / 2;
            } else {
                endIndex = midIndex;
                midIndex = endIndex/2;
            }
        } 

        let newPrefix = firstStr.slice(0, midIndex);
        if (matchPrefix(strs, newPrefix)) {
            return newPrefix;
        }
    }

    return prefix;
};

var matchPrefix = (strs, prefix) => {
    for(let i=0; i<strs.length; i++) {
        if (strs[i].indexOf(prefix) != 0) {
            return false;
        }
    }

    return true;
}
