#Objective
Given a string, print all permutation

#Ideas
##Recursion
f(n) => 

1. Calculate f(n-1) to get a list of strings
2. Insert nth char at every possible positions for all strings from #1.

It doesn't eliminate duplications. 

##Recursion - 2
inspired by the reference link

1. For every char in the string, set it as the first one
2. Get permutation for the rest of chars.

It is a top-down solution.
It can be used to reduce duplication. Duplicate chars could be first one only once.

##Optimal
Because it is bottom-up recursion, it is easy to implement without recursion.

To remove duplication, we can use hash table.

Another way is to generate permutation string by order. It could be tricky.

#Reference
* http://algorithms.tutorialhorizon.com/print-all-the-permutations-of-a-string/
