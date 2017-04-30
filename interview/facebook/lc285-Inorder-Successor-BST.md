Source

* https://discuss.leetcode.com/category/355/inorder-successor-in-bst
* http://www.cnblogs.com/grandyang/p/5306162.html

Given a binary search tree and a node in it, find the in-order successor of that node in the BST.

Note: If the given node has no in-order successor in the tree, return null.

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
    
    if (node == p) {
        found = true;
    } else if (found) {
        result = node; 
        return;
    }
    
    Traverse(node.left);    
    if (result == null) Traverse(node.right);
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
