source: https://leetcode.com/problems/reverse-words-in-a-string-ii/#/description

Given an input string, reverse the string word by word. A word is defined as a sequence of non-space characters.

The input string does not contain leading or trailing spaces and the words are always separated by a single space.

For example,
```
Given s = "the sky is blue",
return "blue is sky the".
```

Could you do it in-place without allocating extra space?

## Code
The solution is simple. just be careful about the edge cases like empty, single letter, all letters separated by space.

```c#
/*
solution: 
reverse the whole string and then reverse individual word.
write a helper function to reverse a substring
*/
public class Solution {
    public void ReverseWords(char[] s) {
        if (s == null || s.Length <= 1) return;
        Reverse(s, 0, s.Length - 1);
        
        // reverse each word
        int start = 0;
        int end = 1;
        while(end < s.Length) {
            if(s[end] == ' ') { //run into a word
                Reverse(s, start, end - 1);
                end++;
                start = end;
            } else {
                end++;
            }
        }
        
        // reverse the last piece
        Reverse(s, start, end - 1);
    }
    
    public void Reverse(char[] s, int start, int end) {
        while(start < end) {
            var temp = s[start];
            s[start] = s[end];
            s[end] = temp;
            start++;
            end--;
        }
    }
}
```

## Update
a lot of times I found for loop is easier than while loop to understand. Look at the solution below. Very clean.

```java
public void reverseWords(char[] s) {
    // Three step to reverse
    // 1, reverse the whole sentence
    reverse(s, 0, s.length - 1);
    // 2, reverse each word
    int start = 0;
    for (int i = 0; i < s.length; i++) {
        if (s[i] == ' ') {
            reverse(s, start, i - 1);
            start = i + 1;
        }
    }
    // 3, reverse the last word, if there is only one word this will solve the corner case
    reverse(s, start, s.length - 1);
}

public void reverse(char[] s, int start, int end) {
    while (start < end) {
        char temp = s[start];
        s[start] = s[end];
        s[end] = temp;
        start++;
        end--;
    }
}
```
