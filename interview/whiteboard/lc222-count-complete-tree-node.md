# LC222. Count Complete Tree Nodes
Source: https://leetcode.com/problems/count-complete-tree-nodes/#/description

Given a complete binary tree, count the number of nodes.

Definition of a complete binary tree from Wikipedia:
In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.

## Analysis
1. The key is to find depth of two important nodes.
2. It could be the far left node in the whole tree and the far right node in left-subtree.
3. The latter could be the far left node in right sub-tree.
4. If both heights are difference, we know count of right sub-tree and use recursion to calcuate the left sub-tree;
5. if both are equal, we can calculate count of left sub-tree and recursively call right sub-tree.
6. There is an issue when I designed the solution but realized the issue while coding. I was using far left and far right node in original version and it is wrong.

**Update**: discussion page has nicer code for recursion and also iterative solutions.

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
    public int CountNodes(TreeNode root) {
        if (root == null) {
            return 0;
        } else if (root.left == null && root.right == null) {
            return 1;
        } else {
            int leftHeight = 0;
            var tempNode = root;
            while(tempNode != null) {
                leftHeight++;
                tempNode = tempNode.left;
            }
            
            int rightLeftHeight = 1;
            tempNode = root.right;
            while(tempNode != null) {
                rightLeftHeight++;
                tempNode = tempNode.left;
            }
            
            if (leftHeight == rightLeftHeight) {
                return (int)(Math.Pow(2, leftHeight - 1)) + CountNodes(root.right);
            } else {
                return CountNodes(root.left) + (int)(Math.Pow(2, leftHeight - 2));
            }
        }
    }
}
```
