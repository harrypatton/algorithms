#Source
https://leetcode.com/problems/target-sum/

#Question
You are given a list of non-negative integers, a1, a2, ..., an, and a target, S. Now you have 2 symbols ``+`` and ``-``. For each integer, you should choose one from + and - as its new symbol.

Find out how many ways to assign symbols to make sum of integers equal to target S.

#Clarification
* symbol appears in the front of integer
* each integer has only one symbol
* all of them are ``non-negative`` integers.
* list length >= 0 and <= 200
* sum of all elements <= 1000
* answer fits in 32-bit integer

#Idea
## solution - brutal force
Each position has two choices (the symbols). We can calculate the sum for all combinations and check the result.

Time complexity: O(n^2).

Recursion is easy to implement this solution.

f(n) = f(n-1, S - list[n]) + f(n-1, S+list[n]).

## solution - DP #1
1. For this array, we use a map. The key is sum and the value is the ways of reaching that sum.
2. Assume we have the map for an array [0.., n-1]. When give an element list[n], 
	* every sum in existing dictionary can have two new sums: add or minus the element. The value (i.e., ways of reaching the sum) should be the same. It doesn't add new more ways to reaching the sum.
	* can we reuse the map? It will be tricky because a new sum might be the same as previous sum (with one fewer element). It is probably the same as a new sum using plus. It becomes hard to update the value. I'll use a new dictionary for every iteration. (not perfect though)
3. Return the value from given key with target S.

Complexity
* time: O(count_of_sum * n)
* space: O(count_of_sum). 2 times of count_of_sum is the exact number because we can add minus symbol.

## solution - DP #2
This one is better than previous one - better time and space complexity. I learned from Leetcode.

Assume the sum of positive numbers is S(p), the sum of negative numbers is -S(n).

	=>    S = S(p) - S(n)
	=>    S + 2S(n) = S(p) - S(n) + 2S(n)
	=>    S + 2S(n) = S(p) + S(n)
	=>    S + 2S(n) = Total_Sum
	=>    S(n) = (Total_Sum - S) / 2

The problem becomes ``find a subset of an array which sum is equal to xxx``.  Subset is **not** continuous sub-array.

Edge cases
* S == Total_Sum, it means we are looking for a sum of zero. What does that mean?

Here're the steps,

1. calculate (total_sum - s ) / 2, called it ``target``. Please note, the numerator must be an even number; otherwise cannot find an answer.
2. init an array of length ``target + 1`` with 0 value. Call this array ``sumList``.
	* set first element to be 1, because when target is 0, we can select 0 element as an sub-array.
3. for each element num in the element array,
	* Iteration sumList in descending order when i >= num.
	* update sumList[i] += sumList[ i - num]. This covers the scenario that using the element alone to get a sum.
4. Return the last element of ``sumList``.

Complexity
* time: O(n * target)
* space: O(n * target)

#Learning
Code is accepted after a few minor fixes.

1. The DP idea is correct but I doubted it when thought about the time complexity (I thought it is still the same as brutal force).
2. Failed to handle edge case ``twice`` when first element is zero (which means it has the same sum key with + or -). 
3. I didn't think of DP #2 solution until read the answer from LeetCode. Very smart thought. 
4. I'm so frustrated about DP #2 solution. 
	* So many corner cases. I cannot think through it.
	* In the nested loop, I need to use descending iteration instead of the other way which keeps interfering later operations. Need to be careful.
