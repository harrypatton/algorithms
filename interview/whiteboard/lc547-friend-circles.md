source: https://leetcode.com/problems/friend-circles/#/description

```csharp
public class Solution {        
    public int FindCircleNum(int[,] M) {
        var visited = new bool[M.GetLength(0)];
        int count = 0;

        for(int i = 0; i < M.GetLength(0); i++) {
            if (!visited[i]) {
                visited[i] = true;
                count++;
            }

            var queue = new Queue<int>();
            queue.Enqueue(i);

            while(queue.Count > 0) {
                int x = queue.Dequeue();

                for (int j = 0; j < M.GetLength(1); j++) {
                    if (!visited[j] && M[x, j] == 1) {
                        visited[j] = true;
                        queue.Enqueue(j);
                    }
                }

                for (int j = 0; j < M.GetLength(0); j++) {
                    if (!visited[j] && M[j, x] == 1) {
                        visited[j] = true;
                        queue.Enqueue(j);
                    }
                }
            }                
        }

        return count;
    }
}
```
