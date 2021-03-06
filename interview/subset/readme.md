## 78 - Subsets
source: https://leetcode.com/problems/subsets/?tab=Description

**Problem**: given a set of distinct integers, return all possible subsets. The solution cannot return duplicate subsets.

### Solutions
* **Recursion** - get all subsets based on `[1, n]`, and then extend the subsets by adding another subset (add `[0]` to every subset).
	* empty subset is part of the answer.
	* recursion exit: empty subset. **Learning**: the condition is still tricky and hard to understand.

*  **Iteration**
	* when iterate on first element, the result is `[], [0]`.
	* move to next element `[1]`, we keep the result and then add other results by adding `[1]` to every subset. It becomes `[], [0], [1], [0, 1]`
	* for element `[2]`, the result is `[], [0], [1], [0, 1], [2], [0,2], [1,2], [0, 1,2]`
* **Backtracking**:  `looking for a solution with better explanation.` This is a good link: http://math.stackexchange.com/questions/1689197/using-backtracking-algorithm-to-determine-all-the-subsets-of-integers
* **Bitmap**: use bitmap to indicate if the number is selected or not.

## 90 - Subsets II
source: https://leetcode.com/problems/subsets-ii/?tab=Description

Given a collection of integers that might contain **duplicates**, `nums`, return all possible subsets. The solution set must not contain duplicate subsets.

### Solutions
1. sort the collections so we can handle duplicate numbers efficiently.
2. **Solution - Backtracking** - when pick up next element, we need to consider duplicate ones.
	* it is a special case. Assume [k, k, k, k1, k2, k3 ...]. After calculate the result for [k1, k2, k3], we just add one k to each subset, 2Ks to each subset, and then 3Ks to each subset.
3. **Iterative** - sort the algorithm first. And then the same idea as backtracking solution - when iterate over the element, calculate how many duplicates they have, and then add one k to each subset, 2Ks to each subset, ..., until all duplicates. (I wrote the code at once. good.)

## 40 - Combination Sum II
source: https://leetcode.com/problems/combination-sum-ii/?tab=Description

**Problem**: given a collection of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.

1. Each number in C may only be used `once` in the combination.
2. All numbers (including target) will be positive integers.
3. The solution set must not contain duplicate combinations.

### Solutions
1. **DP**: it is easy to calculate if any combination has the sum, but a little tricky to get the result. I'll revisit this part.
2. **Backtracking**: the most straightforward solution for me. Just be careful about two things
	* when sum is greater than target, we should break the path (otherwise timeout).
	* for duplicate numbers, just calculate the first one and skip others.

## 216 - Combination Sum III
source: https://leetcode.com/problems/combination-sum-iii/?tab=Description

Find all possible combinations of `k` numbers that add up to a number `n`, given that `only numbers from 1 to 9` can be used and each combination should be `a unique set of numbers`.

**note**: each number can be used at most once.

### Solutions
1. **Backtracking**
	* add first one element to the path and then check the remaining for other numbers.
	* when numbers exceed `k` or target exceeds, break current path.
	* Update - I wrote the code and passed in a short time.

## 377 - Combination Sum IV
source: https://leetcode.com/problems/combination-sum-iv/?tab=Description

Given an integer array with all positive numbers and no duplicates, find the number of possible combinations that add up to a positive integer target.

* a number can picked up multiple times.
* order matters. [1, 2], [2, 1] are different combinations.

The problem just needs a count instead of all of the combinations.

### Solutions
DP is good for aggregated result or one of results; backtracking is good to get all results. In this case, we just need to get the count, so we can try DP.

1. f(n-1, sum) is the result. Now consider new element, the total is `f(n-1, sum) + f(n-1, sum-current_value)`. Unfortunately this one doesn't count for different sequences.

**Update** - here're the solutions after reading discussion page,

1. **recursion** - the last element in each combination could be any of the element, so `result(target) = result (target - e1) + result(target - e2) + result(target - e3)`.
	* base: result(0) = 1. it means there is only one way to get target 0.
2. **DP** - it is based on recursion solution. We use 2d matrix. Row: [1, target], Column: numbers; column means the number of combinations ending with that number which has the sum of value in Row.
	* init: `cache[num[i], i] = 1`
	* for each row target and number i, `cache[target, i] = cache[target - nums[i], 0] + cache[target - nums[i], 1] + cache[target - nums[i], 2] ... `.
	* **Update**, we can use a single array to do the work, cache[1..target]. 
		* init: for each number, `cache[0] = 1`, so when number is equal to target, it returns 1.
		* Go through the cache. `cache[target] += cache[target - nums[0]] + cache[target - nums[1]] + cache[target - nums[2]] + ...`. 

# LC - Maximum Size Subarray Sum Equals k
Problem: *given an array, get the max size sub-arrays which sum is equal to k.* Sub-array is continuous array. ([Source](https://discuss.leetcode.com/category/405/maximum-size-subarray-sum-equals-k))

## Analysis
1. **Brutal force**: check n^2 subarrays. Each check is O(n) so total is O(n^3).
2. **Sliding Window**: it may contain negative number, so this approach doesn't work.
3. **DP**: what's the sub-problem formula? Say nth element is the last one in max-size sub-array, we need to find previous max array which sum is equal to `k-element[n]`.  We can do that with a range `[totalNegativeSum, totalPositiveSum]` with `n` elements. 
4. **iterative accumulative sum**: all sum of sub-arrays could try this approach. 
	* Use a dictionary or hash table to store sum -> index mapping. Sum is for `[0, current_index]`.
	* When reach to next element, we can check if hash table has a key equal to `k-element[n]`, if yes, we found a sub-array starting from the index in hash table to current element; however, add to hash table.
	* When two different indexes have the same sum, we always choose the smaller index because it enables bigger subarray length, i.e., if hash table has the key, do nothing.

signature
```
public int GetMaxSizeOfSubArray(int[] array, int k)
```

## Learning
1. I need more practice on mind debugging:). There's a major code bug in my original code. It shouldn't have happened.
