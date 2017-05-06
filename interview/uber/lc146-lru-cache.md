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

A few things to note,

1. Be careful about the code. When there are variables like `node`, `node1` and `node2`, use the right ones. Recommend use
node, pre_node, next_node.
2. When parameter name and class variable have the same name, the parameter name always win because of the local scope.
    * we either use `this.` to specify which one to use
    * or, use a different variable name.
3. Use a better name like `MoveToHead`, `RemoveTail` etc. In my code, `head` is the oldest element.

```c#
public class LRUCache {

        private class Node {
            public int key;
            public int value;
            public Node pre;
            public Node next;

            public Node(int key, int value, Node pre, Node next) {
                this.key = key;
                this.value = value;
                this.pre = pre;
                this.next = next;
            }
        }

        Node head, tail;
        int count = 0;
        Dictionary<int, Node> dict;
        int size;

        public LRUCache(int capacity) {
            head = new Node(0, 0, null, null);
            tail = new Node(0, 0, null, null);
            head.next = tail;
            tail.pre = head;

            count = 0;

            dict = new Dictionary<int, Node>();
            size = capacity;
        }

        public int Get(int key) {
            if (dict.ContainsKey(key)) {
                // get result and move the node to last
                var node = dict[key];
                Remove(node);
                Add(node);
                return node.value;
            }
            else {
                return -1;
            }
        }

        public void Put(int key, int value) {
            if (dict.ContainsKey(key)) {
                // get result and move the node to last
                var node = dict[key];
                node.value = value;
                Remove(node);
                Add(node);
            }
            else {
                var node = new Node(key, value, null, null);
                if (count == size) {
                    dict.Remove(head.next.key);
                    Remove(head.next); // remove oldest                
                }
                else count++;

                Add(node);
                dict[key] = node;
            }
        }

        private void Add(Node node) {
            var lastNode = tail.pre;
            lastNode.next = node;
            node.pre = lastNode;
            node.next = tail;
            tail.pre = node;
        }

        private void Remove(Node node) {
            var node1 = node.pre;
            var node2 = node.next;
            node1.next = node2;
            node2.pre = node1;
        }
    }
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
