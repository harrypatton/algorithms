#420 Strong Password Checker
source: https://leetcode.com/problems/strong-password-checker/

A password is considered strong if below conditions are all met:

1. It has at least 6 characters and at most 20 characters.
2. It must contain at least one lowercase letter, at least one uppercase letter, and at least one digit.
3. It must NOT contain three repeating characters in a row ("...aaa..." is weak, but "...aa...a..." is strong, assuming other conditions are met).

Write a function `strongPasswordChecker(s)`, that takes a string s as input, and return the MINIMUM change required to make s a strong password. If s is already strong, return 0.

Insertion, deletion or replace of any one character are all considered as one change.

# Analysis
1. First check the length.
	* if it has more chars, just remove them.  `result == s.Length - 20`
	* if it has fewer chars, just add them. `result == 6 - s.Length`.
2. Check special letter. When it doesn't exist, `update` or `add` one (it may conflict with #1).
3. Check no repeating character in a row - this is very tricky one.
	* remove one - it may conflict with or address #1
	* update one - it may fix both #2 and #3 using one change.
	* add one - it may conflict with or address #1, but could fix both #2 and #3 using one change.

It seems complicated, even with condition #1 and #2. 

* DP - how to get a sub-problem?
* Recursion - same as DP
* Backtrack - just brutal force and try? I don't know where to start.

**Update** - I gave up and cannot finish reading the solution on discussion page.
