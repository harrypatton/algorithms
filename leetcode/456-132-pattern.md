#456 - 132 Pattern
source: https://leetcode.com/problems/132-pattern/

Given a sequence of n integers a1, a2, ..., an, a `132 pattern` is a subsequence ai, aj, ak such that i < j < k and ai < ak < aj. Design an algorithm that takes a list of n numbers as input and checks whether there is a `132 pattern` in the list.

##Solution - brutal force
1. Iterate over each num
2. Pick up the `min` one from all elements on the `left` that are less than the num.
3. Pick up the `max` one from all elements on the `right` that are less than the num.
4. if `max` > `min`, we find one; otherwise go to next element.

**Time Complexity**: O(n^2).

#Pending
I didn't finish this problem.
