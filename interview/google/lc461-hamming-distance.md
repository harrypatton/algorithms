## Problem
Source: https://leetcode.com/problems/hamming-distance/#/description

The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

Given two integers x and y, calculate the Hamming distance.

## Analysis
1. use xor operator to calculate the number and then count how many 1's.
2. How to count 1's? In Java, there's a simple method to do the work but C# doesn't provide.
    * we can use flag `1, 10, 100, ...` to mask it. Be careful about the condition. Each iteration move `1` bit instead of `i` (iterator pointer) bits.
    * the other way is to move the val itself. Need to compare `32` times so just right-shift `31` times. Be careful about the count times.

## Code
```c#
public class Solution {
    public int HammingDistance(int x, int y) {
        int val = x ^ y;
        int count = 0;
        for (int i = 0; i < 32; i++) {
            if ((val & 1) == 1) count++;
            val >> = 1;
        }

        return count;
    }
}
```
