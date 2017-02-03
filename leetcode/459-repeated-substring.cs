public class Solution {
    public bool RepeatedSubstringPattern(string str) {
        if (str == null || str == string.Empty) {
            return false;
        }
        
        for(int subStringLength = str.Length / 2; subStringLength > 0; subStringLength--) {
            if (str.Length % subStringLength == 0) {
                if (IsRepeated(str, subStringLength)) {
                    return true;
                }
            }
        }

        return false;
    }
    
    private bool IsRepeated(string str, int subStringLength) {
        int subStringCount = str.Length / subStringLength;

        // use the string length to test out
        for(int i = 0; i < subStringLength; i++) {
            for(int j = 1; j < subStringCount; j++) {
                if (str[i + j * subStringLength] != str[i + (j - 1) * subStringLength]) {
                    return false;
                }
            }
        }

        return true;
    }
}
