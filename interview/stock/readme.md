#LC121 - Best Time to Buy and Sell Stock
*Say you have an array for which the ith element is the price of a given stock on day i. If you were only permitted to complete at most one transaction (ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.*

## Analysis
1. The problem is to find the max difference. If no transaction is done (when price keeps going down), return 0.
2. **naive solution**: check every pair and calculate the different. Time O(n^2). 
3. **one iteration**: keep variables `min` and `maxProfit` during the iteration. 
	* `min` is set to the first element. `maxProfit` is set to zero.
	* iterate the array from the second element. 
		* Calculate the profile by `currentPrice - min`. Choose the max one between the new value and `maxProfit`. 
		* if `currentPrice < min`, update `min`.
	* Time O(n). Space O(1).
	* It is a DP solution.

Function Signature
```
int FindMaxProfit(int[] prices)
```

#LC122 - Best Time to Buy and Sell Stock II
source: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/?tab=Description

*Say you have an array for which the ith element is the price of a given stock on day i. Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times). However, you may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again). *

## Analysis
1. if tomorrow's price is higher, we'll make the trade to make profile
2. if price is lower, we do nothing.
3. what if price goes high in two consecutive days? can we sell and buy on the same day? It doens't matter. We can still use #1 as if we buy on day 1 and sell on day 3.
4. The algorithm becomes simple - just compare adjacent elements. If higher, add the difference; otherwise skip.

**Update**: one time bug free code.

#LC123 - Best Time to Buy and Sell Stock III
source: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/?tab=Description

Say you have an array for which the ith element is the price of a given stock on day i. Design an algorithm to find the maximum profit. You may complete **at most two transactions**.

## Analysis
* We can do <= two transactions.
* We already have answer for none and one transaction scenario.
* For two transactions scenario, we need to select pivot. Each part becomes one-transaction scenario.
* It becomes a DP problem. 
	* Calculate none or one-transacation for [0..i]. `0 <= i <= n`. Save them in array `prefix`.
	* Calculate none or one-transaction for [i..n]. `0 <= i <= n`.  Save them in array `suffix`.
	* Use pivot, calculate the value `prefix[i] + suffix[i]` and choose the max value.
	* Time O(1), Space O(n).

## Learning
* My original solution is clean. I learned something from discussion page and tried to combine the first element scenario with others. It brings a very tricky issue that is hard to discover. I should stick with original one.
