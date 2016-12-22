##Original
1. http://algorithms.tutorialhorizon.com/dynamic-programming-longest-common-substring/

**Update**: 
When I completed this post, I realized I implemented longest common subsequence instead of substring. I'll update the file name.
the original post is at http://algorithms.tutorialhorizon.com/dynamic-programming-longest-common-subsequence/

##Overview
**Objective**: Given two string sequences write an algorithm to find the length of longest ~~substring~~ subsequence present in both of them.

##Ideas

###Brutal force
1. Given a string, we can find all substrings. O(n) = n + n - 1 + ...1 = o(n^2).
  * we can start with first letter and then include latter letter each time. Recursion is easy to understand the solution: abcd => a + f(bcd)
  * We can start the whole string. In each iteration, remove one letter to get a new substring. It is easy to do recursion.
2. Once get the substring, it is easy to check if it is a substring of another one. O(m * n). (if use KMP, it is O(m+n)).

###Recursion
Two strings Sm and Sn. We have function LCS(str1, str2) = longest common sub string in both str1 and str2.
1. Remove one string from the end of each string, we have LCS(Sm-1, Sn-1). 
2. To calculate LCS(Sm, Sn),
  * if S[m] == S[n], result = LCS(Sm-1, Sn-1) + 1
  * else, we choose the max value of LCS(Sm-1, Sn) and LCS(Sm, Sn-1).

###DP
It is clear to see this problem can be solved using DP base don Recursion above. A tabular bottom up solution can do the work.

1. Column represents each char in Sm.
2. Row represents each char in Sn.

The time complexity is O(m * n). The space complexity is O(m * n). Because it always use current and previous row, the space complexity could be O(min(m, n)).

###How to get the substring
The matrix at bottom-right cell shows the max length of LCS. How to get the string then?

1. During calculation, if two chars match, we just record it.
2. As an alternative, we can backtrace.
	* if current value == diagonal value + 1, it is the value and move to that cell.
	* otherwise go to either left or up cell with the same value. If both have the same value, it means multiple substrings exist. We just pick up one.

##Learning
Finding the right recursion solution is the key to DP.
