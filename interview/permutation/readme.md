# Permutation
source: https://leetcode.com/problems/permutations/?tab=Description

**problem**: Given a collection of distinct numbers, return all possible permutations.

## Solutions
1. **Recursion #1** - first letter could be any letter. Pick up that and then use the rest of arrays to fill others. It is a little bit tricky because we need to track which letter is already used.
2. **Iteration #2** - assume we have data f(n-1), to calculate f(n), we just need to insert the letter into every possible position. 
3. **Bitmap** - nope. I cannot find a good solution.

**Update** - it is easy to write the code but spent me a few minutes to figure out a bug.

* when remove first 10 elements from the list, just need to call the `list.RemoveAt(0)` 10 times. I was writing code like `list.RemoveAt(i)` which is wrong and actually removed 0, 2nd and 4th elements (because removing changes the index). I was silly at that time :-).

# Permutation II
source: https://leetcode.com/problems/permutations-ii/?tab=Description

Given a collection of numbers that might contain `duplicates`, return all possible unique permutations.

## Solutions
The key thing here is about the `duplicates`. 

1. **brutal force** - get all permutation and remove duplicates. It is inefficient.
2. **iterative** - we still get the result from left to right; however, when add new element, we add it only if the previous element is not the same value. (if yes, we already added it). E.g., add `b` to `abcb`, it becomes `babcb`, `abbcb`, `abcbb`.
	* **Update**: this solution doesn't work for `2, 2, 1, 1`. 
3. **Next Permutation** - aka., `lexicographical order`, a new way to add elements incrementally. 
	* **Update**: tried myself but cannot figure out the right algorithm. need to look for help:). See next section for `Next Permutation algorithm`.
4. **DFS**
	* sort the array
	* pick every `unique` number as the first one of the permutation result.
	* Use recursion to calculate the rest.
	* e.g., [1, 1, 2, 2]. The result is, `1 + [1, 2, 2]`, `2 + [1, 1, 2]`. 
	* Need to track which element is used. 
	* `Next Permutation` is easier for me.
5. **Backtracking**: discussion page always shows backtracking solution but I find it is very hard to understand.

### Next Permutation
Source

* http://stackoverflow.com/questions/1622532/algorithm-to-find-next-greater-permutation-of-a-given-string
* https://www.nayuki.io/page/next-lexicographical-permutation-algorithm

> * Find the highest index `i` such that `s[i] < s[i+1]`. If no such index exists, the permutation is the last permutation.
> * Find the highest index `j > i` such that `s[j] > s[i]`. Such a j must exist, since i+1 is such an index.
> * Swap `s[i]` with `s[j]`.
> * Reverse the order of all of the elements after index `i` till the last element.
