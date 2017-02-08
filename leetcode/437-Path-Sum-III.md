#437 - Path Sum III
source: https://leetcode.com/problems/path-sum-iii/

You are given a binary tree in which each node contains an integer value. Find the number of paths that sum to a given value.

The path does not need to start or end at the root or a leaf, but it must go downwards (traveling only from parent nodes to child nodes).

The tree has no more than 1,000 nodes and the values are in the range -1,000,000 to 1,000,000.

##Idea
Generally we can use recursion to handle tree related problems. In this case, it uses a top-down path so I guess we can also use backtrack then (but probably the same as recursion).

### Recursion
1. When current code value == sum, we found 1.
2. Recursive call left tree and right tree to find sum.
3. Recursive call left tree and right tree to find `sum - current.Val`. **Please note that #2 and #3 are different methods.**, I got caught in the first time:).
	* #2 can choose sub-path
	* #3 has to keep selecting root node because a node is already selected before calling and the path cannot be cut off. 

```
public class Solution {
    public int PathSum(TreeNode root, int sum) {
        if (root == null) {
            return 0;
        }
        
        return PathSumWithPrefix(root, sum) + PathSum(root.left, sum) + PathSum(root.right, sum);
    }
    
    private int PathSumWithPrefix(TreeNode root, int sum){
        if (root == null) {
            return 0;
        }
        
        return (root.val == sum ? 1 : 0) 
            + PathSumWithPrefix(root.left, sum - root.val)
            + PathSumWithPrefix(root.right, sum - root.val);
    }
}
```

### Backtrack
I thought about the idea and got clear when read the solution on discussion page,

1. Every path is top-down. 
2. Write a function that calculates how many paths that end with current node and its descendants have the target sum. There're some parameters below,
	* current node: the node we're calculating.
	* hash table: the sum of different paths from `tree root to current node's each ancestor`. 
	* target: the sum of path we're trying to find
	* sum: the sum of path from `tree root to current node's parent`. add current node value to sum so it becomes the `sum of tree root to current node`.
		* update hash table to include this path. `hash[sum]++ or hash[sum] = 1` depending on previous value.
		* if hash contains key `sum - target`, it means there's an ancestor that the sum of path between it and current node is `target`. Adding to the result.
		* call the same function for current node's left tree and right tree.
		* Update hash table to remove the path from tree root to current node; because it is going to calculate its sibling case.
