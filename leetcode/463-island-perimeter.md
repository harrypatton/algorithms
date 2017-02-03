#463 - Island Perimeter
source: https://leetcode.com/problems/island-perimeter/

The problem is easy to solve but the discussion page shows an interesting solution,

##My Solution
1. The default perimeter of a cell is 4. When it has a neighbor, reduce by 1. 
2. Iterate all cells
	* calculate how many neighbors it has.
	* get the perimeter for that cell
3. Sum all of them.

time complexity: O(4n). 4 means it checks 4 neighbor.

##Optimized Solution
1. It calculates how many islands (cell) in the grid.
2. For each island, it checks how many edges from right and down neighbors.
3. `sum = count_cell * 4 - count_edge * 2`

time complexity: O(2n).

##Notes
1. Each edge is shared by two cells so perimeter is reduced by 2.
2. It only checks right and down - it cover all cases but not over-count. This is smart.
