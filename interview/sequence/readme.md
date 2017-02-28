# LC300 - Longest Increasing sub-sequence
## Source
* https://leetcode.com/problems/longest-increasing-subsequence/?tab=Description
* http://blog.gainlo.co/index.php/2017/02/02/uber-interview-questions-longest-increasing-subarray/

Given an array, return the length of the longest increasing sub-sequence. For example, if the input is [1, 3, 2, 3, 4, 8, 7, 9], the output should be 6 because the longest increasing array is [1, 2, 3, 4, 8, 9].

**Notes**: sub-sequence doesn't require numbers to be continuous.

## Analysis
1. **Brutal Force** - check all sub-sequence. Each element has two choices (in or out), so total is 2^length.
2. **DP** - need to find out sub-problems. 
	* the `LIS` ending in current element: how to calculate this one? We need to scan all previous results (which element < current element) and pick the longest one. O(n).
	* the `LIS` not ending in current element - it is from previous result.
	* the result means the `LIS` ending with current element.
	* complexity: time O(n^2), space O(n).
	* keep tracking the max during the process.
3. LC asks if any solution with time O(nlogn). Unfortunately I cannot figure out the way. 
	* **Update**: it still uses binary search but in a creative way. See [this link](https://discuss.leetcode.com/topic/28738/java-python-binary-search-o-nlogn-time-with-explanation) for more details.

## Extend
1. if the problem is about sub-array which requires continuous element, it becomes easier. **Moving Window**: find max length of current increasing sub-array. After that, move to next (i.e., start = end + 1).
