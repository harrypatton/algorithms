[Source](https://leetcode.com/problems/clone-graph/#/description)

Clone a graph. Label is unique so it is easy to handle. 

The following code has both BFS and DFS. (not easy to understand though).

Please remember to check input parameter. It was a shame that I forgot it in the first time. I should always stick to the analysis process:

* analysis.
* provide naive solution and optimal solution.
* talk about edge cases, base cases or formula. 
* write down simple pesudo code.
* write test case

```csharp
/**
 * Definition for undirected graph.
 * public class UndirectedGraphNode {
 *     public int label;
 *     public IList<UndirectedGraphNode> neighbors;
 *     public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
 * };
 */

// BFS solution
public class Solution {    
    
    public UndirectedGraphNode CloneGraph(UndirectedGraphNode node) {
        if (node == null) return null;
        
        var cloned = new Dictionary<int, UndirectedGraphNode>();
        cloned[node.label] = new UndirectedGraphNode(node.label);
        var queue = new Queue<UndirectedGraphNode>();
        
        queue.Enqueue(node);
        while(queue.Count > 0) {
            var n = queue.Dequeue();
            
            foreach(var neighbor in n.neighbors) {
                if (!cloned.ContainsKey(neighbor.label)) {
                    cloned[neighbor.label] = new UndirectedGraphNode(neighbor.label);
                    queue.Enqueue(neighbor);
                }
                
                cloned[n.label].neighbors.Add(cloned[neighbor.label]);
            }
        }
        
        return cloned[node.label];
    }
}

// DFS solution - easy to understand.
public class Solution_DFS {
    private Dictionary<int, UndirectedGraphNode> visited = new Dictionary<int, UndirectedGraphNode>();
    
    public UndirectedGraphNode CloneGraph(UndirectedGraphNode node) {
        if (node == null) return null;
        
        if (visited.ContainsKey(node.label)) {
            return visited[node.label];
        } else {
            var clonedNode = new UndirectedGraphNode(node.label);
            visited[node.label] = clonedNode;
            
            foreach(var n in node.neighbors) {
                clonedNode.neighbors.Add(CloneGraph(n));
            }
            
            return clonedNode;
        }
    }
}
```
