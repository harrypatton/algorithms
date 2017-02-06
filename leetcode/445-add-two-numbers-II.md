#445 - Add Two Numbers II
Source: https://leetcode.com/problems/add-two-numbers-ii/?tab=Solutions

You are given two non-empty linked lists representing two non-negative integers. The most significant digit comes first and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

**Follow up**:
What if you cannot modify the input lists? In other words, reversing the lists is not allowed.

Example:
```
Input: (7 -> 2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 8 -> 0 -> 7
```

## Ideas
### Reverse
Usually we calculate from the least significant digit and adds up; however, the link list comes first with most significant digit. We can reverse the link list, do the calculation and reverse back.

**Unfortunately** this problem doesn't allow to modify the input lists.

### Solution - brutal force
1. Iterate over two lists and calculate the counts.
2. Once we have the count, we know the bit position; however, it is hard to handle overflow (i.e., the left bit needs to add 1 because the next right addition >= 10).

Technically we can clone input links and modify them but it still violates the requirement essentially.

Although we cannot modify input lists, we can update result list.
1. copy two lists in reverse order to the result list.
2. maintain two pointers to each integer.
3. do the calculation. 
4. reverse it again.

(I feel it still uses cloned input links).

### Solution - stack
Discussion page shows a solution with stack. It means, to calculate the result, we need reverse the list in some way. When talk about reversing, stack is the perfect data structure.

##Learning
1. Compared with the discussion page, my solution has a lot of places to optimize. Too many conditions that we can combine and make the code concise. **I love reading code from other people :)**
