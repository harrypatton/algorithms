# LC409 - Longest Palindrome
Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters. This is case sensitive, for example "Aa" is not considered a palindrome here.[Source](https://leetcode.com/problems/longest-palindrome/#/description)

## Analysis
1. It is an easy problem. A palindrome (except the center one if any) have even numbers of chars. That is, if the char has even number, it can become part of palindrome string.
2. Tricky part #1: I can use a `Dictionary<char, int>` to track total counter of each char, but I use a HashSet here to save memory. When iterate on a char which already exists in HashSet, I know it is even number so add 1 to the counter and also remove from HashSet; otherwise simply add to HashSet.
3. When iteration is end, counter * 2 is the result, but here's the tricky part - a char with odd number can be the center char, right? So if `string.Length > counter * 2`, I know we can use a char with odd number so just plus 1 to the result; otherwise just return `counter * 2`.

**Update**: code one time pass. I use half whiteboard for analysis and test case and the half for coding. Btw, I still think my coding in any editors (even Notepad) is much better than whiteboard. Probably because typing is much faster:). 

```c#
public class Solution {
    public int LongestPalindrome(string s) {
        if (s == null || s.Length == 0) {
            return 0;
        }
        
        var hashSet = new HashSet<char>();
        int counter = 0;
        
        foreach(var c in s) {
            if (hashSet.Contains(c)) {
                counter++;
                hashSet.Remove(c);
            } else {
                hashSet.Add(c);
            }
        }
        
        var result = counter * 2;
        return s.Length > result ? result + 1 : result;
    }
}
```
