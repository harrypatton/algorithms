# Permutation
source: https://leetcode.com/problems/permutations/?tab=Description

**problem**: Given a collection of distinct numbers, return all possible permutations.

## Solutions
1. **Recursion #1** - first letter could be any letter. Pick up that and then use the rest of arrays to fill others. It is a little bit tricky because we need to track which letter is already used.
2. **Iteration #2** - assume we have data f(n-1), to calculate f(n), we just need to insert the letter into every possible position. 
3. **Bitmap** - nope. I cannot find a good solution.

**Update** - it is easy to write the code but spent me a few minutes to figure out a bug.

* when remove first 10 elements from the list, just need to call the `list.RemoveAt(0)` 10 times. I was writing code like `list.RemoveAt(i)` which is wrong and actually removed 0, 2nd and 4th elements (because removing changes the index). I was silly at that time :-).
