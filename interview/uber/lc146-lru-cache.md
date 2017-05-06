Source: https://leetcode.com/problems/lru-cache/#/description

Design and implement a data structure for `Least Recently Used (LRU) cache`. It should support the following operations: `get` and `put`.

* `get(key)` - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
* `put(key, value)` - Set or insert the value if the key is not already present. 
When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

# Analysis
1. It is a queue data structure so we can use array, linked list or queue. 
2. To achieve constant time complexity, linked list is the best choice for add to first, remove any node.
for `get` scenario which is a random access, it needs another helper data structure hash table.

## New Code with its own linked list implementation
This is to reduce complexity using built-in linked list. Please note that there're empty nodes header and tailer. They're used to 
reduce code complexity.

```c#
```

## Original Code
I use C# built-in LinkedList type to do the work; however, the coding is not smooth because I'm unfamiliar with that class.
I would rather use my own linked list type.

```c#
public class LRUCache {
    
    private LinkedList<KeyValuePair<int, int>> list;
    private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> dict;
    private int size;

    public LRUCache(int capacity) {
        list = new LinkedList<KeyValuePair<int, int>>();
        dict = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
        size = capacity;
    }
    
    public int Get(int key) {
        if (dict.ContainsKey(key)) {
            MoveToFirst(dict[key]);
            return dict[key].Value.Value;
        } else {
            return -1;
        }
    }
    
    public void Put(int key, int value) {
        if (dict.ContainsKey(key)) {
            dict[key].Value = new KeyValuePair<int, int>(key, value);
            MoveToFirst(dict[key]);
        } else {
            if(dict.Count == size) {
                var last = list.Last();
                list.RemoveLast();
                dict.Remove(last.Key);
            }
            
            var node = list.AddFirst(new KeyValuePair<int, int>(key, value));
            dict[key] = node;
        }
    }
    
    private void MoveToFirst(LinkedListNode<KeyValuePair<int, int>> node) {
        list.Remove(node);
        list.AddFirst(node);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
```
