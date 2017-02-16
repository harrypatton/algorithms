#398 - Random Pick Index
source: https://leetcode.com/problems/random-pick-index/

**problem**: given an array of integers (may have duplicates), output the index of a given target. If the array has duplicate of target, it should return random index (each index has the same possibility).

## Analysis
### Brutal Force
Scan the whole array and check how many target values, and then return the random one. Time complexity O(n) but space is O(1).

O(n) is something we cannot avoid - simple scenario: every value is unique. we have to check every value.

### Hash Table
Use HashTable to save all positions for all values. Time complexity is O(1) but space is O(n). 

## Update
1. discussion page shows another solution but I think the result is the same as brutal force above.
