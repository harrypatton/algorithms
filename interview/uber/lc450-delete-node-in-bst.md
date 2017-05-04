source: https://leetcode.com/problems/delete-node-in-a-bst/#/description

Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.

Basically, the deletion can be divided into two stages:

* Search for a node to remove.
* If the node is found, delete the node.

**Note**: Time complexity should be O(height of tree).

## Update
My code is crappy. Although it passed OJ, it is hard to follow and complicated. Here're two solutions from discussion page,

### Solution 1 - I don't like the way it exchanges the node value, but it is very clean.

```java
public TreeNode deleteNode(TreeNode root, int key) {
    if(root == null){
        return null;
    }
    if(key < root.val){
        root.left = deleteNode(root.left, key);
    }else if(key > root.val){
        root.right = deleteNode(root.right, key);
    }else{
        if(root.left == null){
            return root.right;
        }else if(root.right == null){
            return root.left;
        }
        
        TreeNode minNode = findMin(root.right);
        root.val = minNode.val;
        root.right = deleteNode(root.right, root.val);
    }
    return root;
}

private TreeNode findMin(TreeNode node){
    while(node.left != null){
        node = node.left;
    }
    return node;
}
```

### Solution 2 - very clean code and exchange the node instead of value

```java
 public TreeNode deleteNode(TreeNode root, int key) {
        if (root == null) return null;
        
        if (root.val > key) {
            root.left = deleteNode(root.left, key);
        } else if (root.val < key) {
            root.right = deleteNode(root.right, key);
        } else {
            if (root.left == null) return root.right;
            if (root.right == null) return root.left;
            
            TreeNode rightSmallest = root.right;
            while (rightSmallest.left != null) rightSmallest = rightSmallest.left;
            rightSmallest.left = root.left;
            return root.right;
        }
        return root;
    }
```

## My Code (Crappy)
```c#
public class Solution {
    public TreeNode DeleteNode(TreeNode root, int key) {
        // delete empty node or the leaf
        if ((root == null) || (root.val == key && root.left == null && root.right == null)) return null;

        TreeNode parent = null;
        var deletedNode = FindNode(root, key, ref parent);
        if (deletedNode == null) return root; // not found.

        // find candidate
        TreeNode candidate = null;
        if (deletedNode.left != null) {
            candidate = deletedNode.left;
            while (candidate.right != null) candidate = candidate.right;
        } else if (deletedNode.right != null) {
            candidate = deletedNode.right;
            while (candidate.left != null) candidate = candidate.left;
        }

        if (candidate != null) DeleteNode(deletedNode, candidate.val);

        // update parent link
        if (parent != null) {
            if (parent.left == deletedNode) parent.left = candidate;
            else parent.right = candidate;
        }        

        // update children link
        if (candidate != null) {
            candidate.left = deletedNode.left;
            candidate.right = deletedNode.right;
        }        

        return deletedNode == root ? candidate : root;
    }

    public TreeNode FindNode(TreeNode root, int key, ref TreeNode parent) {
        if (root.val == key) return root;
        TreeNode node = null;
        
        if (root.left != null) {
            parent = root;
            node = FindNode(root.left, key, ref parent);
        }

        if (node == null && root.right != null) {
            parent = root;
            node = FindNode(root.right, key, ref parent);
        }

        return node;
    }
}
```
