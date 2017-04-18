Source: https://leetcode.com/problems/merge-k-sorted-lists/#/description

Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.

Check how I implement MinHeap using List data structure.

```c#
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists == null) return null;
        
        var head = new ListNode(0);
        var current = head;
        var heap = new MinHeap();
        
        foreach(var node in lists) {
            if (node != null) heap.Add(node);
        }
        
        while(heap.Count > 0) {
            var node = heap.Pop();
            current.next = node;
            current = node;
            if (node.next != null) heap.Add(node.next);
        }
        
        current.next = null;
        return head.next;
    }
}

public class MinHeap {
    private List<ListNode> list = new List<ListNode>();
    
    public int Count {
        get {
            return list.Count;
        }
    }
    
    public void Add(ListNode node) {
        list.Add(node);
        int index = list.Count - 1;
        int parentIndex = (index - 1 ) / 2;
        
        while(parentIndex >= 0 && list[parentIndex].val > list[index].val) {
            Swap(parentIndex, index);
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }        
    }
    
    public ListNode Pop() {
        Swap(0, list.Count - 1);
        var node = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        Heapify(0);
        
        return node;
    }
    
    private void Heapify(int i) {
        var left = 2 * (i + 1) - 1;
        var right = left + 1;
        var min = i;

        // From wiki: Swap with its smaller child in a min-heap and its larger child in a max-heap.
        // If the node is already smallest, do nothing.
        if (left < list.Count && list[left].val < list[min].val) min = left;
        if (right < list.Count && list[right].val < list[min].val) min = right;

        if (i != min) {
            Swap(i, min);
            Heapify(min);
        }
    }
    
    private void Swap(int i, int j) {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
```
