source: https://leetcode.com/problems/intersection-of-two-linked-lists/#/solutions

Write a program to find the node at which the intersection of two singly linked lists begins.

# Analysis
1. my solution is to find the length diff and then move one pointer ahead with the diff. After that, move two pointers together.
2. discussion page shows a more interesting solution. check it out.

```csharp
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        var nodeA = headA;
        var nodeB = headB;
        int lengthA = 0;
        int lengthB = 0;
        
        while(nodeA != null && nodeA.next != null) {
            lengthA++;
            nodeA = nodeA.next;
        }
        
        while(nodeB != null && nodeB.next != null) {
            lengthB++;
            nodeB = nodeB.next;
        }
        
        if (nodeA == null || nodeA != nodeB) {
            return null;
        }
        
        var diff = Math.Abs(lengthA - lengthB);
        var nodeA = lengthA > lengthB ? headA : headB;
        var nodeB = lengthA > lengthB ? headB : headA;
        
        while (diff > 0) {
            nodeA = nodeA.next;
            diff --;
        }
        
        while (nodeA != nodeB) {
            nodeA = nodeA.next;
            nodeB = nodeB.next;
        }
        
        return nodeA;
    }
}
```
