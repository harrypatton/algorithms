source: https://leetcode.com/problems/zigzag-iterator/#/description

Given two 1d vectors, implement an iterator to return their elements alternately. For example, given two 1d vectors:

```
v1 = [1, 2]
v2 = [3, 4, 5, 6]
```

By calling next repeatedly until hasNext returns false, the order of elements returned by next should be: `[1, 3, 2, 4, 5, 6]`.

**Follow up**: What if you are given k 1d vectors? How well can your code be extended to such cases?

The "Zigzag" order is not clearly defined and is ambiguous for k > 2 cases. 
If "Zigzag" does not look right to you, replace "Zigzag" with "Cyclic". For example, given the following input:
```
[1,2,3]
[4,5,6,7]
[8,9]
It should return [1,4,8,2,5,9,3,6,7].
```

## Analysis
1. if there are two lists, we can use two pointers. 
2. if there are k lists, we can maintain a list for all these lists. 
Use a variable to track current list. Use mod to go back to first one.
3. when use the list, it is better to use a linkedlist so removing cost is low.

### k-list scenario
```c#
public class ZigzagIterator {

	public class LinkedNode {
		public IList<int> list;
		public LinkedNode pre;
		public LinkedNode next;
		public int index;

		public LinkedNode(IList<int> list) {
			this.list = list;
			index = 0;
		}
	}

	private LinkedNode current;

    public ZigzagIterator(IList<int> v1, IList<int> v2) {
        foreach(IList<int> list in new IList<int>[] {v1, v2}) {
        	if (list != null && list.Count > 0) {
        		if (current == null) {
        			current = new LinkedNode(list);
        			current.pre = current;
        			current.next = current;
        		} else {
        			var node = new LinkedNode(list);
        			node.next = current.next;
        			current.next = node;
        			node.next.pre = node;
        			node.pre = current;
        			current = node;
        		}
        	}
        }

        if (current != null) current = current.next;
    }

    public bool HasNext() {
        return current != null;
    }

    public int Next() {    	
     	var result = current.list[current.index++];

     	// list is used up
     	if (current.index == current.list.Count) {
     		if (current.next == current) current = null;
     		else {
     			current.pre.next = current.next;
     			current.next.pre = current.pre;
     			current = current.next;
     		}
     	} else current = current.next;

     	return result;
    }
}

/**
 * Your ZigzagIterator will be called like this:
 * ZigzagIterator i = new ZigzagIterator(v1, v2);
 * while (i.HasNext()) v[f()] = i.Next();
 */
```

### 2-list scenario
```c#
public class ZigzagIterator {

	private int index1;
	private int index2;
	private IList<int> list1;
	private IList<int> list2;	

    public ZigzagIterator(IList<int> v1, IList<int> v2) {
        list1 = v1;
        if (list1 == null) list1 = new List<int>();

        list2 = v2;
        if (list2 == null) list2 = new List<int>();

        index1 = 0;
        index2 = 0;
    }

    public bool HasNext() {
        return index1 < list1.Count || index2 < list2.Count;
    }

    public int Next() {    	
     	if (index1 < list1.Count && index2 < list2.Count) {
     		return index1 == index2 ? list1[index1++] : list2[index2++];
     	} else if (index1 < list1.Count) return list1[index1++];
     	else return list2[index2++];
    }
}

/**
 * Your ZigzagIterator will be called like this:
 * ZigzagIterator i = new ZigzagIterator(v1, v2);
 * while (i.HasNext()) v[f()] = i.Next();
 */
```
