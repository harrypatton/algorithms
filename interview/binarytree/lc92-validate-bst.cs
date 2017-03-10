/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution_InOrder {
    private TreeNode previous = null;
    private TreeNode current = null;
    
    public bool IsValidBST(TreeNode root) {
        try
        {
            TraverseBST(root);
            return true;
        }
        catch(ArgumentException ex) {
            return false;
        }
    }
    
    public void TraverseBST(TreeNode node) {
        if (node == null) {
            return;
        }
        
        TraverseBST(node.left);
        
        if (current == null) {
            current = node;
        } else {
            previous = current;
            current = node;

            if (previous.val >= current.val) {
                throw new ArgumentException();
            }
        }
        
        TraverseBST(node.right);
    }
}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution_Recursion {
    private TreeNode previous = null;
    private TreeNode current = null;
    
    public bool IsValidBST(TreeNode root) {
        int min, max;
        return IsValidBST(root, out min, out max);
    }
    
    public bool IsValidBST(TreeNode node, out int min, out int max) {
        min = 0;
        max = 0;
        
        if (node == null ) {
            min = int.MinValue;
            max = int.MaxValue;
            return true;
        }
        
        int left_min, left_max, right_min, right_max;
        if (IsValidBST(node.left, out left_min, out left_max) && IsValidBST(node.right, out right_min, out right_max)) {
            min = node.left == null ? node.val : left_min;
            max = node.right == null ? node.val : right_max;
            return (node.left == null || node.val > left_max) && (node.right == null || node.val < right_min);
        }
        
        return false;
    }
}
