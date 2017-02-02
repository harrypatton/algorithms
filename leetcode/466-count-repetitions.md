#466 - Count The Repetitions
source: https://leetcode.com/problems/count-the-repetitions/

* Define `S = [s,n]` as the string `S` which consists of `n connected strings s`. For example, `["abc", 3] ="abcabcabc"`.
* Define that string `s1` can be obtained from string `s2` if we can remove some characters from `s2` such that it becomes `s1`. For example, “abc” can be obtained from “abdbec” based on our definition, but it can not be obtained from “acbbe”.

**Problem**: given `P = [s1, n1]` and `Q = [s2, n2]`, find the maximum integer `M` such that `[Q, M]` can be obtained from `P`.

#Ideas
