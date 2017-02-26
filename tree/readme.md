# Tree

Tree is an interesting data structure. 

## LC110 - Check if binary tree is balanced
source: https://leetcode.com/problems/balanced-binary-tree/?tab=Description

Verify if a binary tree is balanced. `Balance` means the depth diff between left and right sub-trees are not more than one.

Inituitive way is to use recursion.

1. Reuse the function to check if left sub-tree is balanced.
2. Reuse the function to check if right sub-tree is balanced.
3. Check depths of both sub-trees are within 1 diff. 
	* This is a tricky part. How to get depth information? The function needs to return both a bool and a depth value as well.

**Update**: discussion page shows a solution which is also O(n) but avoid using the out parameter. I use `out` because the function needs to return both bool and depth value. That solution returns depth value directly. If balanced, return real depth; otherwise return -1 as depth. 
