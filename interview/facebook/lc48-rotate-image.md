source: https://leetcode.com/problems/rotate-image/#/solutions

You are given an n x n 2D matrix representing an image.

Rotate the image by 90 degrees (clockwise).

Follow up:
Could you do this in-place?

# Analysis
I used a naive way to do it in-place but the edge cases are still hard to solve. The code becomes very ugly. 

## My solution based on discussion page
```c#
/*
based on the solution from discussion page, the algorithm becomes,
1. reverse each column.
2. do symmetry swap.
*/
public class Solution {
    public void Rotate(int[,] matrix) {
        if(matrix == null) return;
        var n = matrix.GetLength(0);
        
        // reverse each column
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < n/2; j++) {
                Swap(matrix, j, i, n -1 - j , i);
            }
        }
        
        // symmetry swap
        for(int i = 0; i < n; i++) {
            for(int j = i + 1; j < n; j++) {
                Swap(matrix, i, j, j, i);
            }
        }
    }
    
    public void Swap(int[,] matrix, int x1, int y1, int x2, int y2) {
        var temp = matrix[x1, y1];
        matrix[x1, y1] = matrix[x2, y2];
        matrix[x2, y2] = temp;
    }
}
```

## Solution from Discussion Page
Very clean and easy to understand solution.

```c++
/*
 * clockwise rotate
 * first reverse up to down, then swap the symmetry 
 * 1 2 3     7 8 9     7 4 1
 * 4 5 6  => 4 5 6  => 8 5 2
 * 7 8 9     1 2 3     9 6 3
*/
void rotate(vector<vector<int> > &matrix) {
    reverse(matrix.begin(), matrix.end());
    for (int i = 0; i < matrix.size(); ++i) {
        for (int j = i + 1; j < matrix[i].size(); ++j)
            swap(matrix[i][j], matrix[j][i]);
    }
}

/*
 * anticlockwise rotate
 * first reverse left to right, then swap the symmetry
 * 1 2 3     3 2 1     3 6 9
 * 4 5 6  => 6 5 4  => 2 5 8
 * 7 8 9     9 8 7     1 4 7
*/
void anti_rotate(vector<vector<int> > &matrix) {
    for (auto vi : matrix) reverse(vi.begin(), vi.end());
    for (int i = 0; i < matrix.size(); ++i) {
        for (int j = i + 1; j < matrix[i].size(); ++j)
            swap(matrix[i][j], matrix[j][i]);
    }
}
```
