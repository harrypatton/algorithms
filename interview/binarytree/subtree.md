# Check if a BS is a subtree of another BS
source

* http://www.geeksforgeeks.org/check-if-a-binary-tree-is-subtree-of-another-binary-tree/
* http://www.geeksforgeeks.org/check-binary-tree-subtree-another-binary-tree-set-2/

## Analysis
1. A subtree of a tree T is a tree S consisting of `a node in T` and `all of its descendants in T`. When I first work on the problem, I thought a sub-tree is part of the tree, which means it doesn't have all of its descendants, say, a->b->c. a->b is a sub-tree, but b itself is not because it doesn't have b's decendant's c.
2. It is easy to write down the recursion algorithm. It is O(n*m).

# If you are given two traversal sequences, can you construct the binary tree?
this is a good article and picture. http://www.geeksforgeeks.org/if-you-are-given-two-traversal-sequences-can-you-construct-the-binary-tree/

Two trees in the diagram have the same pre-order, post-order and level-order value.

![alt text](http://d1hyf4ir1gqw6c.cloudfront.net//wp-content/uploads/2009/06/Mirror.GIF)
