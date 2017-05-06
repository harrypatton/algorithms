Source: https://leetcode.com/problems/spiral-matrix/#/description

Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.

For example, given the following matrix:
```
[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]
```
You should return `[1,2,3,6,9,8,7,4,5]`.

## Analysis
Solution is easy to write but could have a lot of edge cases.

## Clean Code
Compared with my original code, this one is cleaner to understand. It uses 4 variables to track `row begin`, `row end`, `column begin`, `column end`.

```c#
public class Solution {
    public IList<int> SpiralOrder(int[,] matrix) {       
        var result = new List<int>();
        if(matrix == null) return result;
        int rowBegin = 0;
        int rowEnd = matrix.GetLength(0) - 1;
        int colBegin = 0;
        int colEnd = matrix.GetLength(1) - 1;
        
        while(rowBegin <= rowEnd && colBegin <= colEnd) {            
            // top
            for(int j = colBegin; j <= colEnd; j++) result.Add(matrix[rowBegin, j]);
            rowBegin++;
            
            // down
            for(int j = rowBegin; j <= rowEnd; j++) result.Add(matrix[j, colEnd]);            
            colEnd--;
            
            // important to check boundary here when there's one row left to traverse.
            if (rowEnd >= rowBegin) { 
                // bottom
                for(int j = colEnd; j >= colBegin; j--) result.Add(matrix[rowEnd, j]);
                rowEnd--;
            }            
         
            // important to check boundary here when there's one column left to traverse.
            if (colEnd >= colBegin) {
                // left
                for(int j = rowEnd; j >= rowBegin; j--) result.Add(matrix[j, colBegin]);
                colBegin++;
            }            
        }
                                  
        return result;
    }
}
```

## Orignal Code
The code which calculates each new boundary is hard to understand.

```c#
public class Solution {
    public IList<int> SpiralOrder(int[,] matrix) {
        int rowCount = matrix.GetLength(0);
        int columnCount = matrix.GetLength(1);
        int count = (Math.Min(rowCount, columnCount) + 1) / 2;
        var result = new List<int>();
        
        for(int i = 0; i < count; i++) {
            // top
            for(int j = i; j < columnCount - i; j++) {
                result.Add(matrix[i, j]);
            }
            
            // down
            for(int j = i + 1; j < rowCount - i; j++) {
                result.Add(matrix[j, columnCount -1 -i]);
            }
            
            if (rowCount -1 - i > i) {
                // bottom
                for(int j = columnCount - 2 - i; j >= i; j--) {
                    result.Add(matrix[rowCount -1 -i, j]);
                }                   
            }
         
            if (columnCount - 1 - i > i) {
                // left
                for(int j = rowCount - 2 - i; j >= i + 1; j--) {
                    result.Add(matrix[j, i]);
                }                   
            }         
        }
                                  
        return result;
    }
}
```
