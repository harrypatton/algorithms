# 394. Decode String
source: https://leetcode.com/problems/decode-string/?tab=Description

The problem is easy to understand. A few examples,
```
* abc => abc
* 2[a] => aa
* 2[ab] => abab
* a2[a3[b]] => aabbbabbb
* 12[a] => aaaaaaaaaaaa
```

## Analysis
1. one tricky part is the nest expression. It is obvious that we should use stack to handle.
2. when run into a number, push it to number stack.
3. when run into a char, push it to char stack.
4. when run into a `[`, we need to push it to both stacks because we want remaining ones to separate from the incoming one. The position is a little bit different,
	* for number stack, it could be `2[`.
	* for char stack, it could be `[abc`. 
5. when run into a `]`, we known we need to calculate.
	* for number stack like `2[3[`, get the number between two `[`. After that, remove the number and right `[`. Keep the left `[` so next number can push to stack with separator.
	*  for char stack like `[ab[c`, get the char from top, but it needs to remove `[` as well.
	* after get new string based on value from char and number stack; what's next?
		* if char stack is empty. the string can append to result.
		* if char stack is not empty, it means we are still in a nest expression. We should push these new string back to the stack.
6. After we're done with iteration, if char stack is not empty, it is more like a scenario `abcd`, we just need to pop up them and write in reverse order.
7. when pop the item, we can append to a string builder, use the number to repeat, and just need to reverse the string builder at once.
8. when num stack is empty, treat the number as 1. 

## Learning
1. my code passed after a few iterations in which I fixed some edge cases. I don't feel my logic is clean and code is optimal. 
2. the solution in discussion page is much clean. (I thought about it while coding). the stack is not for char. The stack stores the string and also integer itself. It never pushes `[` into the stack.
