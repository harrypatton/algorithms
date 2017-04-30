Source: https://leetcode.com/problems/minimum-depth-of-binary-tree/#/description

Given a binary tree, find its minimum depth. The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

## Analysis
Check below code for both DFS and BFS solutions.
    
```c#
// BFS Solution
public class Solution {
    public int MinDepth(TreeNode root) {
        int level = 0;
        if (root == null) return level;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while(q.Count > 0) {
            level++;
            int count = q.Count;
            for(int i = 0; i < count; i++) {
                var node = q.Dequeue();
                if (node.left == null && node.right == null) return level;
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }
        }
        
        return level;
    }
}

// DFS Solution
public class Solution_DFS {
    public int MinDepth(TreeNode root) {
        if (root == null) return 0;
        
        if (root.left != null && root.right != null) {
            return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
        } else if (root.left != null) {
            return 1 + MinDepth(root.left);
        } else if (root.right != null) {
            return 1 + MinDepth(root.right);
        } else return 1;
    }
}
```
