#Origin
* http://algorithms.tutorialhorizon.com/find-the-first-repeated-element-in-an-array-by-its-index/
* http://www.geeksforgeeks.org/find-first-repeating-element-array-integers/

#Overview
**Objective**: 
Given an array of integers, find out the first repeated element. First repeated element means the element occurs at least twice and has smallest index.

#Ideas
##Naive solution - brute force
1. sort the array
2. scan the array to find first duplicate.

time complexity: O(nlogn). 
space: O(1).

**Note**, ``this is wrong because it needs the smallest index.``

The correct way is to do 2 loops. O(n^2).

##Solution - sort
1. sort the array in a copy
2. scan the original array. pick one element and find if it repeats in the copied and sorted array.

time complexity: O(nlogn)

##solution - hash table
Use hash table to find all duplicate elements. Whenever find a duplicate, return the result.

time complexity: O(n). 
space: O(n) - hash table cost.

**Note**, ``this is wrong because it doesn't guarantee the smallest index.`` E.g., "1, 2, 2, 1". The first one should be 1.

the correct way is to scan from ``right`` to ``left``. In that case, the last duplicate element must be the first repeat element.

##solution - better one?


#Learning
