#406 - Queue Reconstruction by Height
source: https://leetcode.com/problems/queue-reconstruction-by-height/

Each person is described by a pair `(h, k)`. `h` is the person height and `k` the number of persons in front of this person whose `height >= h`.

# Analysis
Brutal force can work but inefficient.

**Sort**

1. For elements with the same height, it must be ordered by `k` (because the condition is `height >= h`.
2. If `height[element_A] > height[element_B]`, 
	* if `k` is the same, B must be in front.
	* if `k_A > k_B`, B must be in front.
	* if `k_A < k_B`
		* B in front? possibly
		* B in end? possibly

**Update**: I cannot find a good solution within 10 minutes.

After reading the discussion page, here's the idea (and we still use Sort.1 idea)

1. Pick up the tallest group. In the group, every person is sorted by the number and put in a result array.
2. After that, pick up next tallest group. Like #1, it starts with person with smallest number and insert the result array based on number.
3. Finish the iteration.
4. In coding, I sort person by height in descending order and then number in ascending order. After that, I just keep inserting the element in new array based on the number.
