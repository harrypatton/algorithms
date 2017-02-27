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
    public TreeNode SortedArrayToBST(int[] nums) {
        if (nums == null) {
            return null;
        }
        
        return SortedArrayToBST(nums, 0, nums.Length - 1);
    }
    
    public TreeNode SortedArrayToBST(int[] nums, int start, int end) {
        if (nums == null || nums.Length == 0 || start > end) {
            return null;
        }
        
        int middle = start + (end - start) / 2;
        var node = new TreeNode(nums[middle]);
        node.left = SortedArrayToBST(nums, start, middle - 1);
        node.right = SortedArrayToBST(nums, middle+1, end);
        
        return node;
    }
}
