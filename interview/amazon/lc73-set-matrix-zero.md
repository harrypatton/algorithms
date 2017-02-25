# 73 - Set Matrix Zeroes
source: https://leetcode.com/problems/set-matrix-zeroes/?tab=Description

**Problem**: Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in place.

## Solution
1. Use two hash sets (or bool arrays) to store which row and column to set 0. 
	* one scan to find row and column to be zero.
	* another scan to fill in all expected rows and columns.
	* complexity: time `O(n*m)`, space `O(n+m)`.
2. Constant space solution
	* can we update the whole row and zero when detect zero? no, because it wouldn't tell us which element has zero in origin after that operation.
	* we must find a way to mark it.

**Update #1** - I cannot find a solution. Need to check discussion page.

**Update #2** - discussion page has a very smart solution. It saves all zero rows information in first column, and all zero columns information in first row. Because first column and row shares the same top-left cell, it cannot tell if first row or column should be zero. Assume it indicates whether first row should be zero or not, we need another variable to indicate whether first column should be zero or not.
