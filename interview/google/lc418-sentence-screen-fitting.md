source: https://leetcode.com/problems/sentence-screen-fitting/#/description

## Analysis
1. I use the native solution to solve the problem. The code works but show time out for big board.

## Discussion Page
1. Combine the string with space and see how many words we can fit on each row. 
2. If ending with space or next one is space, we continue to next row;
3. otherwise backtracking current position.

```c#
public class Solution {
    public int WordsTyping(string[] sentence, int rows, int cols) {
        if(sentence == null || sentence.Length == 0) return 0;

        var s = string.Join(" ", sentence) + " ";
		int start = 0;
		for(int i = 0; i < rows; i++) {
			start += cols;
			var p = start % s.Length;
			
			if (s[p] == ' ') { // fit
				start++; 
				continue;
			}
			
			if (p >= 1 && s[p-1] == ' ') continue; // fit
			
			// don't fit. find new position which previous letter is space.
			while(p >=1 && s[p-1] != ' ') {
				p--;
				start--;
			}
		}
		
		return start / s.Length;
    }
}
```
