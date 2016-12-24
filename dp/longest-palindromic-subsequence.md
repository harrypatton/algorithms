#Original
* http://algorithms.tutorialhorizon.com/longest-palindromic-subsequence/
* http://www.geeksforgeeks.org/dynamic-programming-set-12-longest-palindromic-subsequence/

#Overview
**Objective**: given a string, find a longest palindromic subsequence in it.

**What is Longest Palindromic Subsequence**: it is a sequence that appears in the same relative order, but not necessarily contiguous(not sub­string) and palindrome in nature( means the subsequence will read same from the front and back.

Example
```
String A = " AABCDEBAZ";

Longest Palindromic subsequence: ABCBA or ABDBA or ABEBA

```

#Ideas
## Brutal force
1. find all subsequences, check if it is a palindromic, and get the longest one. time complexity is O(n * 2 ^n). 

## Recursion
1. if f(0) == f(n-1), the value = 2 + f(1, n - 2);
2. otherwise, value = max(f(0, n -2), f(1, n -1)). Two possibilities - the longest palindromic includes the char or not.

## DP
f[i][j] means the substring from position i to j. 
1. if value[i] == value[j], f[i][j] = 2 + f[i+1][j-1].
2. Otherwise, it is max of (f[i+1][j], f[i][j-1])

it is bottom up manner. Please note that in 2D matrix, it fills in as diagonal direction from left-bottom to upper-right corner.

### Complexity
* Time: O(n^2)
* Space: O(n^2). Probably O(n), because we just use the diagonal line.

#Learning
1. Finding recursion solution is the key.
