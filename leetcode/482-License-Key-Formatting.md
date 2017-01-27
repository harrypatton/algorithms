#License Key Formatting
Given a string S and length k
1. Split the string into a small groups. Each group except the first one has k letters.
	* 1 <= first_group_length <= k
2. Group is separated by dash and no dash inside the group string. It means, we need to skip dashes in original string.
3. Lower case letter must be converted to upper case letter.

#Idea
The problem seems easy to solve.

1. First iteration to find out alphanumerical char count without dashes. say alpha_num_count.
2. In the result, the dash count = (alpha_num_count / 4) - 1. If (alpha_num_count % 4 != 0), add another dash.
3. Allocate a string which length is (dash_count + alpha_num_count).
4. Iterate original string from backward.
	* Ignore dash.
	* Need a pointer to result string. Set a counter to K. When it becomes 0, add dash to result string.

Just be careful about edge cases. 

**I said it before coding, and the reality still shows it is true. I spent a lot of time in the following two edge cases.**
* when alphaNumCount is 0
* when we adds all required letter but original string still has other strings to iterate like dash. I should have used ``resultIndex`` to guard the condition when ``counter == 0``.

```
public class Solution {
    public string LicenseKeyFormatting(string S, int K) {
        const char Dash = '-';
        
        if (S == null || S == string.Empty || K <= 0) {
            return string.Empty;
        }
        
        // TODO: check if char is alphanumberic char and dash only.
        // TODO: check if all chars are dashes.
        
        int alphaNumCount = 0;
        foreach(var c in S) {
            if (c != Dash) {
                alphaNumCount++;
            }
        }
        
        // If no letter, return null.
        if (alphaNumCount == 0) {
            return string.Empty;
        }
        
        int dashCountInResultString = alphaNumCount / K - 1 + (alphaNumCount % K == 0 ? 0 : 1);
        int resultStringCount = alphaNumCount + dashCountInResultString;
        
        var result = new char[resultStringCount];
        var resultIndex = resultStringCount - 1;
        var counter = K;
        
        for(int i = S.Length - 1; i >= 0; i--) {
            if (S[i] != Dash) {
                result[resultIndex--] = char.ToUpper(S[i]);
                counter--;
                
                // the 2nd condition is very important to make sure we don't add dash if unnecessary
                if (counter == 0 && resultIndex>=0) {
                    counter = K;
                    result[resultIndex--] = Dash;
                }
            }
        }
        
        return new string(result);
    }
}
```
