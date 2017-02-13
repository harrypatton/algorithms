public class Solution {
    public int NumberOfArithmeticSlices(int[] A) {
        if (A == null || A.Length < 3) {
            return 0;
        }
        
        // Init the state
        int start = 0;
        int index = 2;
        int diff = A[1] - A[0];
        int result = 0;
        
        while(index <= A.Length) {
            // when reach to end or detect the end of arithmetic
            if (index == A.Length || A[index] - A[index-1] != diff) {
                // calculate the result. When the sequence number is n,
                // the result is 1 + 2 + 3 + ... + n - 2
                // i.e., n*(n+1)/2 - n - (n-1)
                if (index - start >= 3) {
                    int n = index - start;
                    result += n * (n + 1) / 2 - n - (n-1);
                }
                
                // start with the new potential arithmetic
                if (index != A.Length) {
                    start = index - 1;
                    diff = A[index] - A[index-1];
                }
            }
            
            index++;
        }
        
        return result;
    }
}
