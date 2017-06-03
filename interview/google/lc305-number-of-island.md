Source: https://leetcode.com/problems/number-of-islands-ii/#/description

A 2d grid map of m rows and n columns is initially filled with water. We may perform an addLand operation which turns the water at position (row, col) into a land. Given a list of positions to operate, count the number of islands after each addLand operation. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.


## naive solution
1. first element go to a group.
2. add one. check if it is adjacent to any element in the group. O(k).
3. add one. go to a different group.
4. add one. it may connect multiple lands. this is the tricky one. O(k)

time complexity is O(k^2) using hashset. Unfortunately it is time out.

```c#
public class Solution_Naive {
    public struct Cell {
        public int x;
        public int y;
        public Cell(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }

    public IList<int> NumIslands2(int m, int n, int[,] positions) {
        var result = new List<int>();
        var groups = new List<HashSet<Cell>>();        

        for(int row = 0; row < positions.GetLength(0); row++) {
            var c = new Cell(positions[row, 0], positions[row, 1]);
            HashSet<Cell> currentGroup = null;
            var tempGroups = new List<HashSet<Cell>>();
            int merge = 0;

            foreach(var g in groups) {
                // at most merge 3 groups, because a point can connect at most 4 islands.
                // in this case, add the rest of them.
                if (merge == 3) {
                    tempGroups.Add(g);
                    continue;
                }

                bool connected = g.Contains(new Cell(c.x + 1, c.y))
                    || g.Contains(new Cell(c.x - 1, c.y))
                    || g.Contains(new Cell(c.x, c.y + 1))
                    || g.Contains(new Cell(c.x, c.y - 1));

                if (connected) {
                    if (currentGroup == null) currentGroup = g;
                    else {
                        currentGroup.UnionWith(g);
                        merge++;
                    }
                } else tempGroups.Add(g);
            }

            if (currentGroup == null) currentGroup = new HashSet<Cell>();
            currentGroup.Add(c);
            tempGroups.Add(currentGroup);

            groups = tempGroups;
            result.Add(groups.Count);
        }

        return result;
    }
}
```

## Union-find Solution
It uses union-find solution for `O(klogk)` performance. It is awesome. Check the discussion page for more details.

```c#
public class Solution {
    int[,] dirs = {{0, 1}, {1, 0}, {-1, 0}, {0, -1}};

    public IList<int> NumIslands2(int m, int n, int[,] positions) {
        List<int> result = new List<int>();
        if(m <= 0 || n <= 0) return result;

        int count = 0;                      // number of islands
        int[] roots = new int[m * n];       // one island = one tree
        for(int i = 0; i < roots.Length; i++) roots[i] = -1; // everything is water.

        for(int r = 0; r < positions.GetLength(0); r++) {
            int root = n * positions[r, 0] + positions[r, 1];     // assume new point is isolated island
            roots[root] = root;             // add new island
            count++;

            for(int row = 0; row < dirs.GetLength(0); row++) { // merge island
                int x = positions[r, 0] + dirs[row, 0]; 
                int y = positions[r, 1] + dirs[row, 1];
                int nb = n * x + y;
                if(x < 0 || x >= m || y < 0 || y >= n || roots[nb] == -1) continue;
                
                int rootNb = findIsland(roots, nb); // connected neighbor is found. find the root.
                if(root != rootNb) {        // if neighbor is in another island
                    roots[root] = rootNb;   // union two islands 
                    root = rootNb;          // current tree root = joined tree root
                    count--;               
                }
            }

            result.Add(count);
        }
        return result;
    }

    public int findIsland(int[] roots, int id) {
        while(id != roots[id]) id = roots[id];
        return id;
    }
}
```

## My own code using Union-Find
```c#
public class Solution {
    public IList<int> NumIslands2(int m, int n, int[,] positions) {
        var islands = new int[m*n];
        var map = new bool[m, n];
        var result = new List<int>();

        for(int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                islands[i * n + j] = i * n + j;
            }
        }

        var count = 0;
        var offsets = new int[,] {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};

        for(int i = 0; i < positions.GetLength(0); i++) {
            var x = positions[i, 0];
            var y = positions[i, 1];

            count++;
            map[x, y] = true;
            var root = FindRoot(x * n + y, islands);

            for(int j = 0; j < offsets.GetLength(0); j++) {
                var x1 = x + offsets[j, 0];
                var y1 = y + offsets[j, 1];
                if (x1 >= 0 && y1 >= 0 && x1 < m && y1 < n && map[x1, y1]) {
                    var newRoot = FindRoot(x1 * n + y1, islands);
                    if (root != newRoot) {                        
                        islands[root] = newRoot;
                        root = newRoot;
                        count--;
                    }
                }
            }

            result.Add(count);
        }

        return result;
    }

    public int FindRoot(int index, int[] islands) {
        while(islands[index] != index) index = islands[index];
        return index;
    }
}
```
