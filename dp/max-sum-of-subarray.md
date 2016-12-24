#Original
* http://algorithms.tutorialhorizon.com/dynamic-programming-maximum-subarray-problem/

#Overview
**Objective**: find the contiguous sub-array within an one-dimensional array of numbers, which has the largest sum.

Example
```
int [] A = {−2, 1, −3, 4, −1, 2, 1, −5, 4};

Output: contiguous sub-array with the largest sum is 4, −1, 2, 1, with sum 6.

```

#Ideas
## Brutal force
1. Find all sub arrays. It is more like all substrings. 
2. Calculate sum and find the max.

time complexity is O(n*2^n).

## Recursion
Assume f(n) means max sum of sub-array which ends with element n.

1. if f(n-1) > 0, f(n) = value[n] + f(n-1);
2. otherwise f(n) = value[n]

After calculate f(1) to f(n), we just find the max value.

## DP
Use recursion method to calculate for every element. Once find the max value, iteration from that position to find one.

1. add current element to result list
2. If f(n) == value[n], stop, we're done.
2. Otherwise, move toward first position and find f(m) == f(n) - value[n]. If found, go back to #1; otherwise there is a bug.

### Complexity
* Time: O(n)
* Space: O(n)

#Learning
