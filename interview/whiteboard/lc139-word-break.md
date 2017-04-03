
LeetCode [discussion page](https://discuss.leetcode.com/topic/6156/java-implementation-using-dp-in-two-ways/15) shows two better solutions.

```java
public class Solution {
    public boolean wordBreak(String s, Set<String> dict) {
        
        boolean[] f = new boolean[s.length() + 1];
        
        f[0] = true;
        
        
        /* First DP
        for(int i = 1; i <= s.length(); i++){
            for(String str: dict){
                if(str.length() <= i){
                    if(f[i - str.length()]){
                        if(s.substring(i-str.length(), i).equals(str)){
                            f[i] = true;
                            break;
                        }
                    }
                }
            }
        }*/
        
        //Second DP
        for(int i=1; i <= s.length(); i++){
            for(int j=0; j < i; j++){
                if(f[j] && dict.contains(s.substring(j, i))){
                    f[i] = true;
                    break;
                }
            }
        }
        
        return f[s.length()];
    }
}
```

This solution is a weird DP solution. List here anyway. 

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
