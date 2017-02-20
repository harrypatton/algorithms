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

**Solution**: separate the array into 2 partitions and use hash table to save all possible 2-sum.

# K-Sum
**Problem**: find if the sum of `k` elements in an array is equal to a target value.
