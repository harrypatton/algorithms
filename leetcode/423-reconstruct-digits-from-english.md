#423 Reconstruct Digits from English
source: https://leetcode.com/problems/reconstruct-original-digits-from-english/?tab=Description

**Problem**: Given a non-empty string containing an out-of-order `English representation` of digits 0-9, output the digits in `ascending order`.

Input contains only lowercase English letters; input is guaranteed to be valid and can be transformed to its original digits.

Example 1
```
Input: "owoztneoer"
Output: "012"
```

# Analysis
1. I tried to use DP but cannot find a good sub-problem.
2. I used the backtrack
	* when the first digit is in the result, do the recursion call but with fewer chars.
	* when the first digit is not in the result, do the recursion call but without using the first digit.
	* My original code was wrong because I repeat the logic for every digit. It is not true. The division based on first digit already give complete solution.
	* My original code didn't have the wrong recursion exit condition.
3. I fell back to another solution (which is the same as discussion page)
	* find particular things in each word.
	* some words have very special letter to identify them. E.g., only six has letter `x`
	* After identify them first, we can use other special letters to identify the rest. E.g., after identifying `six` is above step, only `seven` has letter `s`.

The cool thing is that discussion page has a cleaner code. Instead of modifying the mapping table letter-count, it uses counter like,

counter[6] = count of letter `x`
counter[7= count of letter `s` - counter[6]

**it is pretty cool**.
