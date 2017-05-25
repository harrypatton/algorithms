Source: https://leetcode.com/problems/top-k-frequent-elements/#/description

Given a non-empty array of integers, return the k most frequent elements.

For example,
`Given [1,1,1,2,2,3] and k = 2, return [1,2].`

Note: 
* You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
* Your algorithm's time complexity must be better than O(n log n), where n is the array's size.

## Analysis
Naive solution: 

1. use a hash table to calcuate count for each number.
2. sort it to get top K elements.

time complexity: O(nlogn) (due to the sorting).

optimization: during the sorting, we can use a mini heap to do that, so time complexity is O(nlogk).

### Note
1. Check the formula on how to calculate parent index. It should return negative one when current index is 0 so we know it is done. I.e.,
use `(i + 1) /2 - 1` instead of `(i - 1) / 2` which returns the same value except the root node. It would make hard to check if we reach the root.
2. Check out the Heapify method. Very important to remember that.

## Update
Check discussion page. It has an awesome bucket sort method. Declare an array of `List<int>`. The array length is the same as input array length. With hash table, use the Count as the array index and add the element to the list. When it is done. scan from the last to the first one.

## Code
```c#
public class Solution {    
    public class KeyCount {
        public int Key;
        public int Count;
        
        public KeyCount (int key, int count) {
            this.Key = key;
            this.Count = count;
        }
    }
    
    public class PriorityQueue {        
        private List<KeyCount> list = new List<KeyCount>();
        
        public void Add(KeyCount counter) {
            list.Add(counter);
            int i = list.Count - 1;
            while(true) {
                int parentIndex = (i + 1) / 2 - 1;
                if (parentIndex >= 0 && list[parentIndex].Count > list[i].Count) {
                    Swap(i, parentIndex);                 
                    i = parentIndex;
                } else break;
            }
        }
        
        public KeyCount RemoveTop() {
            var result = list[0];
            Swap(0, list.Count - 1);
            list.RemoveAt(list.Count - 1);
            Heapify(0);
            return result;
        }
        
        public KeyCount Top {
            get {
                return list[0];
            }
        }
        
        private void Heapify(int i) {
            var left = 2 * (i + 1) - 1;
            var right = left + 1;
            var min = i;

            // From wiki: Swap with its smaller child in a min-heap and its larger child in a max-heap.
            // If the node is already smallest, do nothing.
            if (left < list.Count && list[left].Count < list[min].Count) min = left;
            if (right < list.Count && list[right].Count < list[min].Count) min = right;

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
        
        public int Count {
            get {
                return list.Count;
            }
        }
        
        public IList<int> Values {
            get {
                return this.list.Select(item => item.Key).ToList<int>();
            }
        }
    }
    
    public IList<int> TopKFrequent(int[] nums, int k) {
        var result = new List<int>();
        if (nums == null || nums.Length == 0) return result;
        
        var dict = new Dictionary<int, int>();
        foreach(var n in nums) {
            dict[n] = 1 + (dict.ContainsKey(n) ? dict[n] : 0);
        }
        
        var priorityQueue = new PriorityQueue();
        foreach(var key in dict.Keys) {
            if (priorityQueue.Count < k) {
                priorityQueue.Add(new KeyCount(key, dict[key]));
            } else if (priorityQueue.Top.Count < dict[key]) {
                priorityQueue.RemoveTop();
                priorityQueue.Add(new KeyCount(key, dict[key]));
            }
        }
        
        return priorityQueue.Values;
    }
}

```
