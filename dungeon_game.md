##Original
1. https://leetcode.com/problems/dungeon-game/


##Overview
**Objective**: rescue the princess. A few notes,

1. Both left-top and bottom-right cells may have demons, orbs or just be empty.
2. Knight just go right or down.
3. Knight doesn't have upper-bound health value.
4. Initial health value must be greater than zero.
5. Goal: calculate the minimum initial health.


##Ideas

###Brutal force
1. Calculate paths to reach to the cell. Recursion can help.
2. Given a path, get the initial values. This is a little bit tricky because we need to calculate the value from end to beginning.
3. Get the min initial health value from so many candidate paths.

###Recursion
Not sure how I can write a recursion solution. It is very similar to brutal force one.

###DP
let's define f[m][n] is the min initial value to enter the cell and finally rescue the princess.

1. If value[m][n] >= 0, f[m][n] = 1
2. Otherwise, f[m][n] = 1 - value[m][n].

Next step is to calculate upper cell f[m-1][n] and left cell f[m][n-1].

1. The remaining value must be f[m][n].
2. If value[m-1][n] >= 0, f[m-1][n] = max(1, f[m][n]);
3. otherwise, f[m-1][n] = f[m][n] - value[m-1][n];

**Update #1**: I got stuck because the algorithm doesn't reply on any previously calculated result. We need to find a better subtask.

**Update #2**: I figured it out now. Every cell needs neighbor's result. See details below,

Previously we can easily calculate the result for last column and last row.
f[i][j] => there are two ways for them to move; either right or left.

No matter value[i][j] >= 0 or not, f[i][j] = min(f[i-1][j] - value, f[i][j-1] - value); if f[i][j] <= 0, set to 1. so the calculation is from bottom-right corner to top-left corner.

Please note, it can be changed to ``f[i][j] = min(f[i-1][j], f[i][j-1]) - value``

##Learning
1. Nothing. Just need to think carefully before giving up.
