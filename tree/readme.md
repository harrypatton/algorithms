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

## CC4.2 Find if a route for two nodes on a directed graph
How to represent directed graph in data structure?

1. A node array and another array for edges.
2. Adjacent list - the list includes all nodes. Each node has a list to include node it can connect to.

`dfs` and `bfs` have the same efficiency for this problem. I choose `dfs` for simplicity. We can define a node class with 3 properties,

* value.
* bool visited.
* a list of neighbors.

## LC108 - Convert sorted array to min-height binary search tree
source: https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/?tab=Description

It is easy to recursion for the problem. The middle node becomes root, and the left partion becomes left-subtree and so does the right partition. I cannot any other readable solution.

**Result**: one time bug-free code passed on the system.

## CC4.4 Nodes from every level form a linked list.
1. use `bfs`
2. how to indicate each level? insert a null and then insert all elements from current level.
	* root level, root => null
	* when encounter a null value from queue, create an empty linked list and also add a null value to the queue. We also need to add previous linked list to the result (a list of linked list).
	* when encounter a non-null value from queue, add it to linked list and also add all its children to the queue.

**Update**: the book gives 2 interesting solutions. it is worth looking.

## CC4.5 Check if binary tree is a BST
1. recursion
	* from root node, verify left child <= node < right child.
	* verify both left sub-tree and right sub-tree are BST.
	* complexity: time O(n). space O(logn) due to recursion.
	* **Update**:  My solution has an issue. See examples like, `20 (10, 30), 10 (null, 25)`.  The book shows I missed critical conditions.
		* All left children must be <= node, so we need to track max value from left sub-tree.
		* All right children must be > node, so we need to track min value from right sub-tree.
		* `the book has a very nice solution `.
2. pre-order traversal
	* cannot save the result in an array due to space consumption.
	* the recursion method is always passed with previous element. For the first one, we can pass in `int.MinValue`. 
	* **update**: the book shows this solution doesn't solve the duplicate node scenarios.
