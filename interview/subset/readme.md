## 78 - Subsets
source: https://leetcode.com/problems/subsets/?tab=Description

**Problem**: given a set of distinct integers, return all possible subsets. The solution cannot return duplicate subsets.

###Solutions
* **Recursion** - get all subsets based on `[1, n]`, and then extend the subsets by adding another subset (add `[0]` to every subset).
	* empty subset is part of the answer.
	* recursion exit: empty subset. **Learning**: the condition is still tricky and hard to understand.

```csharp
public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        if (nums == null) {
            return new List<IList<int>>();
        }
        
        return Subsets(nums, 0);
    }
    
    public IList<IList<int>> Subsets(int[] nums, int start) {
        var result = new List<IList<int>>();
        
        if (start >= nums.Length) {
            result.Add(new List<int>());
        }
        
        if (start <= nums.Length - 1) {
            var subResult = Subsets(nums, start + 1);            
            result.AddRange(subResult);
            
            foreach(var list in subResult) {
                var newList = new List<int>(list);
                newList.Insert(0, nums[start]);
                result.Add(newList);
            }
        }
        
        return result;
    }
}
```

*  **Iteration**
	* when iterate on first element, the result is `[], [0]`.
	* move to next element `[1]`, we keep the result and then add other results by adding `[1]` to every subset. It becomes `[], [0], [1], [0, 1]`
	* for element `[2]`, the result is `[], [0], [1], [0, 1], [2], [0,2], [1,2], [0, 1,2]`
* **Backtracking**:  `looking for a solution with better explanation.` This is a good link: http://math.stackexchange.com/questions/1689197/using-backtracking-algorithm-to-determine-all-the-subsets-of-integers
* **Bitmap**: use bitmap to indicate if the number is selected or not.

```csharp
    public class Solution {
        public IList<IList<int>> Subsets(int[] nums) {
            if (nums == null) {
                return new List<IList<int>>();
            }

            // init the result
            var result = new IList<int>[(int)(Math.Pow(2, nums.Length))];
            for (int i = 0; i < result.Length; i++) {
                result[i] = new List<int>();

                for (int j = 0; j < nums.Length; j++) {
                    if (((i >> j) & 1) == 1) {
                        result[i].Add(nums[j]);
                    }
                }
            }

            return result;
        }
    }
```
