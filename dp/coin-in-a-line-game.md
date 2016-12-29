#Origin
* http://algorithms.tutorialhorizon.com/dynamic-programming-coin-in-a-line-game-problem/
* http://www.geeksforgeeks.org/dynamic-programming-set-31-optimal-strategy-for-a-game/

#Overview
**Objective**: 
* Given a line of coins. Each coin has a value.
* Total coin count is even.
* 2 players in this game. Each player choose either the front or the end coin.
* After they pick up all coins, the player with the greater value won.
* Assume each player is equally smart and want to win the game.

Goal: the first player to win the game.

#Ideas
## Brutal force
Not sure how to proceed with brutal force.

## Recursion 1
1. Given a line of coins[1..n].
2. f(n) = max of the following,
	* A chooses 1 and B choose 2: coin[1] + f(3..n)
	* A chooses 1 and B choose n: coin[1] + f(2..n-1)
	* A chooses n and B choose 1: coin[n] + f(2..n-1)
	* A chooses n and B choose n-1: coin[n] + f(1..n-2)
3. When n == 2, A chooses the coin with bigger value.

This doesn't seem right because B is not smart in this case.

## Recursion 2
1. Given a line of coins[1..n].
2. FA(m..n) = max of the following,
	* A chooses m and B does the rest - FB(m+1, n)
	* A chooses n and B does the rest - FB(m, n-1)
	* When n == 2, A chooses the coin with bigger value.
3. FB(m..n) = max of the following,
	* B chooses m and A does the rest - FA(m+1, n).
	* B chooses n and A does the rest - FA(m, n-1).
	* When n == 1, use the value left.

## DP
See recursion #2. We need to maintain two 2D matrix to save FA and FB result. It uses half matrix by diagonal and from top-left to bottom-right.

**Update**: the one in tutorialhorizon is better than mine.

MV(i, j)  = maximum value the first player can collect from i'th coin to j'th coin.

MV(i, j) = Vi + Max { Min{MV(i+2,j), MV(i+1, j-1)}, Min{MV(i+1,j-1), MV(i, j-2)}}

#Learning
I was struggling with FB method - I know it is very similar to FA and cannot think of a way to unify them. 

The original post combines max and min very well. First player tries to find the max value, but after pick up one node, what left is the minimum of two possible ones because player B is smart.
