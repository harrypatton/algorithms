
This solution is a weird DP solution. List here for now.

```csharp
public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        if (s == null || s.Length == 0 || wordDict == null) {
            return false;
        }
        
        var canBreak = new bool[s.Length];
        
        for(int i = 0; i < s.Length; i++) {
            // check if dictionary has the prefix
            if (!canBreak[i] && wordDict.Contains(s.Substring(0, i + 1))) {
                canBreak[i] = true;
            }
            
            // when it can be broken down, find other candidates.
            if(canBreak[i]) {
                for (int j = i + 1; j < s.Length; j++) {
                    if(!canBreak[j] && wordDict.Contains(s.Substring(i + 1, j - i))) {
                        canBreak[j] = true;
                    }
                }
            }
        }
        
        return canBreak[s.Length - 1];
    }
}
```
