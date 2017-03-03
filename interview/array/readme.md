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

#LC33 - Search in Rotated Sorted Array
source: https://leetcode.com/problems/search-in-rotated-sorted-array/?tab=Description

**Problem** - find an element in the array. If not found, return -1. Assume no duplicate exists in the array.

## Analysis
1. Use binary search idea. Every time we should cut half elements so the time complexity is supposed to be O(logn).
2. Draw a picture to get better idea. Select the middle. half element will go to normal binary search and the rest will call ~~the same function recursively~~.
3. Feel easier when no duplicate elements in the array:).
4. **Update** - it is tricky to get edge cases right.
5. **Update 2** - not sure why I was think about recursion. Binary search doesn't need recursion - just move two pointers.

Reset Analysis

1. List all scenarios to consider,
	* one element
	* two elements with descending order
	* ascending order without rotation
	* rotate in the first half
	* rotate in the second half.
2. First of all we need to get middle. If middle == target, it is good.
3. Divided into scenarios.  
	* if middle > start, it is 3+ ascending array, or rotation point is in 2nd half.
		* if target is in `[start, middle)`, `middle - 1` becomes `end`.
		* otherwise go to the right.
	* if middle < start, its rotation point is in the first half.
		* if target is in `(middle, end]`, `middle + 1` becomes `start`.
		* otherwise go to the left.
	* if middle == start, it is 1-element array, or 2-elements array. Which pointer to move?
		* it doesn't matter for 1-element array because pointers would become invalid.
		* for 2-elements array, we can move to right.

**Update**: one time bug-free pass.

#LC153 - Find Minimum in Rotated Sorted Array
source: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/?tab=Description

The array doesn't have duplicate numbers. The problem is to look for the pivot element (i.e., the min value).

## Analysis
1. Still need to care about all scenarios.
2. Unlike finding a target, when do we quite when find the min?
	* when middle > end, go to right (`excluding` the middle)
	* when middle < end, go to left (`including` the middle)
	* when middle == end, it is pivot point.

**Update**: be careful about the edge cases. Still took me 2 times to fix the issue.

#LC81 - Search in Rotated Sorted Array II
source: https://leetcode.com/problems/search-in-rotated-sorted-array-ii/?tab=Description

In this case, the array may contain duplicate numbers.

## Analysis
1. Need to list a few scenarios like previous scenario.
2. The key thing is, if start == middle == end, we cannot tell which direction to go. so we move one step for both pointers. 

**Update**: I missed #2 in the first time but quickly found it after running the test case.

#LC154 - Find Minimum in Rotated Sorted Array II
source: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/?tab=Description

The array may contain duplicate elements; Other than that, it is the same LC153.

## Analysis
1. Just need to be careful about the edge cases; other than that, it is easy to write. I fixed one edge case and passed the test.

