##Original
1. http://algorithms.tutorialhorizon.com/dynamic-programming-longest-common-substring/
2. http://www.geeksforgeeks.org/longest-common-substring/

##Overview
**Objective**: Given two string sequences write an algorithm to find the length of longest substring present in both of them.

This is the substring instead of subsequence.

##Ideas

###Brutal force
1. Given a string, we can find all substrings. O(n) = n + n - 1 + ...1 = o(n^2).
  * we can start with first letter and then include latter letter each time. Recursion is easy to understand the solution: abcd => a + f(bcd)
  * We can start the whole string. In each iteration, remove one letter to get a new substring. It is easy to do recursion.
2. Once get the substring, it is easy to check if it is a substring of another one. O(m * n). (if use KMP, it is O(m+n)).

###Recursion
I cannot find a good recursion solution for this problem, so I had to check the original post. What I tried is,
1. Func(Sm-1, Sn-1): it doesn't work when calculate the result for Func(Sm, Sn);

**Update**: it is so easy to solve after reading the DP solution. It is not obvious to find recursive solution then. This is why I got stuck.

###DP
Use tabular matrix to calculate the result. The cell value means the longest common substring starting from the first char and ending with current char.

1. If Sm[i] == Sn[j], the value is result[i][j] + 1 + result[i-1][j-1].
2. Otherwise, the value is zero.
3. After calculation is done, rescan the matrix to get max value.

Both time and space complexity is O(m * n).

###How to get the substring
Given the cell with max cell, back track the diagonal cell until the value is zero.

##Learning
1. Sometimes it is easy to start with DP directly. Recursion => DP is not always obvious.
2. In DP, it is important to understand the meaning of cell value (i.e., the meaning of subtask.)

##Note
Update #1: geeksforgeeks shows a suffix-tree solution better than DP. Its time complexity is O(m+n). (Awesome).
