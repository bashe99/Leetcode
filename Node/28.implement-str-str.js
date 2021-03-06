/*
 * @lc app=leetcode id=28 lang=javascript
 *
 * [28] Implement strStr()
 *
 * https://leetcode.com/problems/implement-strstr/description/
 *
 * algorithms
 * Easy (31.15%)
 * Total Accepted:    380.8K
 * Total Submissions: 1.2M
 * Testcase Example:  '"hello"\n"ll"'
 *
 * Implement strStr().
 * 
 * Return the index of the first occurrence of needle in haystack, or -1 if
 * needle is not part of haystack.
 * 
 * Example 1:
 * 
 * 
 * Input: haystack = "hello", needle = "ll"
 * Output: 2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: haystack = "aaaaa", needle = "bba"
 * Output: -1
 * 
 * 
 * Clarification:
 * 
 * What should we return when needle is an empty string? This is a great
 * question to ask during an interview.
 * 
 * For the purpose of this problem, we will return 0 when needle is an empty
 * string. This is consistent to C's strstr() and Java's indexOf().
 * 
 */
/**
 * @param {string} haystack
 * @param {string} needle
 * @return {number}
 */
var strStr = function(haystack, needle) {
    if (!needle) {
        return 0;
    }

    let nlength = needle.length;
    let hlength = haystack.length;
    let result = 0;
    
    while(result + nlength <= hlength) {
        if (charSetMatch(haystack, needle, result, result+nlength)) {
            return result;
        } else {
            result++;
        }
    }

    if (result + nlength > haystack.length) {
        return -1;
    }

    return result;
};

var charSetMatch = function(str1, str2, start, end) {
    for(let i= start; i< end; i++) {
        if(str1[i] != str2[i-start]) {
            return false;
        }
    }

    return true;
}


