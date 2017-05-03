source: https://leetcode.com/problems/factor-combinations/#/description

Numbers can be regarded as product of its factors. For example,

```
8 = 2 x 2 x 2;
  = 2 x 4.
```

Write a function that takes an integer n and return `all possible combinations of its factors`.

# Analysis
1. I checked the discussion page to get the solution.
2. There're some edge cases to handle.
3. Even today, I'm not 100% sure I can write it correctly.

```c#
/*
use DFS solution. check from smaller number and then big one.
*/
public class Solution {
    public IList<IList<int>> GetFactors(int n) {
        var result = new List<IList<int>>();
        if (n > 3) DFS(result, new List<int>(), n, 2);
        return result;
    }
    
    public void DFS(IList<IList<int>> result, IList<int> subresult, int n, int start) {
        // base
        if (n == 1) {
            result.Add(new List<int>(subresult));
            return;
        }
        
        int max = (int)Math.Sqrt(n);
        for(int i = start; i <= max; i++) {
            if (n % i == 0) {
                // add to temp result
                subresult.Add(i);                
                DFS(result, subresult, n / i, i);
                // remove the last element
                subresult.RemoveAt(subresult.Count - 1);
            }
        }
        
        // include itself
        if(subresult.Count > 0 && n >= start) {
            var tempResult = new List<int>(subresult);
            tempResult.Add(n);
            result.Add(tempResult);
        }
    }
}
```
