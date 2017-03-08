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
    public IList<string> BinaryTreePaths(TreeNode root) {
        var result = new List<string>();
        BinaryTreePaths(root, result, string.Empty);
        return result;
    }
    
    public void BinaryTreePaths(TreeNode root, IList<string> result, string path) {
        if (root == null) {
            return;
        }
        
        string newPath = (path == string.Empty ? path : path + "->") + root.val.ToString();
        if (root.left == null && root.right == null) {            
            result.Add(newPath);
            return;
        }
        
        BinaryTreePaths(root.left, result, newPath);
        BinaryTreePaths(root.right, result, newPath);
    }
}
