#Objective
Check if a string is a rotation of another string.

e.g., `foobar` is a rotation of `barfoo`. `foobar` is not a rotation of `bfooar`.

#Ideas
##brutal force
1. verify if two strings have the same length.
2. A rotation string has a different start point than other. When iterate through the whole string, they should be the same.
	* check every start point
	* iterate and verify if they're equal.
	* time complexity: O(n^2)

##optimal solution
I cannot find a good solution yet.

**Update**: the reference link shows a better solution. If we append the first string itself and the 2nd string is a substring of a new one, it is a rotation then.

Based on [wiki page](https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm), the substring search algorithm has O(n) time complexity using KMP.

#Reference
* http://algorithms.tutorialhorizon.com/check-if-one-string-is-rotation-of-another-string/
