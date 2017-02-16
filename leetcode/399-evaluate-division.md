#399 - Evaluate Division
Source: https://leetcode.com/problems/evaluate-division/?tab=Description

## Analysis
1. It gives an equation which contains `2 variables` and `the result`.
2. Division
	* Single equation - invert itself
	* Multiple equations
		*  `a/b and b/c`, we would know `a/c`.  
		* `a/c and b/c`, we would know `a/b`.
3. In other words, to calculate `m/n`,
	* find equation contains `m and n`.
	* if not, find equation contains `m or n`.

## Solution - brutal force

1. find all variables and create a m*m square to cache the result.
2. for each equation `a/b`, we fill in the cache matrix.
	* [a, b] and [b, a] is calculated.
	* find every letter other than a and b, say c,  `[c, b]`, then we can calculate [c, a] and then [a, c]
	* find every `[c, a]`, calculate [c, b] and then [b, c]
3. Finally use the matrix to get final result.

Performance depends on how many equations to answers; if there're a lot of and spread over different variables, this solution is ok.

## Solution - Graph traversal
It is actually a graph traversal problem. Given a few edges and calculate the distance between other edges. We can use either `DFS` or `BFS`.

## Learning
1. I was able to write out the code and pass the test; however, I feel I am not very familiar with graph data structure.
	* I was confused if we should add visited flag.
	* I was confused if we need to backtracking (i.e., remove the visited flag after the work is done.)
	* I added a work item to get refreshed on graph topic.
