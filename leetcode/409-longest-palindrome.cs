public class Solution {
    public int LongestPalindrome(string s) {
        if (s == null) {
            return 0;
        }
        
        var charCount = new Dictionary<char, int>();
        foreach(var c in s){
            charCount[c] = charCount.ContainsKey(c) ? charCount[c] + 1 : 1;
        }
        
        bool hasOdd = false;
        int result = 0;
        
        foreach(var value in charCount.Values) {
            if (value % 2 == 1) {
                hasOdd = true;
                result += value - 1;
            } else {
                result += value;
            }
        }
        
        return hasOdd ? result + 1 : result;
    }
}
