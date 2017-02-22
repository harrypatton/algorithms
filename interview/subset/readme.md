## 78 - Subsets
source: https://leetcode.com/problems/subsets/?tab=Description

**Problem**: given a set of distinct integers, return all possible subsets. The solution cannot return duplicate subsets.

###Solutions
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
