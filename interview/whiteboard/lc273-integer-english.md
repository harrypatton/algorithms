[Source](https://leetcode.com/problems/integer-to-english-words/#/description)

Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 2^31 - 1.

For example,

```
123 -> "One Hundred Twenty Three"
12345 -> "Twelve Thousand Three Hundred Forty Five"
1234567 -> "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
```

## Analysis
1. Not hard to come up with a good solution. Handling every K as a helper function.
2. The whole function is a little bit long so it is easy to get bugs. Need to carefully check out.

```csharp
public class Solution {
    private string[] Num1_10_Map = new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten"};
    private string[] Num20_90_Map = new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
    private string[] Num11_19_Map = new string[] {"Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
    private string[] kMap = new string[] {"Billion", "Million", "Thousand"};
        
    public string NumberToWords(int num) {
        if (num == 0) return "Zero";
        int count = 1000 * 1000 * 1000;
        var result = new StringBuilder();
        
        for(int i = 0; i < 4; i++) {
            int tempNum = num / count;
            num = num % count;
            count = count / 1000;
            
            if (tempNum != 0) {
                if (result.Length > 0) result.Append(" ");

                result.Append(GetWordsFor3Digits(tempNum));
                
                if (i <= 2) result.Append(" " + kMap[i]);
            }
        }
        
        return result.ToString();
    }
    
    public string GetWordsFor3Digits(int num) {
        if (num == 0) {
            return "";
        }
        
        var result = new StringBuilder();
        int hundred = num / 100;
        num = num % 100;
        
        if (hundred != 0) {
            result.Append(Num1_10_Map[hundred - 1] + " Hundred");
        }
        
        if (num > 0) {            
            if (result.Length > 0) result.Append(" ");
            
            if (num <= 10) {
                result.Append(Num1_10_Map[num - 1]);
            } else if (num < 20) {
                result.Append(Num11_19_Map[num - 11]);
            } else {
                int douleDigit = num / 10;
                num = num % 10;
                result.Append(Num20_90_Map[douleDigit - 2]);

                if (num != 0) {
                    result.Append(" " + Num1_10_Map[num - 1]);
                }
            }
        }
        
        return result.ToString();
    }
}
```
