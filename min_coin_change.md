#Original
* http://algorithms.tutorialhorizon.com/dynamic-programming-minimum-coin-change-problem/
* http://www.geeksforgeeks.org/find-minimum-number-of-coins-that-make-a-change/

#Overview
**Objective**: given an amount 'A' and n coins. Write a program to find out minimum numbers of coins required to make the change for the amount.

Example
```
Amount: 5
Coins [] = 1, 2, 3.

No of ways to make the change are : { 1,1,1,1,1} , {1,1,1,2}, {2,2,1},{1,1,3} and {3,2}.
So as we can see minimum number of coins required are 2 (3+2=5).
```

#Ideas
## Recursion
1. f(n) = 1 + min(f(n - i)), i is each element from collection Coins.

## DP
1. Initialize an array of int to int.max
2. Base: f(0) = 0. If (n - i) < 0, the f(n-i) = int.max.

Time complexity: O(m * n). m is the amount, n is the different coin count.
Space complexity: O(m). just an array.

#Learning
N/A
