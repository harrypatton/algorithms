# LC206 - Reverse Linked List
source: https://leetcode.com/problems/reverse-linked-list/#/description

The problem is very easy; however, I feel a little nervous when coding and talking. I cannot fully clear my mind on whiteboard. 

I started with recursion solution which is a little bit complicated. My code doesn't organize very well because of the `out` parameter. When I worked on next solution - iterative, it is much better. Probably because the solution itself is simpler. 

Iteration solution one-time pass; but recursion one has one bug in which I didn't set `tail` correctly on base case. It is not because I don't know; just because I'm a little nervous. 

This is my first time of whiteboard coding during preparation. I would say it is ok. Just need more practice.

``` c#
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // Solution #1 - Recursion way
    public ListNode ReverseList_Recursion(ListNode head) {
        ListNode tail;
        return ReverseList(head, out tail);
    }
    
    public ListNode ReverseList(ListNode node, out ListNode tail) {
        if (node == null || node.next == null) {
            tail = node;
            return node;
        } else {
            var nextNode = ReverseList(node.next, out tail);
            
            if (tail != null) {
                tail.next = node;
                node.next = null;
                tail = node;
            }
            
            return nextNode;
        }
    }
    
    // Solution #2 - Iteartive way
    public ListNode ReverseList(ListNode head) {
        ListNode newHead = null;
        while (head != null) {
            var tempNode = head;
            head = head.next;
            tempNode.next = newHead;
            newHead = tempNode;
        }
        
        return newHead;
    }
}

```
