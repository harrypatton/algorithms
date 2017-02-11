#421 Maximum XOR of Two Numbers in an Array
source: https://leetcode.com/problems/maximum-xor-of-two-numbers-in-an-array/

**Problem**: Given a non-empty array of numbers, a0, a1, a2, … , an-1, where 0 ≤ ai < 2^31. Find the maximum result of ai XOR aj, where 0 ≤ i, j < n. (Could you do this in O(n) runtime?)

Example 1
```
Input: [3, 10, 5, 25, 2, 8]
Output: 28
Explanation: The maximum result is 5 ^ 25 = 28.
```

xor means, return true if both are different; return false; when both are the same.

# Analysis
1. It is easy to use brutal force to calculate the result. Time complexity is O(n^2).
2. To get O(n) time, there must be some tricky thing.
	* two min values get the max XOR?
	* max and min value get the max XOR?

**Unfortunately** I cannot find a good solution within 10 minutes.

# Update
The discussion page has a great solution. It took me a while to understand why it works. The tricky thing is,

1. Find most significant bit (i.e., the most left) bit first.
2. If A^B == C, then A^C == B and B^C == A.
