# 331 - Verify Preorder Serialization of a Binary Tree

One way to serialize a binary tree is to use `pre-order traversal`. 

* When we encounter a non-null node, we record the node's value. 
* If it is a null node, we record using a sentinel value such as `#`.

Given a string in which integer or `#` are separated by comma, verify it is a valid binary tree.

## Analysis
1. we know the first letter is the root. If it is #, that's should be the only element in the string.
2. If second letter is #, the left tree is null.
	* if third letter is #, the right tree is null. It should be the last element.
	* if third letter is not #, the right tree is not null. We can recursively call the rest string.
3. If second letter is not #, the left tree is not null. Where does left tree end? Probably we should try every single substring.

## Solution
### Recursion
Base

1. If a string has only 1 char `#`, it is true.
2. if a string has 2 chars, it is false;
3. If a string has 3 chars, the first one is not `#` and the other two are `#`, it is true.

Iteration

1. if a string has more than 3 chars, the first char must not be `#`. Partition the rest arrays and check if both parts are valid.

**Update 1**: the above solution times out. I can add a memory cache for this DP, but is there any bottom-up solution?

### Stack based
Preorder uses a stack to traverse so we probably do that too. The idea is `2##` is a complete node. We can replace it with `#` and push back to stack.

1. if it is a number element, push to stack.
2. if it is #, we need to check if current peek is #. 
	* if yes, pop the element. pop again and verify it is a number element. Repeat this process.
	* Push the element.
3. If stack has only one #, it is true; otherwise false.

**Update**: this is an accepted solution but spend more space. `Time O(n) and space O(n)`.

### In-degree and out-degree
`Discussion Page` has a time O(n) and space O(1) solution using in-degree and out-degree. It is a little tricky to understand.

### leafNode = 1 + non-leafNode
Top topic in `Discussion Page` also shows another solution,

1. when treat # as leaf node, `leaf node = 1 + non-leaf node` because of the full-balance tree property.
2. scan the string, if the condition is meet, break the loop.
3. If we reach the end and also meet the condition, it is valid.

# 297 - Serialize and Deserialize Binary Tree
## Pre-order with parenthesis
I can use parenthesis for left and right sub trees. Here's a few example,

1. A single node 10, the string is 10.
2. A root node 10 with left 2 and right 5, the string is 10(2)(5)
3. A root node 10 with left 2 only. the string is 10(2)()
4. A root node 10 with right 5 only. the string is 10()(5)
5. A root node 10 with left 2 and right 7. Left 2 has left 3 and right 5. the string is 10(2(3)(5))(7)

Both ways can use recursion to do the work.

**Update**: my solution is accepted but not optimal. It has to keep scanning the string to find open/close brackets.

## Pre-order with full balance tree
This solution is from top #1 in discussion page. 

1. Use pre-order to traverse the tree. When node is null, use "x" as the string. I can use empty string here.
2. Each node is separated by a comma. 
3. When deserialize the string, it is interesting to know that it would stop when left-tree is complete. Continue to scan the rest of array, it would complete the right sub-tree.

In my solution, I use `ref` keyword with less readable. In `discussion page`, they use `queue` to avoid that issue, but `queue` itself is an overhead.

#Lowest Common Ancestor II
Source

* http://blog.gainlo.co/index.php/2016/07/06/lowest-common-ancestor/
* lc236: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/?tab=Description

*Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.*

According to the definition of LCA on Wikipedia: `The lowest common ancestor is defined between two nodes v and w as the lowest node in T that has both v and w as descendants (where we allow a node to be a descendant of itself).`

## Analysis
1. **compare node path** - given a node, it is easy to get the path up to root node. If we save two node paths in arrays and then compare from the end. The last common element is the LCA. Time O(logn) and space O(logn). 
	* what if tree node doesn't have a pointer to parent? We have to use backtracking to find the path. Time O(n). 
2. **in-order traversal**: if both nodes appear before the root, we know they're at left tree; if both nodes appear after the root, they're at right tree; otherwise the LCA is root node. We do exactly the same thing for sub-tree. Time complexity is O(n). 

**Update**: I need to rethink this problem. Cannot find a good way for now.

1. It turns out to be a simple solution but a little bit tricky.
2. It uses recursion here.
3. If the root and subtrees contains both nodes, it returns LCA.
4. If the root and subtrees contains only one of them, it returns the node.
5. if the root and subtrees don't contain any of the nodes, it returns null.
6. so the base is `if (root == null || root == node1 || root == node2), return root.`
7. After that, call the same function on left subtree and right subtree. If one of the result is null, we return the other result; if both are not null, it means each subtree has one of them, then root is the LCA.

# LC235 - Lowest Common Ancestor I
source: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree

The difference is we're given a BST (binary search tree).

## Analysis
The problem is much easier for BST. 

1. We can set a while loop when both nodes are greater than root or less than root.
	* if greater, set root to root.Right.
	* otherwise, set root to root.Left.
2. When exit the loop, current root value is the LCA. It should cover common scenarios and also edge scenairo like one of node is ancestor.

**Update**: my 4-line code accepted at once. cool!

# LC257 - Binary Tree Paths
source: https://leetcode.com/problems/binary-tree-paths/?tab=Description

The problem needs to get the node path for all leaf nodes.

## Analysis
1. **Recursion** (or DFS)
	* base: when current node is leaf node, add the result.
	* formula: scan left tree and then right tree. We need to pass a prefix path to every function call.
2. **Iterative** (or BFS): we need a queue to handle it. Seems complicated though. 

## Learning
1. when doing post-order traversal, remember it is very similar to pre-order. A mirror with some adjustment.
2. Be careful about the edge case like single element.
