public class Solution {
    public int NumberOfBoomerangs(int[,] points) {
        if (points == null || points.GetLength(0) == 0) {
            return 0;
        }
        
        int count = 0;
        
        for(int i = 0; i < points.GetLength(0); i++) {
            var distanceMapping = new Dictionary<double, int>();
            
            // calculate distances with other elements
            for(int j = 0; j < points.GetLength(0); j++) {
                if (j != i) {
                    var distance = GetDistance(points[i,0], points[i,1], points[j,0], points[j,1]);
                    distanceMapping[distance] = distanceMapping.ContainsKey(distance) ? distanceMapping[distance] + 1 : 1;
                }
            }
            
            // calculate the result
            foreach(int mappingCount in distanceMapping.Values) {
                if (mappingCount > 1) {
                    count += mappingCount * (mappingCount - 1);
                }
            }
        }
        
        return count;
    }
    
    private double GetDistance(int x1, int y1, int x2, int y2) {
        // no need to calculate Sqrt. current one is good enough to be dictionary key.
        return Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2);
    }
}
