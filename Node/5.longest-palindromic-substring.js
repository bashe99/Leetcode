/*
 * @lc app=leetcode id=5 lang=javascript
 *
 * [5] Longest Palindromic Substring
 *
 * https://leetcode.com/problems/longest-palindromic-substring/description/
 *
 * algorithms
 * Medium (26.46%)
 * Total Accepted:    486.7K
 * Total Submissions: 1.8M
 * Testcase Example:  '"babad"'
 *
 * Given a string s, find the longest palindromic substring in s. You may
 * assume that the maximum length of s is 1000.
 * 
 * Example 1:
 * 
 * 
 * Input: "babad"
 * Output: "bab"
 * Note: "aba" is also a valid answer.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "cbbd"
 * Output: "bb"
 * 
 * 
 */
/**
 * @param {string} s
 * @return {string}
 */
var longestPalindrome = function(s) {
    let container = {};
    let sArray = Array.from(s);
    sArray.map((c,index) => {
        if (!container[c]) {
            container[c] = [index];
        } else {
            container[c].push(index);
        }
    });

    let maxLength = 0;
    let maxValue = "";;
    sArray.map((c, index) => {
        for (let j=container[c].length -1; j>= 0; j--) {
            let saveIndex = container[c][j];
            if (saveIndex >= index) {
                let testStr = s.slice(index, saveIndex + 1);
                if (isPalindromic(testStr)) {
                    if(maxLength < saveIndex - index + 1) {
                        maxLength = saveIndex - index + 1;
                        maxValue = testStr;
                    }

                    j = -1;
                }
            }
        }
    });

    return maxValue;
};

function isPalindromic(str) {
    let i = 0;
    let j = str.length -1;
    while(i < j) {
        if (str[i] == str[j]) {
            i++;
            j--;
        } else {
            return false;
        }
    }

    return true;
    // return str ===  Array.from(str).reverse().join('');
}

