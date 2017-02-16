public class Solution {
    public struct Edge {
        public string Start;
        public string End;
        
        public Edge(string start, string end) {
            this.Start = start;
            this.End = end;
        }
    }
    
    public double[] CalcEquation(string[,] equations, double[] values, string[,] queries) {
        // check parameters
        
        var edgeSet = new Dictionary<Edge, double>();
        
        for(int i = 0; i < equations.GetLength(0); i++) {
            string start = equations[i, 0];
            string end = equations[i, 1];
            edgeSet[new Edge(start, end)] = values[i];
            edgeSet[new Edge(end, start)] = 1.0 / values[i];
            edgeSet[new Edge(start, start)] = 1.0;
            edgeSet[new Edge(end, end)] = 1.0;
        }
        
        var result = new double[queries.GetLength(0)];
        for(int i = 0; i < queries.GetLength(0); i++) {
            var visited = new HashSet<string>();
            var subResult = Calc(edgeSet, visited, queries[i, 0], queries[i, 1]);            
            result[i] = subResult.HasValue ? subResult.Value : -1.0;
        }
        
        return result;
    }
    
    public double? Calc(Dictionary<Edge, double> edgeSet, HashSet<string> visited, string start, string end) {
        visited.Add(start);
        
        var edge = new Edge(start, end);
        
        if (edgeSet.ContainsKey(edge)) {
            return edgeSet[edge];
        }
        
        var ends = edgeSet.Keys.Where(e => e.Start == start).Select(e => e.End);
        foreach(var newStart in ends) {
            if (!visited.Contains(newStart)) {
                visited.Add(newStart);                
                var result = Calc(edgeSet, visited, newStart, end);
                
                if (result.HasValue) {
                    edgeSet[edge] = edgeSet[new Edge(start, newStart)] * result.Value;
                    return edgeSet[edge];
                }
            }
        }
        
        return null;
    }
    
}
