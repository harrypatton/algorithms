[Source](https://leetcode.com/problems/binary-search-tree-iterator/#/description)
173. Binary Search Tree Iterator

It is easy to write down the code. I don't think it is easy to use recursion here though.

Should have written a helper to do the PushAll code.

```csharp
/**
 * Definition for binary tree
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class BSTIterator {

    private Stack<TreeNode> stack;
    
    public BSTIterator(TreeNode root) {
        stack = new Stack<TreeNode>();
        while(root != null) {
            stack.Push(root);
            root = root.left;
        }
    }

    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return stack.Count > 0;
    }

    /** @return the next smallest number */
    public int Next() {
        var node = stack.Pop();
        int value = node.val;
        
        node = node.right;
        while(node != null) {
            stack.Push(node);
            node = node.left;
        }
        
        return value;
    }
}

/**
 * Your BSTIterator will be called like this:
 * BSTIterator i = new BSTIterator(root);
 * while (i.HasNext()) v[f()] = i.Next();
 */
```
