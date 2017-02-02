#464 - Can I Win
source: https://leetcode.com/problems/can-i-win/

**Problem**

that players cannot re-use integers.

For example, two players might take turns drawing from a common pool of numbers of 1..15 without replacement until they reach a total >= 100.

Given an integer `maxChoosableInteger` and another integer `desiredTotal`, determine if the first player to move can force a win, assuming both players play optimally.

You can always assume that `maxChoosableInteger` will not be larger than 20 and `desiredTotal` will not be larger than 300.

#Idea
This is a typical DP problem with a little tweak.

1. First player can pick up any one from 1 .. `maxChoosableInteger` and then second player can choose the rest.
2. Use 2-loops: say first player picks up `n1` and second player picks up `n2`. The problem becomes if first player can win in the rest of numbers to first reach `desiredTotal - n1`.  **Note** I don't know how we can represent the state after picks up `n1` and `n2`.
3. Let's think of another way - what happened for `maxChoosableInteger - 1`. Assume there's an array which index is every number from 1 to `desiredTotal`, and element is boolean which indicates whether first player won.
	* when `maxChoosableInteger` is an odd, it is first player's turn. Update the array backward to see which one we can `win`.
	* when `maxChoosableInteger` is an even, it is second player's turn. Update the array backward to see which one we can `lose`. **Note** not sure how to update it.

**Finally I have to look for help from discussion page.**

**Update**

1. After reading the discussion, it still goes to idea #2. The way to represent the state is using an array of boolean - true means the number is used and false means unused. The key thing is `maxChoosableInteger` is less than 20 so we can use integer to represent the state using bit. 
2. It still uses some backtrack idea. I need to learn more.
3. Without memory cache, the time complexity is O(n!) - enumerate all combinations. I don't understand why it becomes O(2^n) when use memory cache.

