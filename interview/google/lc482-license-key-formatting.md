source: https://leetcode.com/problems/license-key-formatting/#/description

See source for more details.

## Discussion Page
```java
public String licenseKeyFormatting(String s, int k) {
    StringBuilder sb = new StringBuilder();
    for (int i = s.length() - 1; i >= 0; i--)
        if (s.charAt(i) != '-')
            sb.append(sb.length() % (k + 1) == k ? '-' : "").append(s.charAt(i));
    return sb.reverse().toString().toUpperCase();
} 
```

## Orignal Code
It is not as clean as the discussion solution. 

1. I proactively add the `-` after `K` chars. It may cause extra `-` added if original string
has extra dashes. The discussion page adds it only if it is necessary (i.e., add dash when `K+1` chars are added).
2. I allocates more memory than necessary because StringBuilder.Insert is more expensive (not `O(1)`). 
Discussion page use StringBuild.Append, but it has Reverse method in Java. C# doesn't have it.

```c#
/*
1. Assume we always have a valid result.
2. It doesn't require in-place algorithm.
3. we can allocate an array and scan from end to start with K non-dash letters followed by a dash.
*/
public class Solution {
    public string LicenseKeyFormatting(string S, int K) {
    	if (S == null || K<=0) return null;
    	// if (S.Length < K) return null; => this is wrong because the whole string could be the first part.

        var result = new char[S.Length + S.Length/K];
        var index = result.Length - 1;
        var count = 0;
        for(int i = S.Length - 1; i >= 0; i--) {
        	if(S[i] != '-') {
        		result[index--] = char.ToUpper(S[i]);
        		count++;
        	}

        	if (count == K) {
        		count = 0;
        		if (index >= 0) result[index--] = '-';
        	}
        }

        // add a lot of edge cases because 
        // 1. the string may not have enough dashes
        // 2. the string may have more dashes
        // 3. the string may contain only dashes
        if (index == result.Length - 1) return "";
        else if (result[index+1] == '-') index += 2;
        else index++;

        var newString = new char[result.Length - index];
        Array.Copy(result, index, newString, 0, result.Length - index);

        return new string(newString);
    }
}
```
