source: https://leetcode.com/problems/valid-sudoku/#/description

Sudoku:

1. each row has unique digit 1 - 9.
2. each column has unique digit 1 - 9.
3. each 9-box grid has unique digit 1 - 9.

## Analysis
1. The problem is very easy to solve but my original code is crappy. Not clean and scan the board three times.
2. I look at the discussion page. There're clean solutions there.

### Clean code
```

```

### Original code
```c#
public class Solution {
    public bool IsValidSudoku(char[,] board) {
        // check row
        for(int i = 0; i < 9; i++) {
            var hasValue = new bool[9];
            for(int j = 0; j < 9; j++) {
                if(board[i, j] != '.') {
                    int value = board[i, j] - '1';
                    if (hasValue[value]) return false;
                    else hasValue[value] = true;
                }
            }
        }
        
        // check column
        for(int i = 0; i < 9; i++) {
            var hasValue = new bool[9];
            for(int j = 0; j < 9; j++) {
                if(board[j, i] != '.') {
                    int value = board[j, i] - '1';
                    if (hasValue[value]) return false;
                    else hasValue[value] = true;
                }
            }
        }
        
        // check 9-box grid
        for(int i = 0; i < 9; i=i+3) {
            for(int j = 0; j < 9; j=j+3) {
                var hasValue = new bool[9];
                for(int x = 0; x < 3; x++) {
                    for(int y = 0; y < 3; y++) {
                        if(board[i+x, j+y] != '.') {
                            int value = board[i+x, j+y] - '1';
                            if (hasValue[value]) return false;
                            else hasValue[value] = true;
                        }
                    }
                }
            }
        }
        
        return true;
    }
}
```
