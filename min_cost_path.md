#Original
* http://algorithms.tutorialhorizon.com/dynamic-programming-minimum-cost-path-problem/
* http://www.geeksforgeeks.org/dynamic-programming-set-6-min-cost-path/

#Overview
**Objective**: given a 2d matrix where each cell has a cost to travel. Write an algorithm to find a path from left-top corner to bottom-right corner with minimum travel cost. You can move only right or down.

#Ideas
## Brutal force
1. Calculate all paths using recursion and get the min value.
2. f[m][n] = value[m][n] + min(f[m-1][n], f[m][n-1]);

## DP
1. calculate from left to right and then top to down. 
2. main an array to store previous row result.
3. f[m][n] = value[m][n] + min(f[m-1][n], f[m][n-1]);

Time complexity: O(m * n)
Space complexity: O(m). just an array.

#Learning
N/A
