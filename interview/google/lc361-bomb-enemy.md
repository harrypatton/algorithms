Source: https://leetcode.com/problems/bomb-enemy/#/description

Given a 2D grid, each cell is either a wall 'W', an enemy 'E' or empty '0' (the number zero), 
return the maximum enemies you can kill using one bomb.

The bomb kills all the enemies in the same row and column from the planted point until it hits the wall 
since the wall is too strong to be destroyed.

Note that you can only put the bomb at an empty cell.

Example: For the given grid
```
0 E 0 0
E 0 W E
0 E 0 0
```
return 3. (Placing a bomb at (1,1) kills 3 enemies)

## Analysis
* naive solution - place the bomb in every possible empty cell and then calculate the result. O(n^3) - n^2 positions and n for each check.
* optimized solution - discussion shows a DP solution but I cannot figure it out.
* Update - I just understand the two times scan DP in discussion page. (the top two answers are not easy to understand).

```c#
public class Solution {
    public int MaxKilledEnemies(char[,] grid) {
    	if (grid == null) return 0;

    	int rowCount = grid.GetLength(0);
    	int colCount = grid.GetLength(1);
    	int max = 0;
        var dp = new int[rowCount, colCount];

        // scan each row
        for(int i = 0; i < rowCount; i++) {
        	// left -> right
        	int enemyCount = 0;
        	for(int j = 0; j < colCount; j++) {
        		enemyCount = UpdateCache(grid, i, j, dp, enemyCount);
        	}

        	// right -> left
        	enemyCount = 0;
        	for(int j = colCount - 1; j >= 0; j--) {
        		enemyCount = UpdateCache(grid, i, j, dp, enemyCount);
        	}
        }

        // scan each column
        for(int j = 0; j < colCount; j++) {
        	// top -> down
        	int enemyCount = 0;
        	for(int i = 0; i < rowCount; i++) {
        		enemyCount = UpdateCache(grid, i, j, dp, enemyCount);
        	}

        	// down -> top
        	enemyCount = 0;
        	for(int i = rowCount - 1; i >= 0; i--) {
        		enemyCount = UpdateCache(grid, i, j, dp, enemyCount);
        		if (grid[i, j] == '0') max = Math.Max(max, dp[i, j]);
        	}
        }

        return max;
    }

    public int UpdateCache(char[,] grid, int i, int j, int[,] dp, int enemyCount) {
    	if (grid[i, j] == 'E') enemyCount++;
		else if (grid[i, j] == 'W') enemyCount = 0;
		else dp[i, j] += enemyCount;

		return enemyCount;
    }
}
```
