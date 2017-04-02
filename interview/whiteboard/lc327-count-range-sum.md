[Source](https://leetcode.com/problems/count-of-range-sum/#/description)

Given an integer array nums, return the number of range sums that lie in [lower, upper] inclusive.
Range sum S(i, j) is defined as the sum of the elements in nums between indices i and j (i ≤ j), inclusive.

Note:
A naive algorithm of O(n^2) is trivial. You MUST do better than that.

Example:
```
Given nums = [-2, 5, -1], lower = -2, upper = 2,
Return 3.
The three ranges are : [0, 0], [2, 2], [0, 2] and their respective sums are: -2, -1, 2.
```
# Analysis
I cannot figure out a better way than O(n^2) solution. The solution is, adding all sums in one iteration and then calculate the difference
between 2 sums.

[Solution](https://discuss.leetcode.com/topic/33738/share-my-solution) on discussion page reuse the same algorithm used to calculate LC315(count of smaller numbers after self).
