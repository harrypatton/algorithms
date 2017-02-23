public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var result = new List<IList<int>>();
        
        if (nums == null) {
            return result;
        }
        
        // init an empty collection
        result.Add(new List<int>());
        
        foreach(var num in nums) {
            int count = result.Count;
            for(int i = 0; i < count; i++) {
                // Count + 1 positions to insert.
                for(int j = 0; j <= result[i].Count; j++) {
                    var list = new List<int>(result[i]);
                    list.Insert(j, num);
                    result.Add(list);
                }
            }
            
            // remove unused data.
            for(int i = 0; i < count; i++) {
                result.RemoveAt(0);
            }
        }
        
        return result;
    }
}
