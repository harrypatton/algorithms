public class Solution {
    public int CountSegments(string s) {
        const char Space = ' ';
        int result = 0;
        
        // check null or empty string
        if (s == null || s == string.Empty) {
            return result;
        }        
        
        for(int i = 0; i < s.Length; i++) {
            // count 1 when run into a space and previous char is not space.
            if(i > 0 && s[i] == Space && s[i-1] != Space) {
                result++;
            }
        }
        
        // we need to handle the case that the string ending with a word
        if (s[s.Length - 1] != Space) {
            result++;
        }
        
        return result;
    }
}
