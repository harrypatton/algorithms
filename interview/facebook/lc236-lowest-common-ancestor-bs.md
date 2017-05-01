Source: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/#/description

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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || root == p || root == q) return root;
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        
        if (left != null && right != null) return root;
        else if (left != null) return left;
        else if (right != null) return right;
        
        return null;
    }
}
```
