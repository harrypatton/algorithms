## Problem
Write a function that takes a string as input and reverse only the vowels of a string.

```
Given s = "hello", return "holle".
Given s = "leetcode", return "leotcede".
```

Note:
The vowels does not include the letter "y".

## Analysis
Easy to use two pointers to solve the problem.

**Note**: see how clean the code is to avoid another two while statement inside the big one. 

## Code

```c#
public class Solution {
    public string ReverseVowels(string s) {
        if (s == null || s.Length == 0) return s;
        var chars = s.ToCharArray();
        int start = 0;
        int end = chars.Length - 1;
        
        while(start < end) {
            if (!IsVowel(chars[start])) start++;
            else (!IsVowel(chars[end])) end--;
            else {
                var temp = chars[start];
                chars[start] = chars[end];
                chars[end] = temp;
                start++;
                end--;
            }
        }
        
        return new string(chars);
    }
    
    public bool IsVowel(char c) {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'
            || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
    }
}
```
