#Original
* http://algorithms.tutorialhorizon.com/dynamic-programming-maximum-product-cutting-problem/
* http://www.geeksforgeeks.org/dynamic-programming-set-36-cut-a-rope-to-maximize-product/

#Overview
**Objective**: given a rope of length n meters, write an algorithm to cut the rope in such a way that product of different lengths of rope is maximum. At least one cut has to be made.

Example
```
 Rope length: 2 
 Options: (1*1)
 Maximum Product Cutting : 1*1 = 1
 
 Rope length: 3 
 Options: (1*1*1, 2*1)
 Maximum Product Cutting : 2*1 = 2
 
 Rope length: 4 
 Options: (1*1*1*1, 2*1*1, 3*1, 2*2)
 Maximum Product Cutting : 2*2 = 4
 
 Rope length: 5 
 Options: (1*1*1*1*1, 2*1*1*1, 3*1*1, 2*2*1, 3*2)
 Maximum Product Cutting : 3*2 = 2
```

#Ideas
## Brutal force
1. There are n-1 cut positions - each one could be cut or not.
2. The total way to cut is 2^(n-1). After that, calculate the max result.

## Recursion
1. Base f(1) = 1
2. f(n) = max( f(1) * f(n-1), f(2) * f(n-2), f(3) * f(n-3), ..., f(n/2) * f(n - n/2)).

## DP
1. just use the recursion way to calculate. Time complexity is 1 + 2 + ... + n = O(n^2). Space complexity is O(n).
2. base condition is very tricky. 
	* f(1) = 1
	* f(2) = 1 
	* when we calculate f(3), f(1) * f(2) is 1; however f(3) could be 2 because the 2 could be a whole without cut (i.e., f(2) == 2).
	* conclusion - f(i) = i for initialization. For edge cases, f(2) = 1, f(3) = 2, f(4) = 4.

#Learning
1. Original post has a better recursion.
```
Let maxProd(n) be the maximum product for a rope of length n. maxProd(n) can be written as following.

maxProd(n) = max(i * (n-i), i * maxProdRec(n-i)) for all i in {1, 2, 3 .. n}

It reads as if the first cut could be at position 1, 2, ... n - 1. After that, there could be no cut or some cut(s) which get max production.

```
