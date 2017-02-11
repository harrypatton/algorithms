#424 - Longest Repeating Character Replacement
source: https://leetcode.com/problems/longest-repeating-character-replacement/

Given a string that consists of only uppercase English letters, you can replace any letter in the string with another letter at most k times. Find the length of a longest substring containing all repeating letters you can get after performing the above operations.

Note:
Both the string's length and k will not exceed 104.

## Clarification
1. A letter in replaced with another letter from the same string. (of course, otherwise choosing an existing letter as the repeating letter can get longer substring).
2. `containing all repeating letters` means all letters in the substring are the same.

## Analysis
1. If `k` >= s.Length - 1, the result is s.Length. We can repeat the first letter.
2. When each letter is unique, it doesn't matter which letter to start. Just pick up k letter and convert to the first one. The longest repeating substring is `k+1`.
3. Now there are some repeating letters. There might be interval between those repeating letters. The longest way must be using `k` to fill in the interval gap.
    * assume we have each repeating position, then we can have a loop to test which starting position can cover most positions using the `k`. The result would be `k + convered_position_count`.
4. Idea from #3. Iterate on every letter. 
    * for each letter, loop from next char to last char,
        * if the letter is not the same, k--.
        * if the letter is the same, do nothing.
        * when k becomes 0, quite the loop.
    * always track the must one.
    * time complexity: O(n*k). not efficient because we have to check duplicate strings (the only difference is the first or last letter).
    
    
I feel like #3 is the right solution but cannot find a good way to calculate longest substring in O(n) time.

The code below works ok but too slow. The edge case is tricky as well.

```csharp
public class Solution {
    public int CharacterReplacement(string s, int k) {
        if (s == null || s == string.Empty) {
            return 0;
        }
        
        if (k >= s.Length - 1) {
            return s.Length;
        }
        
        int max = 0;
        for(int i = 0; i < s.Length; i++) {
            int counter = k;
            int j = i + 1;
            
            while (j < s.Length && counter >= 0) {
                if (s[i] != s[j] ) {
                    counter--;
                }

                j++;
            }
            
            max = Math.Max(max, j - i + counter);
        }
        
        return max > s.Length ? s.Length : max;
    }
}
```
