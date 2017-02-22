public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var result = new List<IList<int>>();
        CombinationSum3(k, n, 0, 1, new List<int>(), result);
        return result;
    }
    
    public void CombinationSum3(int numberCount, int target, int sum, int start, IList<int> path, IList<IList<int>> result) {
        if (path.Count == numberCount && sum == target) {
            result.Add(new List<int>(path));
        } else if (path.Count > numberCount || sum > target) {
            return;
        }
        
        for(int i = start; i <= 9; i++) {
            path.Add(i);
            CombinationSum3(numberCount, target, sum + i, i + 1, path, result);
            path.Remove(i);
        }
    }
}
