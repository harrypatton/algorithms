public class Solution {
    public string AddBinary(string a, string b) {
        if (a == null || b == null) {
            return a == null ? b : a;
        }
        
        int index1 = a.Length - 1;
        int index2 = b.Length - 1;
        bool overflow = false;
        var result = new StringBuilder();
        
        while(index1 >= 0 || index2 >= 0) {
            char digit1 = index1 >= 0 ? a[index1] : '0';
            char digit2 = index2 >= 0 ? b[index2] : '0';
            
            if (digit1 == digit2) {
                result.Append(overflow ? "1" : "0");
                overflow = digit1 == '1';
            } else {
                result.Append(overflow ? "0" : "1");
            }
            
            index1--;
            index2--;
        }
        
        if (overflow) {
            result.Append("1");
        }
        
        return new string(result.ToString().ToCharArray().Reverse().ToArray());
    }
}
