public class Solution_backtracking {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        var result = new List<IList<int>>();
        if (candidates == null) {
            return result;
        }
        
        Array.Sort(candidates);
        Backtracking(candidates, target, 0, new List<int>(), result, 0);
        
        return result;
    }
    
    public void Backtracking(int[] candidates, int target, int sum, IList<int> set, IList<IList<int>> result, int start) {
        // found match, add to result
        if (sum == target) {
            result.Add(new List<int>(set));
        } else if (sum > target) {
            return;
        }
        
        for (int i = start; i < candidates.Length; i++) {
            if (i == start || candidates[i] != candidates[i-1]) {
                set.Add(candidates[i]);
                Backtracking(candidates, target, sum + candidates[i], set, result, i+1);
                set.Remove(candidates[i]);
            }
        }
    }
}
