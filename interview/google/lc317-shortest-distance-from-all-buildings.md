source: https://leetcode.com/problems/shortest-distance-from-all-buildings/#/description

You want to build a house on an empty land which reaches all buildings in the shortest amount of distance. You can only move up, down, left and right. You are given a 2D grid of values 0, 1 or 2, where:

Each 0 marks an empty land which you can pass by freely.
Each 1 marks a building which you cannot pass through.
Each 2 marks an obstacle which you cannot pass through.
For example, given three buildings at (0,0), (0,4), (2,2), and an obstacle at (0,2):

```
1 - 0 - 2 - 0 - 1
|   |   |   |   |
0 - 0 - 0 - 0 - 0
|   |   |   |   |
0 - 0 - 1 - 0 - 0
```

The point (1,2) is an ideal empty land to build a house, as the total travel distance of 3+3+1=7 is minimal. So return 7.

**Note:** There will be at least one building. If it is not possible to build such house according to the above rules, return -1.

## Analysis
without the obstacle, getting the path is easy.

* I feel it is a DP problem but not sure how to do that.
* I give up - no idea how to solve it.

After reading discussion page - it has a very easy solution BFS => instead of searching from empty land, I should start from buildings.
1. for every building, use BFS to update the distance for every '0' cell. save total buildings too.
2. after that, check all '0' cell for the smallest distance.

**Time complexity**: `m * n buildings`. Each BFS we scan m*n cells. Total is `O(m^2 * n^2)`.

```c#
public class Solution {
    private int[,] distance;
    private int[,] reachingBuilding;

    public struct P {
        public int i;
        public int j;
        public P(int i, int j) {
            this.i = i;
            this.j = j;
        }
    }

    public int ShortestDistance(int[,] grid) {
        int totalBuilding = 0;
        int result = int.MaxValue;

        // calculate distances for all buildings
        distance = new int[grid.GetLength(0), grid.GetLength(1)];
        reachingBuilding = new int[grid.GetLength(0), grid.GetLength(1)];
        for(int i = 0; i < grid.GetLength(0); i++) {
            for(int j = 0; j < grid.GetLength(1); j++) {
                if (grid[i, j] == 1) {
                    totalBuilding++;
                    BFS(grid, i, j);
                }
            }
        }

        // find the smallest one.
        for(int i = 0; i < grid.GetLength(0); i++) {
            for(int j = 0; j < grid.GetLength(1); j++) {
                if (grid[i, j] == 0 && reachingBuilding[i, j] == totalBuilding) {
                    result = Math.Min(result, distance[i, j]);
                }
            }
        }

        return result == int.MaxValue ? -1 : result;
    }

    private void BFS(int[,] grid, int i, int j) {
        var direction = new int[,] {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
        var visited = new HashSet<P>();
        var q = new Queue<P>();
        var start = new P(i, j);
        q.Enqueue(start);
        visited.Add(start);        
        int step = 0;        

        while(q.Count > 0) {
            int count = q.Count;
            step++;
            for(int k = 0; k < count; k++) {
                var p = q.Dequeue();

                // add candidates (only for empty land)
                for(int row = 0; row < direction.GetLength(0); row++) {
                    int x = p.i + direction[row, 0];
                    int y = p.j + direction[row, 1];
                    var child = new P(x, y);

                    if (x >= 0 && y >= 0 && x < grid.GetLength(0) && y < grid.GetLength(1)
                        && grid[x, y] == 0 
                        && !visited.Contains(child)) {

                        distance[x, y] += step; // update distance.
                        reachingBuilding[x,y]++;

                        q.Enqueue(child);
                        visited.Add(child);                        
                    }
                }
            }
        }
    }
}
```
