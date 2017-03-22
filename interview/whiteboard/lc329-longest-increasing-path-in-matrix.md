# LC329. Longest Increasing Path in a Matrix
Source: https://leetcode.com/problems/longest-increasing-path-in-a-matrix/#/description

Given an integer matrix, find the length of the longest increasing path.

From each cell, you can either move to four directions: left, right, up or down. You may NOT move diagonally or move outside of the boundary (i.e. wrap-around is not allowed).

Example 1:
```
nums = [
  [9,9,4],
  [6,6,8],
  [2,1,1]
]
Return 4
The longest increasing path is [1, 2, 6, 9].
```

Example 2:
```
nums = [
  [3,4,5],
  [3,2,6],
  [2,2,1]
]
Return 4
The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.
```

## Analysis
1. I wrote the first version of code using backtracking. I has a matrix to track if the element is used or not in the traversal to avoid infinite loop. Unfortunately my solution is time out.
2. Go back to the question, it should be a DP. Why?
    * it asks for count instead of the path.
    * it always go to next bigger element so it won't go back to visited node. We don't need the visited matrix.
3. Check the DP solution below,

```csharp
public class Solution {
    public int LongestIncreasingPath(int[,] matrix) {
        int max = 0;
        if (matrix == null) {
            return max;
        }
        
        var cache = new int[matrix.GetLength(0), matrix.GetLength(1)];
        
        for(int i = 0; i < matrix.GetLength(0); i++) {
            for(int j = 0; j < matrix.GetLength(1); j++) {
                max = Math.Max(max, Traverse(matrix, i, j, cache));
            }
        }
        
        return max;
    }
    
    public int Traverse(int[,] matrix, int x, int y, int[,] cache) {
        if (cache[x, y] != 0) {
            return cache[x, y];
        }
        
        var offsets = new int[][] { new int[] {0, -1}, new int[] {0, 1}, new int[]{-1, 0}, new int[]{1, 0}};
        int max = 1;
        
        foreach(var offset in offsets) {
            var newX = x + offset[0];
            var newY = y + offset[1];
            if (newX >= 0 && newX < matrix.GetLength(0)
                && newY >= 0 && newY < matrix.GetLength(1)
                && matrix[newX, newY] > matrix[x, y]) {
                max = Math.Max(max, 1 + Traverse(matrix, newX, newY, cache));
            }
        }
        
        cache[x,y] = max;
        return max;
    }
}
```
