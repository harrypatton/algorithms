#Source
https://leetcode.com/problems/predict-the-winner/

#Question
Given an array of scores that are non-negative integers. Player 1 picks one of the numbers from either end of the array followed by the player 2 and then player 1 and so on. Each time a player picks a number, that number will not be available for the next player. This continues until all the scores have been chosen. The player with the maximum score wins.

Given an array of scores, predict whether player 1 is the winner. You can assume each player plays to maximize his score.

#Idea
I saw it before. It is an interesting and typical DP problem.

## Solution - DP
There are two choice for play 1 - the start and the end. Once chose, play 2 must left the min score for the rest of choices for play 1.

f(1..n) = ``MAX`` of the following
* pick up the first one: ``array[1] + MIN ( f(3..n),  f(2..n-1) )``
* pick up the last one: ``array[n] + MIN ( f(2..n-1), f(1..n-2) )``

so a big problem can break down into small sub-problems, and there are duplicate sub-problems so we can use DP.

It is easy to use a dictionary to save sub-problem result and use recursion, but I'd like to use bottom-up way.

The f(1..n) indicates it has two parameters so we can use at least 2-d matrix.

We need to initialize the 2-d matrix
```
for i = 0 to n-1
	f(i, i) = nums[i];

for i = 0 to n -2
	f(i, i + 1) = max(nums[i], nums[i + 1]);

for columnIndex = 2 to n - 1
	int i = 0;
	int j = columnIndex;

	while (j < length) {
		f(i, j) = Max(nums[i] + Min( f(i+2, j), f(i+1, j-1)), nums[j] + Min( f(i+1, j-1), f(i, j-2) );
		i++;
		j++;
	}
	
```

To predicate the winner,
```
play1 = f(0, n-1).
play2 = sum(nums) - play1.

bool isWinner = play1 >= play2.
```

time complexity: O(n^2)
space complexity: O(n^2)

#Learning
1. Practicing is always good. Easier to think of the solution but harder to write it down.
2. Take me a while to figure out the ``diagonal iteration`` in 2-d matrix. (every time the inner loop has a different length and row/column changes every time, so I should have used while statement instead of hardcode the length)
3. **I don't think we have to use 3 pre-results to determine one result**. I need to revisit this question. Cannot think more today:-(.
