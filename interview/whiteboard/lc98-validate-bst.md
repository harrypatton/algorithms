[Source](https://leetcode.com/problems/validate-binary-search-tree/#/description)

Check [discussion solution](https://discuss.leetcode.com/topic/4659/c-in-order-traversal-and-please-do-not-rely-on-buggy-int_max-int_min-solutions-any-more) (I also pasted the code below). It doesn't use the `cur` pointer because it is unnecessary, and check how concise the code is. I have a lot of things to learn.

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

```c++
class Solution {
public:
    bool isValidBST(TreeNode* root) {
        TreeNode* prev = NULL;
        return validate(root, prev);
    }
    bool validate(TreeNode* node, TreeNode* &prev) {
        if (node == NULL) return true;
        if (!validate(node->left, prev)) return false;
        if (prev != NULL && prev->val >= node->val) return false;
        prev = node;
        return validate(node->right, prev);
    }
};
```
