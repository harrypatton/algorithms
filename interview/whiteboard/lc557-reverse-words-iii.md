Source: https://leetcode.com/problems/reverse-words-in-a-string-iii/#/description

Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

Example 1:
```
Input: "Let's take LeetCode contest"
Output: "s'teL ekat edoCteeL tsetnoc"
```
**Note**: In the string, each word is separated by single space and there will not be any extra space in the string.

```c#
/*
it is a string with a few words. need to reverse the word itself but keep space and world order.
Solutions - find each word and reverse. Check how we find each word below.
*/
public class Solution {
    public string ReverseWords(string s) {
        var chars = s.ToCharArray();
        for(int i = 0; i < chars.Length; i++) {
            if (chars[i] != ' ') {
                // find current word
                int j = i;                
                while(j < chars.Length - 1 && chars[j+1] != ' ') j++;
                ReverseWord(chars, i, j);
                i = j; // tricky. equals = j and the for loop will add 1.
            }
        }
        
        return new string(chars);
    }
    
    public string ReverseWords_2(string s) {
        var chars = s.ToCharArray();
        int start = -1;
        int end = -1;
        
        for(int i = 0; i < chars.Length; i++) {
            if (chars[i] == ' ') { // here's a space.
                if (end >= 0) { // word ending
                    ReverseWord(chars, start, end);
                    start = -1;
                    end = -1;
                }
            } else {
                if (start == -1) start = i;               
                end = i;
            }
        }
        
        if (end >= 0) ReverseWord(chars, start, end);
        
        return new string(chars);
    }
    
    public void ReverseWord(char[] chars, int start, int end) {
        if (start >= chars.Length) return;
        int middle = start + (end - start) / 2;
        
        for(int i = start; i <= middle; i++) {
            // swap i and (end - i + start)
            var temp = chars[i];
            chars[i] = chars[end - i + start];
            chars[end - i + start] = temp;
        }
    }
}
```
