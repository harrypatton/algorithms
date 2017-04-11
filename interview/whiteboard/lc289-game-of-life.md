Source: https://leetcode.com/problems/game-of-life/#/description

Look at other people's solution, I have to say it is elegant and concise when handle `SetState` method. https://discuss.leetcode.com/topic/29054/easiest-java-solution-with-explanation/2

very straightforward solution. Space is O(1) and time is O(n). Even each cell checks 8 times (for neighbors)

```csharp
/*
live (1), dead (0).

Any live cell with fewer than two live neighbors dies, as if caused by under-population.
Any live cell with two or three live neighbors lives on to the next generation.
Any live cell with more than three live neighbors dies, as if by over-population..
Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

we need the update at the same time, so we could either create a new state array 
or use in-place one. The state is int, so it can store multiple states,
1. dead -> dead 00
2. dead -> live 10
3. live -> dead 01
4. live -> live 11

look at the change, when become dead, nothing changes. (0 added in the begining)
when become live, 1 is added. It means adding 2.

the previous state is always use (state & 1)
*/
public class Solution {
    public void GameOfLife(int[,] board) {
        // calculate next state
        for(int i = 0; i < board.GetLength(0); i++) {
            for (int j = 0; j < board.GetLength(1); j++) {
                SetState(board, i, j);
            }
        }
        
        // switch to next state
        for(int i = 0; i < board.GetLength(0); i++) {
            for (int j = 0; j < board.GetLength(1); j++) {
                board[i,j] = board[i,j] >> 1;
            }
        }
    }
    
    public void SetState(int[,] board, int i, int j) {
        int liveCount = 0;
        
        for(int x = i - 1; x <= i + 1; x++) {
            for (int y = j - 1; y <= j + 1; y++) {
                if (x == i && y == j) continue; // ignore itself
                
                if (x >= 0 && y >= 0 && x < board.GetLength(0) && y < board.GetLength(1)) {
                    if ((board[x, y] & 1) == 1) {
                        liveCount++;
                    }
                }
            }
        }
        
        if ((board[i, j] & 1) == 1) {
            if (liveCount == 2 || liveCount == 3) {
                board[i, j] += 2;
            } // die, do nothing.
        } else {
            board[i,j] = liveCount == 3 ? 2 : 0;
        }
    }
}
```
