[Source](https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/#/description)

Given a binary tree, return the zigzag level order traversal of its nodes' values. (ie, from left to right, then right to left for the next level and alternate between).

## Analysis
It is easy to come up with the solution. When write code, just be careful and make sure no bug. I'm very close to that level today. 

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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if (root == null) {
            return result;
        }
        
        bool leftFirst = true;
        var stack1 = new Stack<TreeNode>();
        var stack2 = new Stack<TreeNode>();        
        stack1.Push(root);
        
        while(stack1.Count > 0) {
            var list = new List<int>();
            
            while(stack1.Count > 0) {
                var node = stack1.Pop();
                list.Add(node.val);
                
                var node1 = leftFirst ? node.left : node.right;
                var node2 = leftFirst ? node.right : node.left;
                
                if (node1 != null) stack2.Push(node1);
                if (node2 != null) stack2.Push(node2);
            }
            
            result.Add(list);
            leftFirst = !leftFirst;
            var temp = stack1;
            stack1 = stack2;
            stack2 = temp;
        }
        
        return result;
    }
}
```
