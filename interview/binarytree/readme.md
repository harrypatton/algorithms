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
