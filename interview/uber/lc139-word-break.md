Source: https://leetcode.com/problems/word-break/#/description

Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, 
determine if s can be segmented into a space-separated sequence of one or more dictionary words. 
You may assume the dictionary does not contain duplicate words.

For example, given
```
s = "leetcode",
dict = ["leet", "code"].
```

Return true because "leetcode" can be segmented as "leet code".

## Analysis

### BFS solution (my solution)
Solution 1 - scan every letter and mark every matched word

1. use an array to store the result.
2. foreach char in the s, if array[i-1] is true, 
check every string in the dictionary. If it is equal to substring starting from that index. 
if yes, mark new position as true.

time complexity: worse case (m * n). m is s length and n is dictionary size.

Solution 2 - DFS/recursion. try every possible match in first letter and call the same function for the rest of string.

question: how to calculate the time complexity? 
f(n) = f(n-1) + f(n-2) + f(n-3) + ... (try every one)
     = 2^n.
     
bad time complexity.

Solution 3 - DP solution?

```c#
public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        if (s == null || wordDict == null || wordDict.Count == 0) return false;
        var result = new bool[s.Length];
        
        for(int i = 0; i < s.Length; i++) {
            if (i == 0 || result[i-1]) {
                foreach(var word in wordDict) {
                    if(s.Substring(i).StartsWith(word)) {
                        result[i + word.Length - 1] = true;
                        if (result[s.Length - 1]) return true;
                    } 
                }
            }
        }
        
        return false;
    }
}
```

### DP 1
time complexity: O(n*m)

```java
public class Solution {
    public boolean wordBreak(String s, Set<String> dict) {
        
        boolean[] f = new boolean[s.length() + 1];
        
        f[0] = true;
        
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
        }    
        
        return f[s.length()];
    }
}
```
### DP 2
time complexity: n^2. If dictionary size is much bigger, this solution is better.

```java
public class Solution {
    public boolean wordBreak(String s, Set<String> dict) {
        
        boolean[] f = new boolean[s.length() + 1];
        
        f[0] = true;
        
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
