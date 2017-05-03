source: https://leetcode.com/problems/insert-delete-getrandom-o1-duplicates-allowed/#/description

# Analysis
1. The idea is very similar to LC380; however, it is design for collection which allows duplication. LC380 is a hashset which is much simpler.
2. The tricky code is in Remove. A few edge cases to consider.

```c#
public class RandomizedCollection {
    private Dictionary<int, HashSet<int>> dict = new Dictionary<int, HashSet<int>>();
    List<int> list = new List<int>();
    Random r = new Random();

    /** Initialize your data structure here. */
    public RandomizedCollection() {
        
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {        
        var result = !dict.ContainsKey(val);
        if (result) dict[val] = new HashSet<int>();        
        dict[val].Add(list.Count);
        list.Add(val);
        return result;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if(!dict.ContainsKey(val)) return false;
        
        var indexList = dict[val];        
        var index = indexList.First();
        
        if (index != list.Count - 1) { // we're not removing the last element
            if (list[index] == list[list.Count - 1]) { // remove the same element.
                index = list.Count - 1;
            } else {
                list[index] = list[list.Count - 1]; // swap with last element
                dict[list[index]].Remove(list.Count - 1);
                dict[list[index]].Add(index);
            }
        }
        
        list.RemoveAt(list.Count - 1); // remove from the list.        
        indexList.Remove(index); // remove the index list.
        if (indexList.Count == 0) dict.Remove(val);  // remove from the dictionary.

        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        var index = r.Next(0, list.Count);
        return list[index];
    }
}
```
