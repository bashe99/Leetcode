/*
 * @lc app=leetcode id=1 lang=javascript
 *
 * [1] Two Sum
 *
 * https://leetcode.com/problems/two-sum/description/
 *
 * algorithms
 * Easy (40.70%)
 * Total Accepted:    1.4M
 * Total Submissions: 3.5M
 * Testcase Example:  '[2,7,11,15]\n9'
 *
 * Given an array of integers, return indices of the two numbers such that they
 * add up to a specific target.
 * 
 * You may assume that each input would have exactly one solution, and you may
 * not use the same element twice.
 * 
 * Example:
 * 
 * 
 * Given nums = [2, 7, 11, 15], target = 9,
 * 
 * Because nums[0] + nums[1] = 2 + 7 = 9,
 * return [0, 1].
 * 
 * 
 * 
 * 
 */
/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var twoSum = function(nums, target) {
    let newNums = JSON.parse(JSON.stringify(nums));
    newNums.sort((a,b)=>a-b);
    let leftIndex = 0;
    let rightIndex = newNums.length -1;
    while(leftIndex <= rightIndex) {
        let sum = newNums[leftIndex] + newNums[rightIndex];
        if (sum == target) {
            let actualLeftIndex = nums.indexOf(newNums[leftIndex]);
            let actualRightIndex = nums.lastIndexOf(newNums[rightIndex]);
            return [actualLeftIndex, actualRightIndex];
        } else if (sum > target) {
            rightIndex--;
        } else {
            leftIndex++;
        }
    }

    return [];
};

var twoSum2 = function(nums, target) {
    let records = {};
    nums.forEach((element,index) => {
        if(records[element]) {
            records[element].push(index);
        } else {
            records[element] = [index];
        }
    });

    nums.sort((a,b)=>a-b);
    let leftIndex = 0;
    let rightIndex = nums.length -1;
    while(leftIndex <= rightIndex) {
        let sum = nums[leftIndex] + nums[rightIndex];
        if (sum == target) {
            let actualLeftIndex = records[nums[leftIndex]][0];
            let rightArray = records[nums[rightIndex]];
            let actualRightIndex = rightArray[rightArray.length -1]
            return [actualLeftIndex, actualRightIndex];
        } else if (sum > target) {
            rightIndex--;
        } else {
            leftIndex++;
        }
    }

    return [];
};

let result = twoSum2([3,2,4], 6);
console.log(result);