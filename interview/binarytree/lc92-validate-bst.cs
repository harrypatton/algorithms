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
