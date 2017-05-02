Source: https://leetcode.com/problems/course-schedule/#/description

I learned new algorithm from this question. Very interesting.

There are a total of n courses you have to take, labeled from 0 to n - 1.

Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]

Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?

For example:
```
2, [[1,0]]
There are a total of 2 courses to take. To take course 1 you should have finished course 0. So it is possible.
```
```
2, [[1,0],[0,1]]
There are a total of 2 courses to take. To take course 1 you should have finished course 0, 
and to take course 0 you should also have finished course 1. So it is impossible.
```

# Analysis
topological order - no cycle when BFS.

```c#
/*
topological order.
*/
public class Solution {
    public bool CanFinish(int numCourses, int[,] prerequisites) {
        var dict = new HashSet<int>[numCourses];;
        var degree = new Dictionary<int, int>();
        
        // init degree
        for(int i = 0; i < numCourses; i++) {
            degree[i] = 0;
        }
        
        // populate the dependency
        for(int i = 0; i < prerequisites.GetLength(0); i++) {
            var j = prerequisites[i, 1];
            var k = prerequisites[i, 0];
            if (dict[j] == null) {
                dict[j] = new HashSet<int>();
            }
            
            dict[j].Add(k);
            degree[k]++;
        }
        
        // init the queue
        var q = new Queue<int>();
        foreach(var key in degree.Keys) {
            if (degree[key] == 0) q.Enqueue(key);
        }
        
        int count = 0;
        while(q.Count > 0) {
            var key = q.Dequeue();
            count++;
            
            if (dict[key] == null) continue; // course without dependency
            
            foreach(var val in dict[key]) {
                degree[val]--;               
                if (degree[val] == 0) q.Enqueue(val);
            }
        }
        
        return count == numCourses;
    }
}
```
