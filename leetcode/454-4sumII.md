#454 - 4Sum II

Given four lists A, B, C, D of integer values, compute how many tuples (i, j, k, l) there are such that `A[i] + B[j] + C[k] + D[l]` is zero.

To make problem a bit easier, all A, B, C, D have same length of N where 0 ≤ N ≤ 500. 

##Idea
### Hash table
1. For list A and B, calculate the sum of every pair and store the data in a dictionary.  The key is the sum and value is the ways to reach that sum. Time complexity is O(n^2).
2. We create another dictionary for list C and D.
3. Iterate every `key` on first dictionary, and verify if any `-key` exist in the second dictionary. count += dict1[key] * dict2[-key]. Worst case is O(n^2).

Complexity

* time: O(n^2)
* space: O(n^2) - the worse case is there're n^2 different sum values.

#Learning
1. [discussion page](https://discuss.leetcode.com/topic/67593/clean-java-solution-o-n-2) uses the same idea but with only one hash table. We don't need the second one because when iterate list C and D, we can use the first hash table to check if they are the tuple. It is the same time complexity but save one hash table. `Cool!`
