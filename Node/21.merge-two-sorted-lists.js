/*
 * @lc app=leetcode id=21 lang=javascript
 *
 * [21] Merge Two Sorted Lists
 *
 * https://leetcode.com/problems/merge-two-sorted-lists/description/
 *
 * algorithms
 * Easy (45.64%)
 * Total Accepted:    505.8K
 * Total Submissions: 1.1M
 * Testcase Example:  '[1,2,4]\n[1,3,4]'
 *
 * Merge two sorted linked lists and return it as a new list. The new list
 * should be made by splicing together the nodes of the first two lists.
 * 
 * Example:
 * 
 * Input: 1->2->4, 1->3->4
 * Output: 1->1->2->3->4->4
 * 
 * 
 */
/**
 * Definition for singly-linked list.
//  * function ListNode(val) {
//  *     this.val = val;
//  *     this.next = null;
//  * }
//  */
/**
 * @param {ListNode} l1
 * @param {ListNode} l2
 * @return {ListNode}
 */

var mergeTwoLists = function(l1, l2) {
    let result = [];
    let l1Index = 0;
    let l2Index = 0;

    while(l1 && l2 && l1Index < l1.length && l2Index < l2.length) {
        console.log(l1.length);
        if (l1[l1Index] <= l2[l2Index]) {
            result.push(l1[l1Index]);
            l1Index++;
        } else {
            result.push(l2[l2Index]);
            l2Index++;
        }
    }

    if (l1 && l2 && l1Index >= l1.length && l2Index < l2.length -1) {
        result = result.concat(l2.slice(l2Index));
    } else if (l1 && l2 && l2Index >= l2.length && l1Index < l1.length -1) {
        result = result.concat(l1.slice(l1Index));
    }

    return result;
};
