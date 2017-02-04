#452 - Minimum Number of Arrows to Burst Balloons
source: https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/

#Idea
We can try DP solution to solve the problem. 

1. Sub-problem is we found minimum number of arrows for (n-1) balloons. We can use a list with tuple(int, int) to save the arrows.
2. Adding one balloon will check if existing arrows hit, if not, add one more.
	* A little bit tricky to check if two horizontal lines have overlap. Check the code.
3. If a balloon can be hit by multiple arrows, choosing one is enough? Apparently it is not. I think of a scenario that use the second kind of min arrows lead to a better solution for next balloon. 

**Failed** - the sub-problem result is tricky. 

##Learning
After reading the discussion page, the solution is here,

1. sort all balloon by the start position. If two balloon have the same start position, sorted by end position then.
2. iterate over each balloon
	* track how many arrows we need
	* track the arrow limit which means the end point of current arrow.
	* when check current balloon in the loop
		* if `start <= arrow_limit`, the arrow can still hit. update `arrow_limit == Math.Min(arrow_limit, end)`
		* else it needs a new arrow and arrow_limit is the `end`.
