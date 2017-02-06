#442 - Find All Duplicates in an Array
Source: https://leetcode.com/problems/find-all-duplicates-in-an-array/

Given an array of integers, `1 ≤ a[i] ≤ n (n = size of array)`, some elements appear `twice` and `others appear once`.

Find all the elements that appear `twice` in this array. Could you do it without extra space and in O(n) runtime?

##Idea
### Solution - hash table
1. use hash table to calculate the appearances.

### Solution - index
1. Whenever element value is positive and less than the array length, it is easy to think of `value <-> array_index` mapping. 
2. We will change value to negative value to indicate whether we see the element or not.
3. Iterate every element in the array
	* Get the element `value`. It might be negative because we saw an element which `value ==  index + 1`, so we need to choose **the abs one**.
	* Check the element value at index `value - 1`.
		* if negative, it means we saw `value` before so add it to result
		* if position, update the new element's value to be negative.
4. Because we use negative sign, it indicates only two state - seen or not seen. If the problem is updated to "three times" or more, we cannot use this way.
