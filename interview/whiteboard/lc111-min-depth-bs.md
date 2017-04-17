Solution: https://leetcode.com/problems/minimum-depth-of-binary-tree/#/solutions

Given a binary tree, find its minimum depth.

The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

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
public class Solution {
    public int MinDepth_Solution1(TreeNode root) {
        if (root == null) return 0;
        if (root.left == null && root.right == null) return 1;
        
        return 1 + Math.Min(
                root.left != null ? MinDepth(root.left) : int.MaxValue, 
                root.right != null ? MinDepth(root.right) : int.MaxValue);        
    }
    
    public int MinDepth(TreeNode root) {
        if (root == null) return 0;
        var left = MinDepth(root.right);
        var right = MinDepth(root.left);
        
        return (left == 0 || right == 0) ? 1 + left + right : 1 + Math.Min(left, right);
    }
}
```
