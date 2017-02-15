#402 - Binary Watch
source: https://leetcode.com/problems/binary-watch/?tab=Solutions

It is an interesting problem.

I uses a straightforward method to solve the problem - given a bit array of length `n`, how many numbers can we get if we can set `m` bits to 1? It uses recursion method.

In discussion page, it is more interesting. `hour could be 0 to 11, and minute could be 0 to 59`. How many combination? `12 * 60 = 720`. not too many so we can check bit count on each combination, and add the one with `m` bit count to result.

the number to check should be `(hour >> 6) + minute`
