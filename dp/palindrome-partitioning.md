Title: Split the String into Minimum number of Palindromes

#Objective
Given a large string, cut the string into chunks such that each sub­string is a palindrome. A string with only one char is a palindrome. The goal is to find the minimum number of cuts.

#Ideas
##Brutal force
1. Assume the string has n chars. It has n-1 potential cut positions and include one which doesn't have any cut. Total ways of substring is 2^(n-1) + 1.
2. Check each substring is palindrome or not.
3. Find the minimum cut from the iteration.

##Recursion
1. f(n) means min palindrome substring count. 
2. Base: f(-1) = 0, f(0) = 1
2. f(n+1) is the minimum of,
	* f(n) + 1
	* assume a few palindrome ending with n+1 position - [m1, n+1], [m2, n+1], ..., [mz, n+1]. Calculate the minimum of f(m1-1), f(m2-1), ..., f(mz-1). After that, plus 1 to include the ending palindrome as well.

Given a position, how to find all palindrome substrings ending on it? If we use a 2D matrix to track all substrings, it is easy to calculate palindrome flags for all of them.

##DP
Check recursion algorithm for DP.

###Note 
1. The original post at tutorialhorizon uses hash table to store substring result in recursion way using top-down approach.
2. The post on geeksforgeeks actually uses my way to solve the problem.

###Complexity
* Time: O(n^2)
* Space: O(n^2)

#Reference
* http://algorithms.tutorialhorizon.com/dynamic-programming-split-the-string-into-minimum-number-of-palindromes/
* http://www.geeksforgeeks.org/dynamic-programming-set-17-palindrome-partitioning/
