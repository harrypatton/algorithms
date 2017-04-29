Source: https://discuss.leetcode.com/topic/31954/5ms-java-clean-solution

![Image of Yaktocat](https://drscdn.500px.org/photo/135826875/m%3D900/7e1d9c2bdc47791e3b54f25bf50b6370)

The question is locked so I have to check the discussion page.

# Analysis
1. One way is to create a big 2d array. Row count is tree depth `h` and the column count is `2^(h-1)`. Use BFS to put every tree node.
After that, scan 2d from left to right.
2. Pre-order, in-order or post-order doesn't help. It seems that we need to sort it in some way. The 3 order traversal can give us an array
 and we need to sort it (based on what?). Depth and the column index. Column index is primary key and then check depth. How to get depth 
 and column index? We can use in-order traversal and use new class to include node, row index (i.e., depth) and column index.
3. discussion page has a simpler solution to handle list using dictionary though. It uses two queue lists to avoid additional class; but it should be the same.
 
# Update
1. Apparently when I did the question the second time, I found a better solution with O(n). The previous solution with OrderedNodeList is actually O(nlogn) due to the sorting.

## New Code
```c#
/**
 * Definition for binary tree
 * class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) {this.val = x; this.left = this.right = null;}
 * }
 */

/*
1. When use BFS, we can gurantee the order on vertical.
2. We need a way to check the column index so it is better to use another data structure to track it.
3. Maintain a hash table so that key is column index and value is the list. Because of BFS, we just add to the end.
4. Convert hash table value to List<List<int>>
*/

class NewTreeNode {
    public TreeNode node;
    public int column;
    public NewTreeNode (TreeNode n, int c) {
        node = n;
        column = c;
    }
}

class Solution {
    public List<List<int>> verticalOrderTraversal(TreeNode A) {
        if (A == null) return new List<List<int>>();
        
        var result = new Dictionary<int, List<int>>();
        var q = new Queue<NewTreeNode>();
        q.Enqueue(new NewTreeNode(A, 0));
        int minColumn = int.MaxValue;
        int maxColumn = int.MinValue;
        
        while(q.Count > 0) {
            var n = q.Dequeue();
            
            minColumn = Math.Min(minColumn, n.column);
            maxColumn = Math.Max(maxColumn, n.column);
            
            if(!result.ContainsKey(n.column)) result[n.column] = new List<int>();
            result[n.column].Add(n.node.val);
            
            if(n.node.left != null) q.Enqueue(new NewTreeNode(n.node.left, n.column - 1));
            if(n.node.right != null) q.Enqueue(new NewTreeNode(n.node.right, n.column + 1));
        }
        
        var list = new List<List<int>>();
        for(int i = minColumn; i <= maxColumn; i++) {
            if(result.ContainsKey(i)) list.Add(result[i]);
        }
        
        return list;
    }
}

```

## Old Code
 ```csharp
 public class OrderedTreeNode {
    public TreeNode node;
    public int rowIndex;
    public int columnIndex;
}

public List<List<int>> VerticalOrder(TreeNode root) {
    var orderedNodeList = new List<OrderedTreeNode>();
    Traverse(IList<OrderedTreeNode> orderedNodeList, root, 0, 0);
    
    orderedNodeList.Sort((item1, item2) => if (item1.columnIndex != item2.ColumnIndex) { return item1.columnIndex - item2.columnIndex; } else {item1.rowIndex - item2.rowIndex} );
    
    var result = new List<List<int>>();
    List<int> tempList = null;
    
    for(int i = 0; i < orderedNodeList.Count; i++) {
        if (i == 0 || orderedNodeList[i].columnIndex != orderedNodeList[i-1].columnIndex) {
            if (tempList != null) result.Add(tempList);            
            tempList = new List<int>();            
        }
        
        tempList.Add(orderedNodeList[i].val);
    }
    
    return result;
}

public List<List<Integer>> Traverse(IList<OrderedTreeNode> orderedNodeList, TreeNode node, int rowIndex, int columnIndex) {
    if (node == null) return;
    orderedNodeList.Add(new OrderedTreeNode(node, rowIndex, columnIndex));
    
    Traverse(orderedNodeList, node.left, rowIndex+1, columnIndex - 1);
    Traverse(orderedNodeList, node.right, rowIndex+1, columnIndex + 1);
}
 ```
