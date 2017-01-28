#Magical String
Source: https://leetcode.com/problems/magical-string/

It seems to generate magical string based on a small start string and return the first n numbers. The question already gives a magical string to start.

* Because it needs the first N number, we can use N-length char array instead of string builder.
* start string: 122. Initialize the array with that value.
* ``index`` points to 3 which position we will update the array.
* ``count_pointer``points to 2. it points to how many consecutive numbers next? it must be different from previous number.
* as long as index < n, adding numbers based on ``count_pointer`` and previous number, move ``count_pointer`` ahead.
* Count the count of 1 during the time, but be careful about edge cases.

#Summary
1. It is easy for me to write a complete solution in the first time.
