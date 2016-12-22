The original problem could be found in the following places,
* http://algorithms.tutorialhorizon.com/dynamic-programming-coin-change-problem/
* http://www.geeksforgeeks.org/dynamic-programming-set-7-coin-change/

#Overview
##Object
Given a set of coins and amount, write an algorithm to find out how many ways we can make the change of the amount using the coins given.

##Constraints
1. we have infinite supply of each coin which value is S1, S2 ... Sm.
2. The coin order doesn't matter, so don't include duplicate results.

#Ideas
##Brutal force
Say the amount is n. The max count of coins is n (or better: n/min(values) + 1). 

###Base
1. if collection has one coin, it is easy to calculate.
2. if min coin value of collection is greater than amount, there is no match.

(**Please note** that the following solution is not perfect. Use the one from geeksforgeeks.org.)
To avoid duplicate count, it starts with first coin. If we repeat the process for each coin, we'll recalculate the same result.
```
// take first coin say coin_foo, the result may contain zero foo, one foo, two foos, up to max_count foos.

// handle zero foo
recursive_call(amount, coin_collections_except_coin);

// handle 1, 2, ..., max_count foos.
for(int i = 1; i <= max_coin_count; i ++)
{
  int remainingAmount = amount - coin_foo * i;
  recursive_call(remainingAmount, coin_collections_except_coin);
}
```

It is hard to measure the time/space complexity of this algorithm.

**Please note** that the brutal force one on [geeksforgeeks](http://www.geeksforgeeks.org/dynamic-programming-set-7-coin-change/) is much better than mine - it divides solutions into 2 buckets (instead of multiple ones like mine). It is easy to understand and converted to DP solution.

> To count total number solutions, we can divide all set solutions in two sets.
> 1. Solutions that do not contain mth coin (or Sm).
> 2. Solutions that contain at least one Sm.
> Let count(S[], m, n) be the function to count the number of solutions, then it can be written as sum of count(S[], m-1, n) and count(S[], m, n-Sm).

##Dynamic Programming
Apparently brute force one shows an optimal substructure and overlapping subproblems. It is a good candidate for DP.

###Observation
1. The solution is the sum of using m-1 coins for n value and using m coins for (n-value_mcoin) value.
2. We can use 2-dimensional array to solve the problem. 
  * the row is 1 to n (amount)
  * the column is each coin. 
  * the cell value means how many ways to reach to current amount (row) using coin 1 to current coin.
  * if no way to reach the value, just put zero.
  
Rule: s[i][j] = s[i][j-1] + s[i - value_j][j]

#Learning
1. It is important to get the correct recursive method first. After that, it is easy to use DP with 2d array.
2. Recursion - ideally the solution can divided into 1 or 2 subsolutions. If more than 2, it becomes harder to use DP. (in that case, probably 3d array)
