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

# Flatten a linked list
source: http://blog.gainlo.co/index.php/2016/06/12/flatten-a-linked-list/

*It is not a regular linked list. Each node has a next pointer and also a child pointer. Flat the list by levels.*

## Analysis
1. I seems a BFS traversal. 
2. We uses a queue for BFS.
3. Add the first element is queue.
4. While queue is not empty,
	* pop up the element and treat it as a queue head.
	* Scan the list and add them to linked list. 
	* During the iteration, if any element has child pointer, add to the queue.
5. Edge Cases: set null to all child pointers. The last element's next should be null.

##Learning
1. It is easy to come up with queue + BFS solution. Be careful about the edge case.
2. The source shows an in-place solution without using queue. very clever. 
