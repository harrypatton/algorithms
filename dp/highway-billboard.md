#Original
* http://algorithms.tutorialhorizon.com/dynamic-programming-highway-billboard-problem/

#Overview
**Objective**: check the original post. It needs to find out max revenue aligning with the regulation (> 5 miles) and potential billboard positions.

Examples
```
int[] x = {6, 7, 12, 13, 14};
int[] revenue = {5, 6, 5, 3, 1};
int distance = 20;
int milesRestriction = 5;

Output: Maximum revenue can be generated :10 (x1 and x3 billboard will be placed)
```

#Ideas
## Brutal force
1. Find all sub arrays. It is more like all substrings. 
2. Remove sub arrays which break the regulation.
2. Calculate sum and find the max one.

time complexity is O(n*2^n).

## Recursion
1. f(1) = revenue[1].
2. f(n) means max revenue ending with position n. Assume position m is just before position n that is more than 5 miles away from position n.
f(n) = f(m) + revenue[n]. if m <=0, f(m) = 0.
3. After calculate all positions, find the max one.

## DP
See recursion.

### Complexity
* Time: O(n * miles_in_regulation).
* Space: O(n)

n is the count of potential positions.

#Learning
Original post has a different resolution. It starts with mile,
f(n) means the max revenue for this length. 

1. If there is no billboard for nth mile, f(n) = f(n-1).
2. Otherwise, f(n) = f(n - 6) + revenue[n].

* time complexity: O(mile) => it is close to my solution, i.e., potential count * mile in regulation. Mine is faster if positions are sparse.
* space complexity: O(mile) => it is more than my solution.

Compared with my solution, it consumes more spaces but the logic is simpler.
