#434 - Number of Segments in a String

source: https://leetcode.com/problems/number-of-segments-in-a-string/

**Problem**: Count the number of segments in a string, where a segment is defined to be a contiguous sequence of non-space characters.

## Analysis
* It is the same as the question like word count. 
* Be careful about edge cases.
	* null or empty string
	* no space - single word
	* contiguous spaces
	* multiple words
	* leading spaces
	* trailing spaces
* Expect time complexity to be O(n) 

## Idea - one loop
What's the best algorithm to cover so many edge cases?

1. Handle null or empty string first.
2. Iterate through the string,
	* When run into a space, if previous char exists and is not space, add 1; otherwise keep going.
	* When run into non-space, keep going.
3. After iteration is done, if last char is non-space, add 1.

I believe it should cover all edge cases. We'll see after running with Leetcode.

## Learning
1. Unlike my solution counts the word when see the last letter, discussion page shows we can also count the word whenever see the first letter of the word. It is a better solution to cover all edge cases with cleaner code. Interesting.
