public class Solution {
    public int MaxRotateFunction(int[] A) {
        if (A == null) {
            return 0;
        }
        
        int current = 0;
        int sum = 0;
        
        for(int i = 0; i < A.Length; i++) {
            current += i * A[i];
            sum += A[i];
        }
        
        int max = current;
        
        for(int i = A.Length - 1; i >= 1; i--) {
            current = current + sum - A.Length * A[i];
            max = Math.Max(max, current);
        }
        
        return max;
    }
}
