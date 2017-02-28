# LC300 - Longest Increasing sub-arrays
## Source
* https://leetcode.com/problems/longest-increasing-subsequence/?tab=Description
* http://blog.gainlo.co/index.php/2017/02/02/uber-interview-questions-longest-increasing-subarray/

Given an array, return the length of the longest increasing sub-array. For example, if the input is [1, 3, 2, 3, 4, 8, 7, 9], the output should be 5 because the longest increasing array is [1, 2, 3, 4, 8].

note: sub-array doesn't require numbers to be continuous.

## Analysis
1. **Brutal Force** - check all sub-arrays. Each element could be in the sub-array or not so total is 2^length.
2. **DP** - need to find out sub-problems. 
	* the `LIS` ending in current element: how to calculate this one? We need to scan all previous results (which element <= current element) and pick the longest one. O(n).
	* the `LIS` not ending in current element - it is from previous result.
	* the result means the `LIS` ending with current element.
	* complexity: time O(n^2), space O(n).
	* keep tracking the max during the process.
