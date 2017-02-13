public class Solution {
    public string ToHex(int num) {
        // handle edge cases
        if (num == 0) {
            return "0";
        }
        
        string result = string.Empty;
        int count = 0;
        
        // Use f as mask to check every 4 bits from right to left.
        // when shift negative number to the right, C# adds 1 to fill in left part.
        // We need to use variable count to avoid infinite loop here.
        while(num != 0 && count < 8) {
            count ++;
            
            // save the result
            int tempNum = num & 15;
            result = GetHex(tempNum) + result;

            // Move to next 4 bits on left
            num = num >> 4;
        }
        
        return result;
    }
    
    public string ToHex_Original(int num) {
        // handle edge cases
        if (num == 0) {
            return "0";
        }
        
        var result = new List<char>();
        
        // Use f as mask to check every 4 bits from right to left.
        for(int i = 0; i < 8; i++) {
            // exit because we don't want to add leading zero
            if (num == 0) {
                break;
            } else {
                // save the result
                int tempNum = num & 15;
                result.Add(GetHex(tempNum));
                
                // Move to next 4 bits on left
                num = num >> 4;
            }
        }
        
        // Reverse and get the result
        result.Reverse();
        return new string(result.ToArray());
    }
    
    public char GetHex(int num) {
        if (num >= 0 && num <= 9) {
            return (char)(num + '0');
        } else {
            return (char)((num - 10) + 'a');
        }
    }
}
