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
    public bool IsBalanced(TreeNode root) {
        int depth;
        return IsBalanced(root, out depth);
    }
    
    public bool IsBalanced(TreeNode node, out int depth) {
        depth = 0;
        if (node == null) {
            return true;
        } else {
            int leftTreeDepth, rightTreeDepth;
            
            if (IsBalanced(node.left, out leftTreeDepth) && IsBalanced(node.right, out rightTreeDepth)) {
                depth = Math.Max(leftTreeDepth, rightTreeDepth) + 1;
                return Math.Abs(leftTreeDepth - rightTreeDepth) <= 1;
            } else {
                return false;
            }
        }
    }
}
