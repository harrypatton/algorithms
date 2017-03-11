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
* This solution doesn't work for follow-up question like `allow at most k transactions`.
* I don't like top discussion page solution which is too specific to the scenario. I like the 2nd one which is generalized for `k transaction`.

#LC188 - Best Time to Buy and Sell Stocks IV
source: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/?tab=Description

*Say you have an array for which the ith element is the price of a given stock on day i. Design an algorithm to find the maximum profit. You may complete at most k transactions.*

## Analysis
* DP comes in mind quickly. 
* Formula. **Update**: it might be wrong because Leetcode gives me timeout exception.
	* `f(k, i)` means max profit in days `[0..i]` using `at most k transactions`. 
	* How to calculate the number using subproblems? Choose the max of subresults below,
		* Not selling on day `i`: use `f(k, i-1)`
		* Selling on day `i`: previous buying day could be any day `j` in `[0..i-1]`.  The result is `Max(f(k-1, j) + prices[i] - prices[j])`.
	* the edge case is very interesting.
		* use `j` or `j-1` in `Max(f(k-1, j) + prices[i] - prices[j])`? I choose `j` to cover scenario like buy on first day and sell on last day.
		* do we need 2d array, one array or two arrays to save the cache? It seems that we have to use two arrays to save the result to avoid overwriting.
* Base
	* f(k, 0) = 0: only one day, cannot sell the stock.
	* f(0, i) = 0: no transaction allowed.

Signature
```
public int GetMaxProfit(int[] prices, int k)
```

##Learning
1. The DP solution shows time out so my formula might be wrong.
2. The discussion page shows a similar DP solution but with a couple of tricks to reduce the time out. Check it out.

#LC309 - Best Time to Buy and Sell Stock with Cooldown
source: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/?tab=Description

Say you have an array for which the ith element is the price of a given stock on day i.

Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:

* You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
* After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)

##Analysis
* let's say we have an array of price difference. 0, 2, 3, -2, 2, -1, -5, 3. Adding up the positive one? We have too chose one negative integer with one positive integer, because we cannot buy on the dropping day so we cannot get the profile on next day. 
* I kind of get the idea but hard to put in implementation. I need to find a cleaner way to solve the problem.

##Learning
* I'll leave as is for now. 
