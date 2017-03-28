[Source](https://leetcode.com/problems/diameter-of-binary-tree/#/description)

Given a binary tree, you need to compute the length of the diameter of the tree. The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

Although the problem is marked as easy, I found it is interesting.

1. In regular recursion, the time is O(nlogn). check post here: https://discuss.leetcode.com/topic/83653/java-easy-to-understand-solution
2. Below the DFS way to get O(n) solution. Very smart.

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
    private int max = 0;
    
    public int DiameterOfBinaryTree(TreeNode root) {
        GetMaxDepth(root);
        return max;
    }
    
    public int GetMaxDepth(TreeNode node) {
        if (node == null) {
            return 0;
        }
        
        int leftTreeDepth = GetMaxDepth(node.left);
        int rightTreeDepth = GetMaxDepth(node.right);
        max = Math.Max(max, leftTreeDepth + rightTreeDepth);
        
        return Math.Max(leftTreeDepth, rightTreeDepth) + 1;
    }
}
```
