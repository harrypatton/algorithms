# LC200 - Number of Islands
[Source](https://leetcode.com/problems/number-of-islands/#/description)

Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
You may assume all four edges of the grid are all surrounded by water.

## Analysis
1. I didn't make it out in first time.
2. I tried brutal force but cannot figure out a good way.
3. I tried DP but cannot come with the subproblem formula. I tried DP hard because #2 doesn't work out and it is usually a sign for DP.
4. I read the discussion page and then realized it can be solved by backtracking/DFS. 

```csharp
public class Solution {
    public int NumIslands(char[,] grid) {
        int count = 0;
        
        for(int i = 0; i < grid.GetLength(0); i++) {
            for(int j = 0; j < grid.GetLength(1); j++) {
                if (grid[i, j] == '1') {
                    count++;
                    ClearLand(grid, i, j);
                }
            }
        }
        
        return count;
    }
    
    public void ClearLand(char[,] grid, int i, int j) {
        int rowCount = grid.GetLength(0);
        int columnCount = grid.GetLength(1);
        
        if (i < 0 || i >= rowCount || j < 0 || j >= columnCount || grid[i, j] == '0')
            return;
        
        grid[i, j] = '0';
        ClearLand(grid, i - 1, j);
        ClearLand(grid, i + 1, j);
        ClearLand(grid, i, j - 1);
        ClearLand(grid, i, j + 1);
    }
}
```
