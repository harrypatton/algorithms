/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode list1, ListNode list2) {
        var stack1 = GetStack(list1);
        var stack2 = GetStack(list2);
        var header = new ListNode(0);
        
        while(stack1.Count != 0 || stack2.Count != 0) {
            var currentHeader = header;
            var sum = currentHeader.val;
            
            // The 3rd IF can combine with others
            // if (stack1.Count == 0) => add the result and end the if.
            // if (stack2.Count == 0) => add the result and end the if.
            // no more elses.
            if (stack1.Count == 0) {
                sum += stack2.Pop().val;
            } else if (stack2.Count == 0) {
                sum += stack1.Pop().val;
            } else {
                sum += stack1.Pop().val + stack2.Pop().val;
            }
            
            // currentHeader.val is always sum % 10 no matter we have overflow flag or not.
            // header statement can be replaced with ? operator.
            if (sum / 10 == 0) {
                currentHeader.val = sum;
                header = new ListNode(0);
            } else {
                currentHeader.val = sum % 10;
                header = new ListNode(1);                    
            }

            header.next = currentHeader;
        }
        
        if (header.val == 0) {
            header = header.next;
        }
        
        return header;
    }
    
    private Stack<ListNode> GetStack(ListNode list) {
        var stack = new Stack<ListNode>();
        
        while(list != null) {
            stack.Push(list);
            list = list.next;
        }
        
        return stack;
    }
}
