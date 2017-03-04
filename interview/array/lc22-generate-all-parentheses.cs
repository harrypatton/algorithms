public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();
        GenerateParenthesis(n, result, string.Empty, n, n);
        return result;
    }
    
    public void GenerateParenthesis(int n, IList<string> list, string currentResult, int openCount, int closeCount) {
        if (currentResult.Length == 2 * n) {
            list.Add(currentResult);
            return;
        }
        
        if (openCount > 0) {
            GenerateParenthesis(n, list, currentResult + "(", openCount - 1, closeCount);
        }
        
        if (openCount < closeCount) {
            GenerateParenthesis(n, list, currentResult + ")", openCount, closeCount - 1);
        }
    }
}
