#416 - Partition Equal Subset Sum
source: https://leetcode.com/problems/partition-equal-subset-sum/

Given a non-empty array containing only positive integers, find if the array can be partitioned into two subsets such that the sum of elements in both subsets is equal.

Example
```
Input: [1, 5, 11, 5]
Output: true
Explanation: The array can be partitioned as [1, 5, 5] and [11].
```

# Analysis
This is an interesting problem. I don't have an intuitive solution coming up in mind. 

1. The problem could be find subsets which sum is equal to specific sum (e.g, half of total sum). Subset doesn't need to be continuous.
2. We can uses a hash set to store what sum we have encounter. When iterate each element, let's check it and also update the hash set.
	* this is tricky - when update the hash set, I have to use a second hash set to avoid both adding and updating elements.
	* when init the hashset, add value 0.
3. time complexity O(n^2). space complexity: O(n^2)

## Update
The above solution works fine but of course it is not optimal per discussion page. It is actually a DP problem or `0/1 knapsack` (an element is selected or not).

1. `result[i][j]`: it means, given an array of `0..j`, whether it can find a subset which sum is equal to `i`.
2. when calculate `result[i][j]`, there're two options - include j or not.
	* when include j, the result is whether a subset of `0..j-1` which sum is equal to `i - array[j]`, i.e., `result[i][j] = result[i-array[j]][j-1]`
		* when not include j, the result is whether a subset of `0..j-1` which sum is equal to i. `result[i][j] = result[i][j-1]`
		* when either is true, `result[i][j] = true`
3. to start, `result[0][0] = true`.
4. We can set a 2D matrix to save the state. Each cell depends on its left value and one above cell on left column. It means,
	* we need one array to save values for left column. 
	* We also need another array to save values for current column. (we cannot reuse previous one because it may conflict with current values)
5. Top to down and then left to right.

## Learning
1. After checking discussion page, I found that we can use only one array instead of two in my solution. The key is, check from sum to 0, because we'll update current element and it will never be used in the rest of iteration.
