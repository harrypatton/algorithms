#396 - Rotate Function

source: https://leetcode.com/problems/rotate-function/

It is a little hard to understand the problem until read examples.

## Analysis
1. We can do brutal force to calculate every pivot position (total n). Every pivot takes O(n) to get the result, so the time complexity is O(n^2). 
2. Optimal solution based on brutal force,
	* the continuous pivot position: f(m-1) and f(m) has a slightly difference. It should be easy to get f(m) result from f(m-1).
	* After a long math equation, here's what I get, `f(m-1) = f(m) + total_sum - n *array[m-1]`. 
	* we need to calculate total sum of array.
	* we need to calculate the result when there's no pivot (i.e., the pivot number is in first place:).

how about overflow? `n` is less than `10^5`, but we don't know the element range in the array. We can use `long`; however, the result returns `int` so I assume it wouldn't overflow.

**I wrote down the code and passed the tests (I did update the code a few times because of edge scenarios and my carelessness). Need to do better.**

My solution is the same as discussion page. cool.
