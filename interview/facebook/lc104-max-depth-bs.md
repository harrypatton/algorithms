source: https://leetcode.com/problems/maximum-depth-of-binary-tree/#/description

Given a binary tree, find its maximum depth.

The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

## Analysis
Check BFS and DFS solutions below. The DFS one code is very clean.

```c#
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution_BFS {
    public int MaxDepth(TreeNode root) {
        int level = 0;
        if (root == null) return level;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while(q.Count > 0) {
            level++;
            int count = q.Count;
            for(int i = 0; i < count; i++) {
                var node = q.Dequeue();
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }
        }
        
        return level;
    }
}

public class Solution_Simple {
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;
        return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
    }
}

public class Solution_Original {
    private int max = 0;
    
    public int MaxDepth(TreeNode root) {
        Traverse(root, 1);
        return max;
    }
    
    public void Traverse(TreeNode node, int depth) {
        if (node == null) return;
        max = Math.Max(max, depth);
        Traverse(node.left, depth+1);
        Traverse(node.right, depth+1);
    }
}
```
