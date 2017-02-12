#417 Pacific Atlantic Water Flow
Source: https://leetcode.com/problems/pacific-atlantic-water-flow/

It may take a while to understand the problem. To simply it, here's the problem,

1. We can go to any direction - left, right, top and down, as long as current height >= neighbor's.
2. Take one cell as start point, if it can go to `(top or left border) AND (right or bottom border)`, add it to result.

# Analysis
1. It seems a DP problem and we can iterate once for Pacific (top/left border) and then Atlantic (bottom/right border).
2. Let's start for Pacific first
	* use a 2d matrix to save the result
	* first row and column become `true`
	* **a**. iterate `from top to bottom and from left to right`. If neighbors at `bottom` or `right` is true and current cell height >= its height, set it true.
	* **b**. iterate `from bottom to top and from right to left`, if neighbors at `top` or `left`, and current cell height >= its height, set it true.
	* The two iterations would cover all 4 directions. We cannot check 4 directions on each step because we don't know the status of dependent cells.
	* ~~we may iterate multiple times until the recent iteration doesn't change any value. (we need a flag to check it).~~
3. Repeat the process for Atlantic - just different iteration.
4. Check both matrix and find cells which value in both matrix are `true`.

## Update
1. It is still problematic in Step **2.a** and **2.b** so I have to set a flag to indicate if any change due one round (a + b). If yes, keep going; otherwise we are done. I'm not sure how discussion page addresses that issue.

# Learning
1. It uses BFS or DFS to handle this graph problem. Very smart.
2. It uses a 4-element array to handle the 4 neighbors. Very smart.
