# LC3 - longest substring without repeating characters
source: https://leetcode.com/problems/longest-substring-without-repeating-characters/?tab=Description

**Problem**: Given a string, find the length of the longest substring without repeating characters.

## Analysis
1. The problem doesn't say lower-case English letter so we need to use hash table.
2. **Brutal force** - check every single `substring` and verify all chars are unique.  time complexity is O(n^3).
3. **DP** - f(n) means longest substring (without dupe) ending with this letter. For new letter, scan back to find longest substring until `f(n) + 1`. total complexity is O(n^2).
4. **Moving Window**
	* use a hash set to store current characters.
	* let's use two pointers. Check end pointer,
		* if it is not in hash set, add it, move end pointer, increase the counter (and update the max)
		* if it is in hash set, we need to move start pointer.  While moving, remove the element from hashset until reach the same value as end point. Move end pointer one step.
		* when end step reach after the end, we can quite.

**Update**: yes, I get one-time pass with bug-free code.

## Learning
1. [Discussion page](https://leetcode.com/articles/longest-substring-without-repeating-characters/) has awesome solutions to learn. It uses a Dictionary to store the char index. When the char is repetitive, it uses that index value to quickly skip.
2. we don't have to set a variable for the counter, because it is equal to (end - start + 1).

#LC179 - Largest Number
source: https://leetcode.com/problems/largest-number/?tab=Description

Given a list of non negative integers, arrange them such that they form the largest number. For example, given `[3, 30, 34, 5, 9]`, the largest formed number is `9534330`. Note: The result may be very large, so you need to return a string instead of an integer.

## Analysis
1. The first digit in each number is very important. We should pick up the one with biggest digit.
2. If the first digit is the same, it is tricky for next one. E.g, `3, 32, 34`.  `34332` is the biggest one.
	* If both numbers have the `nth` digit, bigger digit wins. E.g., `32, 36 = 3632`.
	* If one digit is missing, the other one with a bigger second digit which is also greater than first digit is bigger. E.g, `3, 34 = 343`, `3, 32 = 332`, 
		* if the 3rd digit is the same, we have to keep checking the rest. `3, 332 = 3332 `, `3, 334 = 3343`
3. We just need to sort based on logic above and combine them together.
4. **Update** - the above analysis is too tricky when the remaining letter is the same as first one. See examples below. 

```
32, 323 => 323-32
343, 3433 => 34-343
```
I end up with a cheating way - just check `string.Compare(numStr1 + numStr2, numStr2 + numStr1)`. The result is accepted by the system.

