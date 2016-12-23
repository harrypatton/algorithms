#Original
* http://algorithms.tutorialhorizon.com/dynamic-programming-minimum-numbers-are-required-whose-square-sum-is-equal-to-a-given-number/
* http://www.geeksforgeeks.org/minimum-number-of-squares-whose-sum-equals-to-given-number-n/

#Overview
**Objective**: Given a number, Write an algorithm to find out minimum numbers required whose square's sum is equal to the number.

Example
```
Given Number: 12

Numbers whose sum of squares are equal to 12.

1^2+1^2+1^2+1^2+1^2+1^2+1^2+1^2+1^2+1^2+1^2+1^2 = 12

2^2+2^2+2^2 = 12

3^2+1^2+1^2+1^2 = 12

Answer: 3 numbers (2,2,2)
```
#Ideas
## Brutal force
1. find the biggest single number which square is very close the number. Repeat the process for the rest of number; however, I'm not sure if it comes with minimum number.
2. Another way, 
	* Check if one number's square is equal to the value, if yes, we're done.
	* If not, we can calculate the result for 2 numbers which sum is equal to the value. There are many combinations of the two numbers, so we need to find the minimum number finally. Please note that there are a lot of overlapping subproblems that we can store in memory.

## DP
1. Base - start with 1. f(1) = 1.
2. Base shortcut - if a single number's square is equal to the value, we just fill in 1.
3. Iteration - given a number n, it becomes a combination of (1, n-1), (2, n-2), (n/2, n/2) (handling edge here), calculate the result from all combinations and find the minimum one. Because we start from small number, so it is doable. 

Time complexity: each number calculation is n/2. we have n number to check so it is O(n^2).
Space complexity: O(n). just an array.

**Note**: the one in original post shows a better solution. Check Learning part.

#Learning
1. The DP is not optimal one because of the two part combination. Actually the original post from geeksforgeeks shows a better solution with O(n*sqrt(n)). We don't have to try every single combination. We know the element must come from 1 .. sqrt(n). The value should be the minimum one in 1 + func(value - i*i), 1 <= i <= sqrt(n).
