#441 - Arrange Coins
source: https://leetcode.com/problems/arranging-coins/

You have a total of `n` coins that you want to form in a staircase shape, where `every k-th row must have exactly k coins`.

Given n, find the total number of full staircase rows that can be formed. n is a non-negative integer and fits within the range of a 32-bit signed integer.

## Solutions
### Solution - brutal force
1. the total coins of the staircase would be `1 + 2 + ... + m`. We need to find the maximum `m` so that the total would be `<= n`.
2. use a loop to keep adding the value; when do we exit?
	* sum > n, so find the max m.
	* sum < 0, it means overflow so we find max m too. (**this is very important edge case to consider**)

time complexity: O(n).

### Solution - Squart value
We can use math to detect that ` Sqrt(n*2) - 2 < m < Sqrt(n*2)`. The problem is, `n*2` could overflow so that we cannot get a good result.

1. Discussion page shows one solution is to use `long` type to store `n*2`.
2. Is there any better way to reduce the scope `n`? In previous solution, we just try 1 until the result so it is O(n). 
	* Double checking the formula again, we can get `sqrt(2) * sqrt(n) - 2 < m < sqrt(2) * sqrt(n)`, so we find both lower and upper bound.
	* Use lower bounds as the baseline. We cannot just use `m*(m+1) /2` because it may overflow so we need to divide by 2 first (the order is based on even or odd).
