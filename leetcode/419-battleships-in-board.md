#419 - Battleships in a Board
source: https://leetcode.com/problems/battleships-in-a-board/

**Problem**

1. Battleship is horizontal or vertical. It is always one row or column. A battleship cannot span multiple rows or columns.
2. The board has only battleships and empty slots. It never give invalid battleships as input.

**Requirement**: do it in `one-pass`, using only `O(1) extra memory` and `without modifying the value of the board`?

# Analysis
Scan the 2D array

* if it is an empty slot, ignore.
* if it is a cell,
	* no right/down neighbors, result++;
	* right neighbor exists, ignore and keep moving.
	* down neighbor exists, ignore and keep moving.

It means we add the battleship whenever we reach the end.

Easy algorithm

```C#
public class Solution {
    public int CountBattleships(char[,] board) {
        int result = 0;
        
        if (board == null) {
            return result;
        }
        
        int rowCount = board.GetLength(0);
        int columnCount = board.GetLength(1);
        
        for(int i = 0; i < rowCount; i++) {
            for (int j = 0; j < columnCount; j++) {
                if ((board[i,j] == 'X')
                    && ( i == rowCount - 1 || board[i+1, j] == '.' )
                    && ( j == columnCount - 1 || board[i, j+1] == '.' )) {
                        result++;
                    }
            }
        }
        
        return result;
    }
}
```
