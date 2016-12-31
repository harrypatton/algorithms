#Origin
* http://algorithms.tutorialhorizon.com/algorithms-find-whether-given-the-sequence-of-parentheses-are-well-formed/

#Overview
**Objective**: 
Check if a sequence of parentheses are well formed.

#Ideas
It seems easy when I think about the scenario in Compiler class that executes a statement consisting of different operations. It needs a stack to check.

1. If it is an open parenthesis, push to stack.
2. If it is a close one, peek the stack
	* if matched open one, pop it.
	* otherwise report error.
3. After scanning all chars in the string, verify the stack is empty.

#Learning
My solution can handle multiple types of brackets. Both space and time complexity are O(n).

The solution in original post has a better space complexity O(1) but it works for single parentheses type.
