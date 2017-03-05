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

# Permutation of an Array of Arrays
source: http://blog.gainlo.co/index.php/2017/01/05/uber-interview-questions-permutations-array-arrays/

Given a list of array, return a list of arrays, each array is a combination of `one element in each given array`. One example,

```
input: [[1, 2, 3], [4], [5, 6]]
output: [[1, 4, 5], [1, 4, 6], [2, 4, 5], [2, 4, 6], [3, 4, 5], [3, 4, 6]]
```

## Analysis
1. The new array pick one element from each array in original list.
2. tricky things or edge cases.
	* what about duplicate elements? need to clarify. If we need to handle duplicates, we need to sort the array and add unique elements (or use hashset to check duplicates).
	* does the order inside the result array matter? E.g., [1, 4, 5], how about [1, 5, 4]? Another way to ask the question, is the nth element in final array always coming from nth array in original list?

### Recursion
Permutation is always each to use recursion or iterative method. Say we have the answer for f(n-1), it is easy to get f(n) by inserting every element to previous result.

### Backtracking
I should practice that too.

### Better Solution
I haven't found out yet.

### Learning
1. The source needs improvement on quality. It is not as good as LeetCode.
2. If we just need to print out the result instead of return, we can use backtracking to save the memory.

#LC22 - Generate all Parentheses
source: https://leetcode.com/problems/generate-parentheses/?tab=Description

Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses. For example, given n = 3, a solution set is:
```
[
  "((()))",
  "(()())",
  "(())()",
  "()(())",
  "()()()"
]
```

## Analysis
1. Not an intuitive way to come up with a solution.
2. Brutal force - n pairs have 2n length. Open parentheses could be any random n positions. Total is C(2n, n). Given one string, it takes O(n) to check if valid. Not efficient.

### Iterative/DP/Recursion
Say we have the result for `f(n-1)`, given a new pair, how to update it?

1. In the first time, I cannot find a good solution on that. I don't know how to denote or find a sub-problem formula. I have to check the answer.
2. I always think of DP, but in this case, to get all results, I should have tried backtracking. Apparently it is very easy to use backtracking. I got one-time bug free pass; but it is not very intuitive to understand.

# Maximum Sum of Two Non-adjacent Elements
Source: http://blog.gainlo.co/index.php/2016/12/02/uber-interview-question-maximum-sum-non-adjacent-elements/

Given an array of integers, find a maximum sum of **two** non-adjacent elements. `For example, inputs [1, 0, 3, 9, 2] should return 10 (1 + 9).`

## Analysis
1. Because it requires non-adjacent elements, so we cannot sort.
2. Brutal Force - check each pair and record the max. time complexity: O(n^2)
3. Optimization - we can also use one time iteration to find the result. 
	* f(n-2) means the max element so the max sum for current element is f(n-2) + array[n].
	* f(n-1) is Math.Max(f(n-2), array[n-1]).
	* Init the value based on first and second element, and then calculate starting from the third one.
	* If array is less than 3 element, we return int.MinValue.
4. Be careful about the edge cases.

##Learning##
1. I can easily write down the code but I don't clarify the question first
	* Is it any random number of non-adjacent elements or two elements? 
	* What if one element is positive and others are negative?
2. When I write the code, I wrongly assume it means 2 elements but the source shows 2 or more elements, so I keep as is and write a new question below.

# Maximum Sum of any Non-adjacent Elements
source: http://blog.gainlo.co/index.php/2016/12/02/uber-interview-question-maximum-sum-non-adjacent-elements/

Given an array of integers, find a maximum sum of **any** non-adjacent elements. `For example, inputs [1, 0, 3, 9, 2] should return 10 (1 + 9).`

## Analysis
1. No intuitive way to do brutal force. 
2. Because it requests max value, we can use DP; otherwise use backtracking.
	* **formula**:  `f(n) = Math.Max(f(n-2) + current_element, f(n-1))`.  It is obvious.
	* **base**: f(0) = array[0], f(1) = Math.Max(array[0], array[1]).

## Learning
1. It is easy to write down the code; but be careful it doesn't work for negative number. When consider negative numbers, the **formula** should be `f(n) = Math.Max(currentElement, f(n-2) + current_element, f(n-1))`. Just add currentElement to the list.
