#405 - Convert a Number to Hexadecimal
Source: https://leetcode.com/problems/convert-a-number-to-hexadecimal/

## Analysis
1. Usually start with least significant position. Use Mod 16 to get the bit value and then move to next (i.e., `num / 16`) until the value is zero.
2. The tricky part is to handle negative number. 
* It is represented by [two's complement](https://en.wikipedia.org/wiki/Two%27s_complement) (i.e., `get the positive part, flip all bits and add 1`).
* `max + 1 + num` will mask the signal bit. We can start with that number. When calculate the most significant part, we need to add that one back (i.e, add 8).

**Update**: the above solution doesn't work well for so many edge cases like 0, -1, Min and Max.

Here's a new solution I think it is better,
1. iterate 8 times
2. the bit would be `num & 15`. `f` is 15 instead of 16.
	* if **updated num is zero**, stop because we don't need leading zero.
3. reverse the string.

## Learning
1. When convert `int` to `char`,  it needs `explicit cast`.
2. Be careful about edge scenarios.
3. Instead of using `List<char>`, we can just use string `+ operator`. It would avoid the reverse in the end and performance is still good because of the small size of result.
4. Instead of using hardcode `8 loop count`, we just use `while (num > 0)` to reduce the check inside the loop.
