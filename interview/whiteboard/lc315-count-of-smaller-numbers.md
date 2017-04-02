[Source](https://leetcode.com/problems/count-of-smaller-numbers-after-self/#/description)

You are given an integer array nums and you have to return a new counts array. The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i].

Example:
```
Given nums = [5, 2, 6, 1]

To the right of 5 there are 2 smaller elements (2 and 1).
To the right of 2 there is only 1 smaller element (1).
To the right of 6 there is 1 smaller element (1).
To the right of 1 there is 0 smaller element.
```
Return the array [2, 1, 1, 0].

## Analysis
This problem is very similar to the one that calculate how many inversion pair in an array. A modified merge sort works well.
During the merge, when we pick up right part of array, we know how to calculate the count.

A few things to note,

1. Merge sort has to use O(n) memory. In-place sorting is very hard to write.
2. It is ok to introduce a modified data structure. e.g., in this case, we use a class to store index and count.

## Code

```csharp
public class Solution {
    public class Node {
        public int index;
        public int val;
        public int count;
        public Node(int index, int value) {
            this.index = index;
            this.val = value;
            this.count = 0;
        }
    }
        
    public IList<int> CountSmaller(int[] nums) {
        var result = new List<int>();
        if (nums == null || nums.Length == 0) return result;
        
        var nodes = new Node[nums.Length];
        for(int i = 0; i < nodes.Length; i++) {
            nodes[i] = new Node(i, nums[i]);
        }
        
        nodes = MergeSort(nodes);
        Array.Sort(nodes, (item1, item2) => item1.index - item2.index);
        
        foreach(var node in nodes) {
            result.Add(node.count);
        }
        
        return result;
    }
    
    public Node[] MergeSort(Node[] nodes) {
        if (nodes == null || nodes.Length <= 1) return nodes;
        
        var nodes1 = new Node[nodes.Length / 2];
        var nodes2 = new Node[nodes.Length - nodes1.Length];
        Array.Copy(nodes, 0, nodes1, 0, nodes1.Length);
        Array.Copy(nodes, nodes1.Length, nodes2, 0, nodes2.Length);
        
        nodes1 = MergeSort(nodes1);
        nodes2 = MergeSort(nodes2);
        
        int count = 0;
        int index = 0;
        int i = 0;
        int j = 0;
        
        while (i < nodes1.Length || j < nodes2.Length) {
            if (i < nodes1.Length && j < nodes2.Length) {
                if (nodes1[i].val <= nodes2[j].val) {
                    nodes1[i].count += count;
                    nodes[index] =nodes1[i];
                    i++;
                } else {
                    count++;
                    nodes[index] = nodes2[j];
                    j++;
                }
                
                index++;
                continue;
            }
            
            while (i < nodes1.Length) {
                nodes1[i].count += count;
                nodes[index] =nodes1[i];
                i++;
                index++;
            }
            
            while (j < nodes2.Length) {
                nodes[index] = nodes2[j];
                j++;
                index++;
            }
        }
        
        return nodes;
    }
}
```
