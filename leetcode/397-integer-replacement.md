#397 - Integer Replacement
source: https://leetcode.com/problems/integer-replacement/

Given a positive integer n and you can do operations as follow:

If `n` is even, replace `n` with `n/2`.
If `n` is odd, you can replace `n` with either `n + 1` or `n - 1`.
What is the minimum number of replacements needed for n to become 1?

##Analysis
It seems to be DP problem. 

1. when n is even, `f(n) = f(n/2) + 1`
2. when n is odd, `f(n) = Math.Min(f(n+1), f(n-1)) + 1`. This is the tricky part. It needs `f(n+1)` result which is future result; however, it is an even number then it becomes `f((n+1) / 2) + 1`, so `f(n) = Math.Min( (f((n+1)/2)+ 1, f(n-1)) + 1 `;

**Update**: DP solution is O(n), but still get time out - too slow.

```csharp
public class Solution {
    public int IntegerReplacement(int n) {
        if (n == 1) {
            return 0;
        }
        
        var result = new int[n+1];
        result[1] = 0;
        result[2] = 1;
        
        for(int i = 3; i <= n; i++) {
            if (i % 2 == 0) {
                result[i] = result[i/2] + 1;
            } else 
            {
                result[i] = Math.Min(result[(i+1)/2] + 1, result[i-1]) + 1;
            }            
        }
        
        return result[n];
    }
}
```

**Update**:  this one uses a simple recursion. it is accepted. Time complexity is O(n).

```csharp
public class Solution {
    public int IntegerReplacement(int n) {
        if (n == 1) {
            return 0;
        } else if (n == 2) {
            return 1;
        }
        
        if (n % 2 == 0) {
            return IntegerReplacement(n/2) + 1;
        } else {
            return Math.Min(IntegerReplacement(n-1), IntegerReplacement(n/2 + 1) + 1) + 1;
        }
    }
}
```

**Update**: 

After reading the discussion page, I realize it is an interesting problem. It is a bitwise operation. 
`n/2` is to right shift one position, `n+1` or `n-1` on odd number is bit operation too. 
Other people managed to find a pattern to get the min change steps - reduce as many 1 as possible in steps.
I still feel it is a little bit hacky to find the pattern.
