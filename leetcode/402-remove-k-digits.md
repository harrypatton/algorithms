#402 - Remove K Digits
source: https://leetcode.com/problems/remove-k-digits/

**Problem**: given a non-negative integer `num` represented as a string, remove `k` digits from the number so that the new number is the smallest possible.

## Analysis
1. thought about removing the biggest digits but it didn't work out for the 3 examples.
2. brutal force: there're CnK combinations.
3. DP? what's the sub-problem? It reminders me of 1/0 knapsack problem.

## DP
As a number, it is easy to start backward. For last letter, it is either in the min number or not.

The final result is `f(n, k) = Min(f(n-1, k) * 10 + array[n], f(n-1, k-1))`. f(n, k) means the minimum numbers from array 0..n when removing `k` digits. 

1. init value `f(0, x) = 0`, `f(x, 0) = x`
2. Row count: `digit count`; column count: `k`
3. Two arrays (length == column count) are sufficient for cache purpose.

## Learning
1. The following solution works fine with time `O(n * k)`. Discussion page shows an `O(n)` solution with simpler idea.
2. when work on O(n) solution, I missed a lot of edge cases and took a while to fix each of them. I need more practice though.

**DP Solution**

```csharp
public class Solution {
    public string RemoveKdigits(string num, int k) {
        if (num == null) {
            return null;
        }
        
        var result = new string[k+1];
        
        for(int i = 0; i < num.Length; i++) {
            // save the result for current row (i.e., new number)
            var tempResult = new string[k+1];
            
            for (int j = 0; j <= k; j++) {
                // when there is no digit to remove, the min is the same as the whole number
                if (j == 0) {
                    tempResult[j] = (result[0] == "0" ? string.Empty : result[0]) + num[i];
                } else if (i == 0) { // when there is a single number, it is always 0 when remove 1 or more digits. (0 scenario is covered in above case)
                    tempResult[j] = "0";
                } else {
                    // we can include current number or exclude it.
                    // when include it, the value is f(n-1, k) * 10 + array[n], i.e., result[j] * 10 + num[i] - '0'
                    // when exclude it, the value is f(n-1, k-1), i.e., result[j-1]
                    var result1 = (result[j] == "0" ? string.Empty : result[j]) + num[i];
                    var result2 = result[j-1];
                    
                    if (result1.Length != result2.Length) {
                        tempResult[j] = result1.Length < result2.Length ? result1 : result2;
                    } else {
                        tempResult[j] = string.Compare(result1, result2) < 0 ? result1 : result2;
                    }
                }                
            }
            
            result = tempResult;
        }
        
        return result[k];
    }
}
```
