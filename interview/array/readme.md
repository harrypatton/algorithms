# LC3 - longest substring without repeating characters
source: https://leetcode.com/problems/longest-substring-without-repeating-characters/?tab=Description

**Problem**: Given a string, find the length of the longest substring without repeating characters.

## Analysis
1. The problem doesn't say lower-case English letter so we need to use hash table.
2. **Brutal force** - check every single `substring` and verify all chars are unique.  time complexity is O(n^3).
3. **DP** - f(n) means longest substring (without dupe) ending with this letter. For new letter, scan back to find longest substring until `f(n) + 1`. total complexity is O(n^2).
4. **Moving Window**
	* use a hash set to store current characters.
	* let's use two pointers. Check end pointer,
		* if it is not in hash set, add it, move end pointer, increase the counter (and update the max)
		* if it is in hash set, we need to move start pointer.  While moving, remove the element from hashset until reach the same value as end point. Move end pointer one step.
		* when end step reach after the end, we can quite.

**Update**: yes, I get one-time pass with bug-free code.

## Learning
1. [Discussion page](https://leetcode.com/articles/longest-substring-without-repeating-characters/) has awesome solutions to learn. It uses a Dictionary to store the char index. When the char is repetitive, it uses that index value to quickly skip.
2. we don't have to set a variable for the counter, because it is equal to (end - start + 1).

#LC179 - Largest Number
source: https://leetcode.com/problems/largest-number/?tab=Description

Given a list of non negative integers, arrange them such that they form the largest number. For example, given `[3, 30, 34, 5, 9]`, the largest formed number is `9534330`. Note: The result may be very large, so you need to return a string instead of an integer.

## Analysis
1. The first digit in each number is very important. We should pick up the one with biggest digit.
2. If the first digit is the same, it is tricky for next one. E.g, `3, 32, 34`.  `34332` is the biggest one.
	* If both numbers have the `nth` digit, bigger digit wins. E.g., `32, 36 = 3632`.
	* If one digit is missing, the other one with a bigger second digit which is also greater than first digit is bigger. E.g, `3, 34 = 343`, `3, 32 = 332`, 
		* if the 3rd digit is the same, we have to keep checking the rest. `3, 332 = 3332 `, `3, 334 = 3343`
3. We just need to sort based on logic above and combine them together.
4. **Update** - the above analysis is too tricky when the remaining letter is the same as first one. See examples below. 

```
32, 323 => 323-32
343, 3433 => 34-343
```
I end up with a cheating way - just check `string.Compare(numStr1 + numStr2, numStr2 + numStr1)`. The result is accepted by the system.

#LC33 - Search in Rotated Sorted Array
source: https://leetcode.com/problems/search-in-rotated-sorted-array/?tab=Description

**Problem** - find an element in the array. If not found, return -1. Assume no duplicate exists in the array.

## Analysis
1. Use binary search idea. Every time we should cut half elements so the time complexity is supposed to be O(logn).
2. Draw a picture to get better idea. Select the middle. half element will go to normal binary search and the rest will call ~~the same function recursively~~.
3. Feel easier when no duplicate elements in the array:).
4. **Update** - it is tricky to get edge cases right.
5. **Update 2** - not sure why I was think about recursion. Binary search doesn't need recursion - just move two pointers.

Reset Analysis

1. List all scenarios to consider,
	* one element
	* two elements with descending order
	* ascending order without rotation
	* rotate in the first half
	* rotate in the second half.
2. First of all we need to get middle. If middle == target, it is good.
3. Divided into scenarios.  
	* if middle > start, it is 3+ ascending array, or rotation point is in 2nd half.
		* if target is in `[start, middle)`, `middle - 1` becomes `end`.
		* otherwise go to the right.
	* if middle < start, its rotation point is in the first half.
		* if target is in `(middle, end]`, `middle + 1` becomes `start`.
		* otherwise go to the left.
	* if middle == start, it is 1-element array, or 2-elements array. Which pointer to move?
		* it doesn't matter for 1-element array because pointers would become invalid.
		* for 2-elements array, we can move to right.

**Update**: one time bug-free pass.

#LC153 - Find Minimum in Rotated Sorted Array
source: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/?tab=Description

The array doesn't have duplicate numbers. The problem is to look for the pivot element (i.e., the min value).

## Analysis
1. Still need to care about all scenarios.
2. Unlike finding a target, when do we quite when find the min?
	* when middle > end, go to right (`excluding` the middle)
	* when middle < end, go to left (`including` the middle)
	* when middle == end, it is pivot point.

**Update**: be careful about the edge cases. Still took me 2 times to fix the issue.

# Permutation of an Array of Arrays
source: http://blog.gainlo.co/index.php/2017/01/05/uber-interview-questions-permutations-array-arrays/

Given a list of array, return a list of arrays, each array is a combination of `one element in each given array`. One example,

```
input: [[1, 2, 3], [4], [5, 6]]
output: [[1, 4, 5], [1, 4, 6], [2, 4, 5], [2, 4, 6], [3, 4, 5], [3, 4, 6]]
```

## Analysis
1. The new array pick one element from each array in original list.
2. tricky things or edge cases.
	* what about duplicate elements? need to clarify. If we need to handle duplicates, we need to sort the array and add unique elements (or use hashset to check duplicates).
	* does the order inside the result array matter? E.g., [1, 4, 5], how about [1, 5, 4]? Another way to ask the question, is the nth element in final array always coming from nth array in original list?

### Recursion
Permutation is always each to use recursion or iterative method. Say we have the answer for f(n-1), it is easy to get f(n) by inserting every element to previous result.

### Backtracking
I should practice that too.

### Better Solution
I haven't found out yet.

### Learning
1. The source needs improvement on quality. It is not as good as LeetCode.
2. If we just need to print out the result instead of return, we can use backtracking to save the memory.

#LC22 - Generate all Parentheses
source: https://leetcode.com/problems/generate-parentheses/?tab=Description

Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses. For example, given n = 3, a solution set is:
```
[
  "((()))",
  "(()())",
  "(())()",
  "()(())",
  "()()()"
]
```

## Analysis
1. Not an intuitive way to come up with a solution.
2. Brutal force - n pairs have 2n length. Open parentheses could be any random n positions. Total is C(2n, n). Given one string, it takes O(n) to check if valid. Not efficient.

### Iterative/DP/Recursion
Say we have the result for `f(n-1)`, given a new pair, how to update it?

1. In the first time, I cannot find a good solution on that. I don't know how to denote or find a sub-problem formula. I have to check the answer.
2. I always think of DP, but in this case, to get all results, I should have tried backtracking. Apparently it is very easy to use backtracking. I got one-time bug free pass; but it is not very intuitive to understand.

# Maximum Sum of Two Non-adjacent Elements
Source: http://blog.gainlo.co/index.php/2016/12/02/uber-interview-question-maximum-sum-non-adjacent-elements/

Given an array of integers, find a maximum sum of **two** non-adjacent elements. `For example, inputs [1, 0, 3, 9, 2] should return 10 (1 + 9).`

## Analysis
1. Because it requires non-adjacent elements, so we cannot sort.
2. Brutal Force - check each pair and record the max. time complexity: O(n^2)
3. Optimization - we can also use one time iteration to find the result. 
	* f(n-2) means the max element so the max sum for current element is f(n-2) + array[n].
	* f(n-1) is Math.Max(f(n-2), array[n-1]).
	* Init the value based on first and second element, and then calculate starting from the third one.
	* If array is less than 3 element, we return int.MinValue.
4. Be careful about the edge cases.

##Learning##
1. I can easily write down the code but I don't clarify the question first
	* Is it any random number of non-adjacent elements or two elements? 
	* What if one element is positive and others are negative?
2. When I write the code, I wrongly assume it means 2 elements but the source shows 2 or more elements, so I keep as is and write a new question below.

# Maximum Sum of any Non-adjacent Elements
source: http://blog.gainlo.co/index.php/2016/12/02/uber-interview-question-maximum-sum-non-adjacent-elements/

Given an array of integers, find a maximum sum of **any** non-adjacent elements. `For example, inputs [1, 0, 3, 9, 2] should return 10 (1 + 9).`

## Analysis
1. No intuitive way to do brutal force. 
2. Because it requests max value, we can use DP; otherwise use backtracking.
	* **formula**:  `f(n) = Math.Max(f(n-2) + current_element, f(n-1))`.  It is obvious.
	* **base**: f(0) = array[0], f(1) = Math.Max(array[0], array[1]).

## Learning
1. It is easy to write down the code; but be careful it doesn't work for negative number. When consider negative numbers, the **formula** should be `f(n) = Math.Max(currentElement, f(n-2) + current_element, f(n-1))`. Just add currentElement to the list.

# LC283 - Move Zeroes
source: http://blog.gainlo.co/index.php/2016/11/18/uber-interview-question-move-zeroes/

**Problem**: modify the array by moving all the zeros to the end (right side). The order of other elements doesn’t matter.

`Extention`: move zeros and still keep the orders of other elements.

## Analysis
1. Extra array - get another array, copy non-zero elements first and then set the rest as zero. `Time O(n)` and `Space O(n)`.
2. `In-Place`:  something similar to quick sort. Pivot elements. Quick sort is not a stable algorithm so it cannot preserve the order.
	* set two pointers at start and end.
	* `while (start < end)`
		* while (start < end && start == non-zero), start++;
		* while (end > start && end == zero), end--;
		* if (start < end && start == zero && end== non-zero), swap the elements, start++ and end--;
	* Here's another way to write the while code block, `while (start < end)`
		* if (start == non-zero) start++; continue;
		* if (end == zero), end--; continue;
		* swap start and end; move both pointers;
	* The 2nd `while code block` is cleaner than the first one.

##Extension
What can we do to preserve the order? It is an easy problem to just move non-zero element; the rest would be zero.

1.  Set a pointer `p` to a position which will be set with non-zero element, i.e., `p = 0`.
2. Iterate over the whole array
	* if current element is non-zero element (`be careful about the edge case`)
		* `if p != index,  array[p] = array[index]`; otherwise don't set the same value.
		* move pointer `p` one step.
	* if current element is zero, do nothing. 
3. After the iteration, starting with `p`, set the rest of arrays to zeros.

**Update**: one time bug free code passed.

# Weighted Random Number
source: http://blog.gainlo.co/index.php/2016/11/11/uber-interview-question-weighted-random-numbers/

**Problem**: Write a function that returns values randomly, according to their weight. Example. 
```
Suppose we have 3 elements with their weights: A (1), B (1) and C (2). 
The function should return A with probability 25%, B with 25% and C with 50% based on the weights.
```

## Analysis
1. I rarely see this type of problem.
2. The answer should be a function and run it a few times, it should generate all elements with expected probability.
3. Add all weights to a total and generate a number `k` between `1` and `sum`. Choose ceiling on random.Next(0, sum).
4. Iterate over the element and reduce `k` by the element weight. if `k <= 0`, current element is the output.

### Questions
1. How to validate the algorithm is correct?
2. Do we need perfect random? If we use built-in library `Random class`, it never happen. Need to clarify with interviewer.

## Learning
1. Weight could be double type. Do you think about that?
2. My original algorithm is correct (the same solution in source). Time complexity O(n) and space O(1). Can we improve time complexity?
	* O(n) seems hard without space.
	* O(logn) seems doable due to binary search. Instead of saving the weight, I can store the sum of weight until that element.
3. Be careful about edge cases. The random.Next will return int type. In our case, we can always find the integer. 

# LC20 - Valid Parentheses
source
* http://blog.gainlo.co/index.php/2016/09/30/uber-interview-question-delimiter-matching/
* https://leetcode.com/problems/valid-parentheses/?tab=Description

It is also the Uber - Delimiter Matching problem.

**Problem**: Write an algorithm to determine if all of the delimiters in an expression are matched and closed. For example,
```
“{ac[bb]}”, “[dklf(df(kl))d]{}” and “{[[[]]]}” are matched. But “{3234[fd” and {df][d} are not. The question has been asked by Uber recently and is expected to be solved quickly.
```

## Analysis
1. **Stack**: It is easy to solve using stack for open-close delimiter or parenthesis. 
	* When see an open delimiter, push to stack
	* when see a close one, check if peek element is a closing matched one.
		* If yes, pop it up.
		* If no, return - we know it is an invalid expression.
	* edge case
		* when iteration is complete, check any remaining element.
		* ignore letter during iterating.
2. Function signature

```
public bool IsValid(string str);
```

## Learning
1. Easy code but I submitted twice because I didn't run invalid scenario before commit the code. When encounter close delimiter, I need to check if stack is empty before popping up the top element.


# Duplicate Element in string Array
source: http://blog.gainlo.co/index.php/2016/05/10/duplicate-elements-of-an-array/

*Given an array of string, find duplicate elements.*

## Analysis
There're a few ways to handle it. We assume string comparison as O(1) operation.

1. **Naive solution**: pick up one element and compare with others. Time O(n^2) and space O(1).
2. **Sort and find duplicates**. When current element is not the same as previous one, it is a new element. Time O(nlogn) and Space O(1).
3. **Use a hash set**. When element exists in hash set, it is duplicate; otherwise add to hash set. Time O(n), Space O(n).

## Follow up - big array
What if the array is too large to put in memory? Apparently, we have to store all those strings in files. Then how can we find duplicate elements?

1. The array is very big so
	* We cannot simply use sorting.
	* We cannot use hashset because it is going to be big.
2. **Update**: we can use external sorting and use #1 to solve the problem.
	* sort two arrays and merge back to the disk. Keep the process until all data is sorted.
3. The source also gives a **File Pivot** solution - somehow buckets these strings. Each bucket can fit into memory and there're no duplicates among buckets. The tricky thing is how to bucket them in good ways so that each can fix in. 
4. The efficient is based on I/O instead of big O anymore. 

## Follow up - distributed data
What if the array is too large to fit in one node? We have to store all those strings in different nodes. How to find duplicate elements?

1. Similar to external sorting. Sort all string on every single machine and then get a master machine to read one string from every machine. It is `n-way merging sort`; we can minimize the network communication cost by read a small chuck of data from one machine at once. 
2. Partition - one machine owns one partition and other machines send data in that partition to that machine, so result from one machine is independent on others. The result is just a combination.
3. Partition is better because if one node is down, it only impacts that partition. In `external sorting` solution, one node failure would block the system.

# LC17 - Letter Combinations of a Phone Number
Problem: *given a digit string, find all letter combinations. Order doesn't matter.*. ([Source](https://leetcode.com/problems/letter-combinations-of-a-phone-number/#/description)). The mapping is,

* 1 -> abc
* 2 -> def
* ...
* 8 -> tuv
* 9 -> wxyz

```
public IList<string> GetCombinations(string digits);
```

## Analysis
The problem is very similar to string permutation.

1. We can either use a Queue or temporary list to do the work. Queue is probably more memory efficient depending on the underlying memory.

Edge case:

1. what return when string is empty.
2. calculate the start and end char for each digit.

## Learning
1. funny - operator precedence. `x.y` > `(x)y` > `?:`
2. I calculate start and end char by myself to save some memory; however, if we use a hard-code string array for the mapping, the code is better to maintain with few bugs. The memory cost is O(1).

# LC67 - Add Binary
Problem: *Given two binary strings, return their sum (also a binary string).*. [Source](https://leetcode.com/problems/add-binary/#/description)

For example,
```
a = "11"
b = "1"
Return "100".
```

## Analysis
1. Use two pointers and calculate from back to front. 
2. Use a flag to indicate whether we have an overflow.
3. Use StringBuilder to be more memory efficient.
4. Edge cases to be careful,
	* Empty string
	* 1111 + 1

## Learning
1. code is easy to write but StringBuilder doesn't have Reverse() method. I have to do `StringBuilder -> string -> CharArray -> Reverse() -> ToArray -> string`. In interview, I'll call a method `Reverse` on `StringBuilder`. In work, I'll add an extension method.

# LC215 - Kth Largest Element in an Array
*Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.* [Source](https://leetcode.com/problems/kth-largest-element-in-an-array/#/description)

For example,
```
Given [3,2,1,5,6,4] and k = 2, return 5.
```

Note: 
You may assume k is always valid, 1 ≤ k ≤ array's length.

## Learning
1. It takes me a while to implement the min-heap using C#. .NET doesn't have built-in support for that and no support for sorted list which allows duplicate elements. What I did is,
	* Create a Heap class.
	* Internally use SortedSet which doesn't allow duplicate elements.
	* Internally use a Dictionary to record each element count.
	* With the count, I determine when it is add or remove the unique element in SortedSet.
	* Memory O(k). Performance is good too.
