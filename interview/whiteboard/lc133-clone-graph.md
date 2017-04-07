[Source](https://leetcode.com/problems/clone-graph/#/description)

Clone a graph. Label is unique so it is easy to handle. 

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
public class Solution {
    private Dictionary<int, UndirectedGraphNode> clonedNodes = new Dictionary<int, UndirectedGraphNode>();
    
    public UndirectedGraphNode CloneGraph(UndirectedGraphNode node) {
        if (node == null) return node;
        
        if (!clonedNodes.ContainsKey(node.label)) {
            var clonedNode = new UndirectedGraphNode(node.label);
            clonedNodes[node.label] = clonedNode;
            
            foreach(var neighbor in node.neighbors) {
                clonedNode.neighbors.Add(CloneGraph(neighbor));
            }
        }
        
        return clonedNodes[node.label];
    }
}
```
