#474 - Ones and Zeroes
Source: https://leetcode.com/problems/ones-and-zeroes/

**Problem**:There are ``m`` 0s and ``n`` 1s respectively. On the other hand, there is an array with strings consisting of only 0s and 1s.

Now your task is to find the maximum number of strings that you can form with given m 0s and n 1s. Each 0 and 1 can be used at most once.

Note:
The given numbers of 0s and 1s will both not exceed 100
The size of given string array won't exceed 600.

Example 1:
```
Input: Array = {"10", "0001", "111001", "1", "0"}, m = 5, n = 3
Output: 4

Explanation: This are totally 4 strings can be formed by the using of 5 0s and 3 1s, which are “10,”0001”,”1”,”0”
```

Example 2:
```
Input: Array = {"10", "0", "1"}, m = 1, n = 1
Output: 2

Explanation: You could form "10", but then you'd have nothing left. Better form "0" and "1".
```

##Ideas
Anything about max size/count/sum is probably solved by DP. In this case,

* Lets take the last element in the array. It could be in the final max array or not.
	* When it is in max array,  ``f(array[0..n-1], m, n) = 1 + f(array[0..n-2], (m-m_in_arrary_element), (n - n_in_array_element)``. I.e., it should be 1 plus the max count of length in 0..n-2 array with less 0s and 1s (the total m and n minus the one is that element). 
	* When it is not in max array, ``f(array[0..n-1], m, n) = f(array[0..n-2], m, n)``.
	* The final result is Max(result1, result2).

It becomes subproblems and there're overlap subproblems so we can use DP.

we can use bottom-up manager to calculate,
* row represents a complex type [i, j]. The row index is i * n + j.  i in [0, m-1], j in [0, n-1].
* column is the string array.

When calculate cell [m, n], it needs a result all cells on the left next column. Space is O(1 + row_count) = O(m*n). 

when index < 0. the cell value is 0. the scan is from up to down and then left to right. 

``time complexity is O(m * n * arry_size) and space is O(m*n).``


#Learning
1. It is still very easy to get messed up with edge cases, especially if we need to add a dummy column or row. In this case, because we can have zero `0` or `1`, so we need to create a (m+1) * (n+1) array. The first one is the dummy one (which means there is no `0` or `1`). 
2. for some reason, I keep using the same array to update the result. It is wrong because the result will be updated with current iteration. What I need is result from previous iteration.
3. It took me 20 minutes (with distraction) to fix the edge cases.
