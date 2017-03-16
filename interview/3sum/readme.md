# 2-Sum

**Problem**: check if the sum of two elements in an array is equal to target value.

There are a few solutions for this problem,

1. **Brutal Force**
	* Iterate every element. 
	* Inside the loop, scan the rest of arrays and verify if the sum is expected. 
	* Time complexity is `1 + 2 + 3 + .. n`, so total is `O(n^2)`. Space complexity is O(1).
2. **Hash Table**
	* iterate every element and add to hash table. 
	* When added, verify if `sum - current_value` exist in hash table. 
	* Time complexity O(n), but space complexity is O(n) too.
3. **Binary Search**
	* sort the array first
	* Iterate every element
	* in each loop, use binary search to check if `any value + current value == sum`.
	* complexity: time `O(nlogn) + O(nlogn) = O(nlogn)`, space O(1)
4. **Two pointers**
	* sort the array
	* one pointer for start and the other for end.
		* if sum < target, it means the first point is not in result (because adding the largest one still less than target). so the result must be in `[start + 1, end]`, and we could repeat the process for new range.
		* if sum > target, it means the last point is not in result (because adding the smallest one still greater than target), so the result must be in `[start, end - 1]`. Repeat the process again.
	* complexity: time `O(nlogn) + O(n) = O(nlogn)`, space O(1).

# 3-Sum
**Problem**: find if the sum of 3 elements in an array is equal to a target value.

1. **Brutal Force**
	* Iterate every element in the array
	* inside loop, find `the sum of 2 elements in the rest` is equal to `sum - current_value`. It goes to 2-sum question. We need to use an array to mark the element which cannot be used anymore (tricky). 
	* **Two Pointer** is easier to understand in this case.
		* sort the array
		* scan the array from the first element
		* use two pointers to check if the rest have 2-sum solution.
		* each time just check `[current, end]`, because we already exclude all elements before current.
	* complexity: time O(n^2), space O(1).
2. **Hash Table**
	* Iterate every element in the array
	* if hash table contains `sum - current_value`, we found the result
	* otherwise, add new values `[every value before current element] + current_value`.
	* complexity: time O(n^2), space O(n).
3. **DP** - I find a lot of duplication in above solution (e.g., two pointers - keep checking the same 2 elements). We can save it in memory but is there any intuitive way?
	* use 1/0 pick, it goes back to the 2 sum and 3 sum subproblems. no DP.
	* instead of using Hash Table, use an array of length total_sum to save all possible 2-sum before current element. It is even worse than Hash Table solution.


# 4-Sum
**Problem**: find if the sum of 4 elements in an array is equal to a target value.
**Solution**: similar to 3-Sum. Sort the array and iterate. For each element, find 3 sum in the rest. Time: O(n^3).

# K-Sum
**Problem**: find if the sum of `k` elements in an array is equal to a target value.

# Subarray with given sum
source: http://blog.gainlo.co/index.php/2016/06/01/subarray-with-given-sum/

The array has only positive numbers. Find a continuous subarray which sum is the target value.

1. we can use two pointers.
2. Another way is using accumulative sum. When current accumulative sum minus the target value, check if the hash table has the value. If yes, we found it; if not, add the latest accumulative sum in hash table.

# Subarray with given sum II
source: http://www.geeksforgeeks.org/find-subarray-with-given-sum-in-array-of-integers/

in this case, the array may has nagetive numbers. The best solution would be using accumulative sum + hash table.

# Subset with given sum III
source: http://www.geeksforgeeks.org/dynamic-programming-subset-sum-problem/

in this case, the array has only positive numbers. Find a subsequence which sum is the target value. Subsequence doesn't need to be continous.

Simple DP problem. 

# Subarrary with given sum IV
source: https://en.wikipedia.org/wiki/Subset_sum_problem

In this case, the array may have positive and negative numbers. 

1. We can use DP
2. The column range is [n, p]. `n` is the total sum of all negative numbers; `p` is the total sum of all positive numbers. The row range is the subarray [0, n].
3. Finish first column and then move to next one.
4. We can only one array instead of 2d array to save the cache result; however, be careful about the edge case.
	* when current number is positive, let's calculate from bottom to top, so saving new value in the cache result will be not used by coming calculation.
	* when current number is negative, calculate from top to down.
	* we can use two arrays to alternatively save the cache but waste the memory.


#Learning
1. when code 3-sum problem, it is cleaner to merge 2-sum method in the same function. E.g., solution in [discussion page](https://leetcode.com/problems/3sum-closest/?tab=Solutions).
2. If we need to return the subset or subarray, backtracking is the best way.


# LC53 - Maximum Subarray
[Source](https://leetcode.com/problems/maximum-subarray/#/description)

*Find the contiguous subarray within an array (containing at least one number) which has the largest sum.*

Example
```
given the array [-2,1,-3,4,-1,2,1,-5,4],
the contiguous subarray [4,-1,2,1] has the largest sum = 6.
```

## Analysis
1. **Brutal Force** - there're n^2 subarrays. Each array sum is O(n) so it is O(n^2).
2. **Sliding Window** - when reach a negative element, not sure if we need to move. e.g., 2, -1, 3
3. **Accumulative Sum** - calculate current sum for elements `[0, n]` and also save the min sum among `[0, i], i is [0, n-1]`, then we calculate the max sum. Time O(n). Edge cases:
	* how to handle current element alone is the biggest one? It is the same when the sum of `[0, n-1]` is the min value.
	* how to handle the whole array has biggest sum? e.g., all positive numbers. Need to start with min value `zero`.
	* time O(n)
4. **DP**
	* base: f(0) = first element
	* f(n) means the max-sum sub-array ending with 'n'. `f(n) = max(f(n-1) + element, element)`
	* use a `max` to save biggest f(n).
	* time O(n). 

## Learning
1. DP is a better solution than Accumulative Sum when handle edge cases. I missed one scenario when write Accumulative Sum.
