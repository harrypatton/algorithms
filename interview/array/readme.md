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
