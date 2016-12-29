#Origin
* http://algorithms.tutorialhorizon.com/dynamic-programming-edit-distance-problem/

#Overview
**Objective**: 
Given two strings, s1 and s2 and edit operations (given below). Write an algorithm to find minimum number operations required to convert string s1 into s2.

Allowed Operations:

* Insertion — Insert a new character.
* Deletion — Delete a character.
* Replace — Replace one character by another.

#Ideas
## Brutal force
Not sure how to proceed with brutal force.

## Recursion
1. Compare s1 and s2 from the beginning.
	* if both chars are equal, i.e., s1[i] == s2[j], calculate the result for two string s1[i+1..m], s2[j+1..n].
	* else the value == 1 + min(the following items)
		* delete first char in s1 and then calculate s1[i+1..m], s2[j..n].
		* insert first in s1 and then calculate s1[i..m], s2[j+1..n].
		* replace first in s1 and then calculate s1[i+1..m], s2[j+1..n].

## DP
Maintain 2D matrix. The row is s1 and column is s2.

1. f(i, j) means the min operation converted from a substring starting from index i in s1 to a substring starting from index j in s2.
2. Base: at the bottom-right corner, it is either 0 or 1. 
3. Fill in last row and column.
4. f(i, j) 
	* if s1[i] == s[j], f(i, j) = f(i+1, j+1).
	* otherwise, f(i, j) = min{ f(i+1, j), f(i, j+1), f(i+1, j+1) }.

#Learning
