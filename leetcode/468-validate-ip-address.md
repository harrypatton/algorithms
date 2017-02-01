#468 - Validate IP Address
source: https://leetcode.com/problems/validate-ip-address/

Write a function to check whether an input string is a valid IPv4 or IPv6 address or neither.

``IPv4`` address

* four parts separated by dot.
* each part is a decimal number ranging from 0 to 255.
* no leading zero. E.g., 127.0.0.01 is invalid.

``IPv6`` address

* eight groups of four hexadecimal digits
* each group representing 16 bits
* The groups are separated by colons (":"). For example, the address ``2001:0db8:85a3:0000:0000:8a2e:0370:7334`` is a valid one. Also, we could 
* omit some leading zeros among four hexadecimal digits and some low-case characters in the address to upper-case ones, so ``2001:db8:85a3:0:0:8A2E:0370:7334`` is also a valid IPv6 address (Omit leading zeros and using upper cases).
* we don't replace a consecutive group of zero value with a single empty group using two consecutive colons (::) to pursue simplicity. For example, 2001:0db8:85a3::8A2E:0370:7334 is an invalid IPv6 address.
* Besides, extra leading zeros in the IPv6 is also invalid. For example, the address 02001:0db8:85a3:0000:0000:8a2e:0370:7334 is invalid. (the first part has 5 letter)

Note: You may assume there is no extra space or special characters in the input string.

##Idea
1. Set some scopes - min and max lengths
	* IPv4: min (7), max(15), separator is `.`
	* IPv6: min(15), max(39), separator is `:`
2. Uses separator to get substring
	* IPv4: 4 groups
	* IPv6: 8 groups
3. Check each substring if it meets the requirement.
	* IPv4
		* min(1), max(3)
		* Numeric number only
		* 0 - 255 range
		* no leading 0 (except the 0 alone)
* IPv6
		* min(1), max(4)
		* range: hexa, e,g., 0-9, a-F, A-F
		* Leading 0 is fine

##Solution
1. check length first so we know which category the checking will fall in.
	* length < 7 || length > 39 => Neither
	* 15 < Length <= 39 => check IPv6
	* 7 <= Length < 15 => check IPv4
	* Length == 15 => check both IPv4 and IPv6.
2. Validate separator. It can also distinguish the scenario when Length == 15.
3. Check each group then.

It is better to write a few helper functions.


##Learning
1. The main method includes too much details. It knows some length limitation. My original thought was to quickly check the result but we can wrap that in functions IsIPv4 and IsIPv6 - better encapsulation and the same performance gain.
