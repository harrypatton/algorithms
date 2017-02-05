#450 - Delete Node in a BST
source: https://leetcode.com/problems/delete-node-in-a-bst/

Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.

Two steps,

1. find the node with `k` value
2. delete the node

##Idea
1. Find the key. 3 options: found, go to left or right. It doesn't need recursion. We can use while loop to find the key until found.
2. deletion
	* if it is a leaf node, just delete it.
	* else if it has left child, find the `most right node` in left tree. `most right node` doesn't have right child for sure.
		* if `most right node` doesn't have left node, just replace the deleted node.
		* if it has left node, the parent node can set the `left child node` as new `right` node.
	* when it has right child, find the most left node.
* else (i.e., it has right child), find the `most left node` in right tree. `most left node` doesn't have left child for sure.
 		* if `most left node` doesn't have right node, just replace the deleted node.
		* if it has right node, the parent node can set the `right child node` as new `left` node.
3. To remove a node, we need to keep both current and parent node references.

Complexity:
* Time: O(height)
* Space: O(1)

**Update**: my solution is too complicated and failed on edge cases. Discussion page shows an [easy-to-understand solution using recursion](https://discuss.leetcode.com/topic/65792/recursive-easy-to-understand-java-solution).
