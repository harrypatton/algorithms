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
