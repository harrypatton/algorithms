source: https://leetcode.com/problems/insert-delete-getrandom-o1/#/solutions

Design a data structure that supports all following operations in average O(1) time.

1. `insert(val)`: Inserts an item val to the set if not already present.
2. `remove(val)`: Removes an item val from the set if present.
3. `getRandom`: Returns a random element from current set of elements. Each element must have the same probability of being returned.

## Analysis
1. To get constant time for Add and Remove, we can use either `HashSet` or `Dictionary`.
2. To get constant time for getRandom, we have to use an array-like data structure, e.g., List.
3. However, list is tricky to remove an element in O(1). What if we know the position of removed element? We can use Dictionary from #1
to store the index. When remove the element, we just swap it with last element. Removing last element in list is O(1).

```c#
public class RandomizedSet {
    private Dictionary<int, int> dict = new Dictionary<int, int>();
    List<int> list = new List<int>();
    Random r = new Random();

    /** Initialize your data structure here. */
    public RandomizedSet() {
        
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if(dict.ContainsKey(val)) return false;
        dict[val] = list.Count;
        list.Add(val);
        return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if(!dict.ContainsKey(val)) return false;
        
        var index = dict[val];
        dict.Remove(val);
        
        // swap with last element
        // be careful about the edge case: we may remove the last element here.
        if (index == list.Count - 1) {
            list.RemoveAt(list.Count - 1);
        } else {
            var temp = list[index];
            list[index] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            
            // need to update new position for previously last element
            dict[list[index]] = index;
        }
        
        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        var index = r.Next(0, list.Count);
        return list[index];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
```
