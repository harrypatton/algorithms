#449 - Serialize and Deserialize BST
source: https://leetcode.com/problems/serialize-and-deserialize-bst/

1. BFS is easy to understand but it could consume a lot of memory.
2. DFS - it isn't stable - a string can be deserialized to different trees.

##BFS
the format I'm using is, `root(left)(right)`, e.g., 2(1)(3). The key thing is to find out left string and right string based on open/close parenthesis.

It is easy to write out the algorithm. 
