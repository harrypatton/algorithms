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
    private TreeNode kthNode = null;
    private int counter = 0;
    
    public int KthSmallest(TreeNode root, int k) {
        Traverse(root, k);
        return kthNode.val;
    }
    
    public void Traverse(TreeNode root, int k) {
        if (root == null) {
            return;
        }
        
        Traverse(root.left, k);
        
        counter++;
        if (counter == k) {
            kthNode = root;
            return;
        }
        
        Traverse(root.right, k);
    }
}
