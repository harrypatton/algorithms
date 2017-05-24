Source: https://leetcode.com/problems/number-of-islands/#/description

Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

Example 1:
```
11110
11010
11000
00000
```
Answer: 1

Example 2:
```
11000
11000
00100
00011
```
Answer: 3

## Analysis
1. See how beautiful the code is for DFS solution. 
2. BFS solution has a better solution. **Remember**: always use visited to improve the perf. It would time out on LeetCode if we don't use visited.

```c#
public class Solution {
    
    public struct Point {
        public int x;
        public int y;
        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
    
    public int NumIslands(char[,] grid) {
        int result = 0;
        if (grid == null) return result;
        
        for(int i = 0; i < grid.GetLength(0); i++) {
            for(int j = 0; j < grid.GetLength(1); j++) {
                if (grid[i, j] == '1') {
                    result++;
                    //BFS(grid, i, j);
                    DFS(grid, i, j);
                }
            }
        }
        
        return result;
    }
    
    public void DFS(char[,] grid, int i, int j) {
        if (i < 0 || j < 0 || i >= grid.GetLength(0) || j >= grid.GetLength(1) || grid[i, j] == '0') return;
        grid[i, j] = '0';
        DFS(grid, i + 1, j);
        DFS(grid, i - 1, j);
        DFS(grid, i, j + 1);
        DFS(grid, i, j - 1);
    }
    
    public void BFS(char[,] grid, int i, int j) {
        var offsets = new int[,] {{1, 0}, {0, 1}, {-1, 0}, {0, -1}};
        var q = new Queue<Point>();
        var start = new Point(i, j);
        q.Enqueue(new Point(i, j));
        var visited = new HashSet<Point>();
        visited.Add(start);
        
        while(q.Count > 0) {
            var cell = q.Dequeue();
            grid[cell.x, cell.y] = '0';
            for(int row = 0; row < offsets.GetLength(0); row++) {
                int x = cell.x + offsets[row, 0];
                int y = cell.y + offsets[row, 1];
                var point = new Point(x, y);
                if (x >= 0 && y >= 0 && x < grid.GetLength(0) && y < grid.GetLength(1)
                    && grid[x, y] == '1' && !visited.Contains(point)) {
                    q.Enqueue(point);
                    visited.Add(point);
                }
            }
        }
    }
}
```
