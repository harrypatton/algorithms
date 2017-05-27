## Problem
Source: https://leetcode.com/problems/perfect-squares/#/description

Given a positive integer n, find the `least number` of perfect square numbers (for example, `1, 4, 9, 16, ...`) which sum to `n`.

For example, given `n = 12`, return `3` because `12 = 4 + 4 + 4`; given `n = 13`, return `2` because `13 = 4 + 9`.

## Analysis
1. Very easy problem to solve using DP.
2. I haven't written DP for a while so my coding is nasty. See code below.

## Code - use naive memory DP
```c#
public class Solution_TimeOut {
    int[,] cache = null;

    public int NumSquares(int n) {
        cache = new int[n+1, 1 + ((int)Math.Sqrt(n))];
        for(int i = 0; i < cache.GetLength(0); i++) {
            for(int j = 0; j < cache.GetLength(1); j++) {
                cache[i, j] = -1;
            }
        }
        
        return NumSquares(n, 1);
    }
    
    public int NumSquares(int n, int min) {
        if (n == 0) return 0;
        if (cache[n, min] != -1) return cache[n, min];
        
        int result = int.MaxValue;
        for(int i = min; i <= (int)Math.Sqrt(n); i++) {
            var count = NumSquares(n - i * i, i);
            if (count != int.MaxValue) count++;
            result = Math.Min(result, count);
        }
        
        cache[n, min] = result;
        return result;
    }
}
```

## Code - use 2d space DP
```c#
public class Solution_2D_Memory {
    public int NumSquares(int n) {
        var cache = new int[n+1, ((int)Math.Sqrt(n)) + 1];
        for(int j = 0; j < cache.GetLength(1); j++) {
            cache[0, j] = 0;
        }
        
        for(int i = 1; i < cache.GetLength(0); i++) {
            for(int j = 1; j < cache.GetLength(1); j++) {
                cache[i, j] = int.MaxValue;

                // include the element
                var target = i - j*j;                
                if (target >= 0) {
                    cache[i, j] = cache[target, j];
                    // add the element itself if there's a match.
                    if (cache[i, j] != int.MaxValue) cache[i, j]++;
                }
                
                // without the element
                if (j == 1) cache[i, j] = i;
                else cache[i, j] = Math.Min(cache[i, j], cache[i, j - 1]);
            }
        }
        
        return cache[cache.GetLength(0) - 1, cache.GetLength(1) - 1];
    }
}
```

## Code - use one-array DP
```c#
public class Solution {
    public int NumSquares(int n) {
        var cache = new int[n+1];
        for(int i = 0; i < cache.Length; i++) cache[i] = i;
        
        for(int j = 2; j <= (int)Math.Sqrt(n); j++) {
            for(int i = 1; i <=n; i++) {
                var target = i - j * j;
                if (target >= 0) cache[i] = Math.Min(cache[i], cache[target] + 1);            
            }
        }
        
        return cache[cache.Length - 1];
    }
}
```
