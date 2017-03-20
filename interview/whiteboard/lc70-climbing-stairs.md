# LC70. Climbing Stairs
You are climbing a stair case. It takes n steps to reach to the top. Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top? Note: Given n will be a positive integer. [Source](https://leetcode.com/problems/climbing-stairs/#/description)

## Analysis
1. It is an easy problem to solve.
2. Base: I have two base cases for `n == 1` and `n == 2`. It means my code has 3 if-else blocks. If I use `n == 0` case, it will reduce 3 lines but readability is a little bit worse. what does it mean by `n==0`? 
3. The variable for `f(n-1)` and `f(n-2)` is tricky so I use `n1` and `n2`. Wish I could find better names. 

**Update**: there is a bug in my original code when update `n1` and `n2`. I didn't take it carefully. When we get new result, n2 moves to n1, and n1 should move to recent result.

```csharp
public class Solution {
    public int ClimbStairs(int n) {
        int result = 0;
        int n2 = 1;
        int n1 = 2;
        if (n == 1) {
            return n2;
        } else if (n==2){
            return n1;
        } else {
            for (int i = 3; i <= n; i++) {
                result = n1 + n2;
                n2 = n1;
                n1 = result;
            }
        }
        
        return result;
    }
}
```
