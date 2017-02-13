#413 - Arithmetic Slices
source: https://leetcode.com/problems/arithmetic-slices/

A sequence of number is called `arithmetic` if,

1. It has at least 3 numbers.
2. The difference between 2 consecutive numbers is the same.

**Problem**: given an array, calculate how many arithmetic sequences.

## Analysis
### Brutal Force
1. Get all sequences that has at least 3 elements. time complexity O(Cn3).
2. For each sequence, check if it is arithmetic. Each is O(n).

### Sliding Window
1. Once we found arithmetic, what's next?
	* if next element could be part of arithmetic, increase current arithmetic.
	* if not, use `current + next` to find next arithmetic.
2. Assume the max arithmetic length is `n`, the total count is 
	`n-2 + n - 3 + n -4 + ...+1`
=>  `1 + 2 + 3 + ... + n - n - (n-1)` 
=> `n * (n+1) / 2 - n - (n -1)`
3. There's a start pointer for current arithmetic and also the difference value.

## Cool Thing
It is the first time that the code passes without any single change. Yeah!
