#Origin
* http://algorithms.tutorialhorizon.com/find-whether-two-strings-are-permutation-of-each-other/
* http://www.geeksforgeeks.org/check-whether-two-strings-are-anagram-of-each-other/

#Overview
**Objective**: 
Given two strings, check whether one string is permutation of other.

**Example**:
"Sumit" and "tiums" are permutation.
"abcd" and "bdea" are not.

#Ideas
1. Sort each string and verify they're equal. Time complexity is O(nlogn).
2. Use hash table - time complexity is O(n) but space complexity is O(n).
	* Check they have the same size.
	* Add every letter in first string to hash table and record count.
	* Iterate every letter in second string. minus count if found. If not found or count becomes negative, it is not permutation.
3. We could use array to replace hash table if total number of letters is small (e.g., ASCII, 256)

#Learning
