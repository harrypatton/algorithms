Source: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/#/description

## Analysis
Just use BST feature - check the value. See comment below. `Tricky thing`: the variable `p` doesn't mean a node in left sub-tree.
both `p` and `q` may swap position in the input. 

```c#
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || root == p || root == q) return root;
        
        if ((p.val < root.val && root.val < q.val) || (p.val > root.val && root.val > q.val)) return root;
        else if (p.val < root.val) return LowestCommonAncestor(root.left, p, q);
        else return LowestCommonAncestor(root.right, p, q);
    }
}
```

## Update
check the [discussion page](https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/#/solutions), the code is clean (awesome people).
