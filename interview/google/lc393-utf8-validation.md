## Problem
Source: https://leetcode.com/problems/utf-8-validation/#/description

A character in UTF8 can be from 1 to 4 bytes long, subjected to the following rules:

1. For 1-byte character, the first bit is a 0, followed by its unicode code.
2. For n-bytes character, the first n-bits are all one's, the n+1 bit is 0, followed by n-1 bytes with most significant 2 bits being 10.

## Analysis
very straightforward question. just be careful about the edge cases.

## Edge cases
1. a char is 1 to 4 bytes long so be careful to check the max chars.
2. 1-byte char starts with 0, and n-byte starts with 1..10.

## Learning
**when use while statement, please double check the exit condition is correct. For statement is easier.**

## Code

```c#
public class Solution {
    public bool ValidUtf8(int[] data) {
        if (data == null || data.Length == 0) return false;

        int i = 0;
        while(i < data.Length) {
            var count = GetCount(data[i]);
            if (count < 0) return false;

            for(int j = 0; j < count ; j++) {
                if (i + j + 1 >= data.Length) return false; // out of range.
                if (!IsValidNum(data[i + j + 1])) return false;
            }

            i += count + 1;
        }

        return true;
    }

    private int GetCount(int num) {
        if (num >= 256) return -1;
        int prefix = 1 << 7;
        int count = 0;

        while(prefix > 0 && (num & prefix) == prefix) {
            count++;
            prefix = prefix >> 1;
        }

        // 10xxxxx, 11111xxx, 11111111 are all invalid. The later twos are because unicode is 1-4 bytes total.
        if (count == 1 || count > 4) count = -1;
        else if (count == 0) count = 0; // 1-byte unicode char. good.
        else count -= 1; // multi-bytes unicode.
        
        return count;
    }

    private bool IsValidNum(int num) {
        if (num >= 256) return false;

        // prefix is 1000 0000
        int prefix = 128;
        return (num & prefix) == prefix;
    }
}
```
