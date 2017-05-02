
```c#
/*
Given a non-empty binary search tree and a target value, find the value in the BST that is closest to the target.

Note:

Given target value is a floating point.
You are guaranteed to have only one unique value in the BST that is closest to the target.

Solution:
1. if root.value == target, use root.
2. if root.value > target, go to left tree, call the function and compare with root.
3. if root.value < target, to to right tree, call the function and compare with root.
4. need to handle null cases.

time: O(logn)
*/

public int closestValue(TreeNode root, double target) {
    int a = root.val;
    TreeNode kid = target < a ? root.left : root.right;
    if (kid == null) return a;
    int b = closestValue(kid, target);
    return Math.abs(a - target) < Math.abs(b - target) ? a : b;
}
```

```c++
class Solution {
public:
    int closestValue(TreeNode* root, double target) {
        int res = root->val;
        while (root) {
            if (abs(res - target) >= abs(root->val - target)) {
                res = root->val;
            }
            root = target < root->val ? root->left : root->right;
        }
        return res;
    }
};
```

```c#
public class Solution_Logn {
    public TreeNode GetClosest(TreeNode root, double target) {
        if (root.val == target) return root;
        
        if (root.val > target) {
            if (root.left == null) return root;
            var node = GetCloest(root.left, target);
            return (Math.Abs(node.val - target) - Math.Abs(root.val - target)) > 0 ? root : node;
        } else {
            if (root.right == null) return root;
            var node = GetCloest(root.right, target);
            return (Math.Abs(node.val - target) - Math.Abs(root.val - target)) > 0 ? root : node;
        }
    }
}

// O(n) solution. bad.
public class Solution_n {
    public TreeNode GetClosest(TreeNode root, double target) {
        if (root == null) return null;
        
        TreeNode left = GetClosest(root.left, target);
        TreeNode right = GetClosest(root.right, target);
        var result = GetCandidate(left, right);
        result = GetCandidate(result, root);
        
        return result;
    }
    
    private TreeNode GetCandidate(TreeNode node1, TreeNode node2, double target) {
        if (node1 == null) return node2;
        if (node2 == null) return node1;
        
        return (Math.Abs(node1.val - target) - Math.Abs(node2.val - target)) > 0 ? node2 : node1;
    }
}

```
