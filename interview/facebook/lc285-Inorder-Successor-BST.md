Source

* https://discuss.leetcode.com/category/355/inorder-successor-in-bst
* http://www.cnblogs.com/grandyang/p/5306162.html

Given a binary search tree and a node in it, find the in-order successor of that node in the BST.

Note: If the given node has no in-order successor in the tree, return null.

## Update
[4/30/2017] My solution is O(n); however, the discussion pages shows O(logn) solution which is very smart.

```java
public TreeNode successor(TreeNode root, TreeNode p) {
  if (root == null)
    return null;

  if (root.val <= p.val) {
    return successor(root.right, p);
  } else {
    TreeNode left = successor(root.left, p);
    return (left != null) ? left : root;
  }
}
```

```java
public TreeNode inorderSuccessor(TreeNode root, TreeNode p) {
    TreeNode succ = null;
    while (root != null) {
        if (p.val < root.val) {
            succ = root;
            root = root.left;
        }
        else
            root = root.right;
    }
    return succ;
}
```

## Recursion

```c#

private TreeNode result = null;
private bool found = false;

public TreeNode FindSuccessor_Recursion(TreeNode root, TreeNode p) {
    Traverse(root, p);
    return result;
}

public void Traverse(TreeNode node, TreeNode p) {
    if (node == null) return;
    
    Traverse(node.left);
    
    if (node == p) {
        found = true;
    } else if (found) {
        result = node; 
        return;
    }
    
    Traverse(node.right);
}
```

## Iteration
```c#
public TreeNode FindSuccessor_Iteration(TreeNode root, TreeNode p) {
    var q = new Queue<TreeNode>();
    AddToQueue(q, root);
    TreeNode result = null;
    
    while(q.Count > 0) {
        var node = q.Dequeue();
        AddToQueue(node);
        
        if (node == p) {
            result = q.Count > 0 ? q.Dequeue() : null;
            break;
        }
    }
    
    return result;
}

private void AddToQueue(Queue<TreeNode> q, TreeNode node) {
    if (node == null) return;
    
    while(node != null) {
        q.Enqueue(node);
        node = node.left;
    }
}
```
