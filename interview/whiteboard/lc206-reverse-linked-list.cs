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
