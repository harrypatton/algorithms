#459 Repeated Substring Pattern
Source: https://leetcode.com/problems/repeated-substring-pattern/

**Problem**:  Given a non-empty string check if it can be constructed by taking a substring of it and appending multiple copies of the substring together. You may assume the given string consists of lowercase English letters only and its length will not exceed 10000.

##Solutions
I tried a couple of times but didn't find a good solution on it.

1. I thought it could be AA or AAA pattern, but realized it could be AAAAA too.
2. DP - I don't know how to break down sub-problems.

##Learning
1. Discussion page doesn't have any better solution other than brutal force. The trick is, the substring length must be divided by the string length.
2. Time complexity:
	* How many potential substrings? `str.Length == a * b`.  For each pair of `a` and `b`, the min one must be equal or less than O(Sqrt(n)). 
	* For each substring, the checking is O(n) - scan the whole string.
	* Total complexity: O(n * Sqrt(n)).
3. Sometimes the brutal force solution is the best solution.
4. I use separate functions to eliminate a lot of checks in original code like 
```
if (!isRepeated) {
	break;
}
```
