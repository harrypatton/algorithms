#392. Is Subsequence
source: https://leetcode.com/problems/is-subsequence/?tab=Description

Given a string `s` and a string `t`, check if `s` is subsequence of `t`.

A `subsequence` of a string is a new string which is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ace" is a subsequence of "abcde" while "aec" is not).

## Analysis
1. Original problem is very easy to solve. Because it cannot change the order, we can use two pointers to iterate both arrays. As we iterate `t`, it must find a matching char in `s`. The pointers move forward only. `easy to write` but I need more practice to be perfect.

## Follow-Up Question
If there are lots of incoming S, say `S1, S2, ... , Sk where k >= 1B`, and you want to check one by one to see if T has its subsequence. In this scenario, how would you change your code?

We cannot use original solution because each check is O(n+m). The best way is hash table.

1. Calculate every possible subsequence for `t` and save to a hash table.
2. Check every `Sn` using the hash table. It is O(1). 

It may take a while to set up hash table but it is worth it. Another way could be, still use original solution but use a hash table to save the result. Every time check next input, check hash table first. Given that the `K>1B`, it doesn't make any difference.

## Learning
1. As I always mention, it is delightful to see cleaner code in discussion page:). People are smart.
