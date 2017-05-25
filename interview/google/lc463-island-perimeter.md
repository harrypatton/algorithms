Source: https://leetcode.com/problems/island-perimeter/#/description

You are given a map in form of a two-dimensional integer grid where 1 represents land and 0 represents water. 
Grid cells are connected horizontally/vertically (not diagonally). 
The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells). 
The island doesn't have "lakes" (water inside that isn't connected to the water around the island). 
One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. 
Determine the perimeter of the island.

## Analysis
It is easy to come up with the solution. I know the discussion page has a better solution which just check right and down neighbors
but I don't think I can come up with it right away. It is good to know though.

```c#
public class Solution {
    public int IslandPerimeter(int[,] grid) {
        if (grid == null) return 0;
        var offsets = new int[,] {{1, 0},{-1, 0},{0, 1},{0, -1}};
        int perimeter = 0;
        
        for(int i = 0; i < grid.GetLength(0); i++) {
            for(int j = 0; j < grid.GetLength(1); j++) {
                if (grid[i, j] == 0) continue;
                
                perimeter += 4;
                for(int k = 0; k < offsets.GetLength(0); k++) {
                    int x = i + offsets[k, 0];
                    int y = j + offsets[k, 1];
                    
                    if (x >= 0 && y >= 0 && x < grid.GetLength(0) && y < grid.GetLength(1) && grid[x, y] == 1) 
                        perimeter--;
                }
            }
        }
        
        return perimeter;
    }
}
```
