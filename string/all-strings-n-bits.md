#Objective
Generate all strings of n bits.

e.g., n = 3,

000, 001, 010, 011, 100, 101, 110, 111

#Ideas
##Recursion
Every position could be 0 or 1.

f(n) =
	 1 + f(n-1);
	 0 + f(n-1)

##Optimal
1. Because above is bottom-up recursion, it is easy to implement without recursion. O(2^n)
2. Another way is we know the max integer, we can iterate and print out string format for that integer. O(n * 2^n)


#Reference
* http://algorithms.tutorialhorizon.com/print-all-the-permutations-of-a-string/
