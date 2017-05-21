source: https://leetcode.com/problems/binary-tree-longest-consecutive-sequence/#/description

Given a binary tree, find the length of the longest consecutive sequence path.

The path refers to any sequence of nodes from some starting node to any node in the tree along the parent-child connections. 
The longest consecutive path need to be from parent to child (cannot be the reverse).

e.g., the path is from parent to child. the value is more like 2, 3, 4, 5.

## Analysis
It is easy to think of recursion for tree question.

1. the path could be in left or right subtree. if the root and child form consecutive sequence, it becomes 3 options. 
  it needs two functions - current one and the one which find longest from current root. time complexity is big.
2. is there any better solution using only one recursion method?
  We can use DFS to pass in current path, parent value and update max path on the fly. time complexity: O(n).

## Code
```c#
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
	public int max = 1;

    public int LongestConsecutive(TreeNode root) {
    	if (root == null) return 0;
    	
        DFS(1, root.val, root.left);
        DFS(1, root.val, root.right);
        return max;
    }

    public void DFS(int path, int value, TreeNode node) {
    	if (node == null) return;

    	if (node.val == value + 1) {
    		path++;
    		max = Math.Max(max, path);
    	} else path = 1;

    	DFS(path, node.val, node.left);
    	DFS(path, node.val, node.right);
    }
}
```
