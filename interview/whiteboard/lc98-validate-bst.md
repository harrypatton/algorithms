[Source](https://leetcode.com/problems/validate-binary-search-tree/#/description)

```csharp
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
    private TreeNode pre = null;
    private TreeNode cur = null;
    
    public bool IsValidBST(TreeNode root) {
        if (root == null) return true;
        
        if (!IsValidBST(root.left)) return false;
        
        if (cur == null) {
            cur = root;
        } else {
            pre = cur;
            cur = root;
            if (pre.val >= cur.val) return false;
        }
        
        if (!IsValidBST(root.right)) return false;
        
        return true;
    }
}
```
