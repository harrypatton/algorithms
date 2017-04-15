Allocate and release id in the range of [0, N], allocate和relase都要是o(1).

## Analysis
This is an interesting idea,

1. define an index starting from 0 and a released queue.
2. when allocate, pick up one from released queue. 
  * If the queue is empty, increase the index and return.
  * Need to check if index exceeds the max one.
3. when release, add the one to the queue.

## follow up 1: id分配完了怎么办，多次release 同一个id怎么办。
1. if no id, throw exception in above solution.
2. release the id multiple times, we use a hash table to check or bitmap. (n/8 bytes).

## follow up 2: 如何减小内存花销，allocate的复杂度可以是o(n) -->使用bitmap
yes, bitmap is good choice in this case. Hash table consumes too much memory.

## follow up 3: 如何在内存和效率上实现一个折衷，使用比bitmap多一些的内存，但是搜索接近o(1).
Similar to find duplicate files on a huge amount of file list. Use bucket bitmap to indicate whether this bucket has id or not.
After digging into the bucket, use the traditional bitmap way.

Say, N is 1 million. Single bitmap requires `O(1m)`. If we bucket 1m into 1k. the smallest bitmap is 1k size, and the biggest one is still 1m size.
The runtime would be `O(1k) to find bucket and O(1k) to find element = O(1k)`. 

For the first bitmap, we may have to use a normal array. Each element has a count to indicate whether it is full or not.
