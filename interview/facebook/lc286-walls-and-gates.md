Source: 

* http://www.cnblogs.com/grandyang/p/5285868.html
* https://discuss.leetcode.com/category/358/walls-and-gates


You are given a m x n 2D grid initialized with these three possible values.

-1 - A wall or an obstacle.
0 - A gate.
INF - Infinity means an empty room. We use the value 231 - 1 = 2147483647 to represent INF as you may assume that the distance to a gate is less than 2147483647.
Fill each empty room with the distance to its nearest gate. If it is impossible to reach a gate, it should be filled with INF.

For example, given the 2D grid:
```
INF  -1  0  INF
INF INF INF  -1
INF  -1 INF  -1
  0  -1 INF INF
```
After running your function, the 2D grid should be:
```
  3  -1   0   1
  2   2   1  -1
  1  -1   2  -1
  0  -1   3   4
```

## Analysis

### DFS
1. Start with DFS for every gate.
2. Assume value for element i is n. Check the neighbors. If neighbor value > n + 1, replace it and start DFS on neighbor; otherwise, stop checking this neighbor. 

### BFS
1. Use a queue to add all gates.
2. Take one node from the queue. If neighbor value > n + 1, update it and add to queue.
3. Keep doing that until queue is empty.

[The source](http://www.cnblogs.com/grandyang/p/5285868.html) from `grandyang` has a good explaination on it.

## Update
1. Actually the leetcode discussion page prefer BFS because of the efficiency. In BFS, the condition becomes `neighbor.value == int.Max` and then add to queue. It makes sense if we think about BFS. It is level 0. If any node can reach the element, it must be the shortest. So it never has to update again after it becomes not int.Max. In production code, we should try iterative way and avoid recursion call.
