public class Solution {
    public IList<int[]> PacificAtlantic(int[,] matrix) {
        var result = new List<int[]>();
        
        if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) {
            return result;
        }
        
        // handle pacific state
        bool[,] pacificState = new bool[matrix.GetLength(0), matrix.GetLength(1)];
        
        for(int i = 0; i < matrix.GetLength(0); i++) {
            pacificState[i, 0] = true;
        }
        
        for(int i = 0; i < matrix.GetLength(1); i++) {
            pacificState[0, i] = true;
        }
        
        while(true) {
            var changed = UpdateViaTopLeft(matrix, pacificState);
            changed |= UpdateViaDownRight(matrix, pacificState);
            
            if (!changed) {
                break;
            }
        }
                
        // handle atlantic state
        bool[,] atlanticState = new bool[matrix.GetLength(0), matrix.GetLength(1)];
        
        for(int i = 0; i < matrix.GetLength(0); i++) {
            atlanticState[i, matrix.GetLength(1) - 1] = true;
        }
        
        for(int i = 0; i < matrix.GetLength(1); i++) {
            atlanticState[matrix.GetLength(0) - 1, i] = true;
        }
        
        while(true) {
            var changed = UpdateViaDownRight(matrix, atlanticState);
            changed |= UpdateViaTopLeft(matrix, atlanticState);
            
            if (!changed) {
                break;
            }
        }        
        
        // handle result
        for(int i = 0; i < matrix.GetLength(0); i++) {
            for(int j = 0; j < matrix.GetLength(1); j++) {
                if (pacificState[i, j] && atlanticState[i,j]) {
                    result.Add(new int[]{i, j});
                }
            }
        }
        
        return result;
    }
    
    private bool UpdateViaTopLeft(int[,] matrix, bool[,] state) {
        int result = false;
        int rowCount = matrix.GetLength(0);
        int columnCount = matrix.GetLength(1);
        
        for(int i = 0; i < rowCount; i++) {
            for (int j = 0; j < columnCount; j++) {
                if (!state[i, j] && ((i > 0 && state[i-1, j] && matrix[i,j] >= matrix[i-1, j]) || (j > 0 && state[i, j-1] && matrix[i,j] >= matrix[i, j-1]))) {
                        state[i,j] = true;
                        result = true;
                    }
            }
        }
        
        return result;
    }
    
    private bool UpdateViaDownRight(int[,] matrix, bool[,] state) {
        int result = false;
        int rowCount = matrix.GetLength(0);
        int columnCount = matrix.GetLength(1);
        
        for(int i = rowCount - 1; i >= 0; i--) {
            for (int j = columnCount - 1; j >= 0; j--) {
                if (!state[i, j] && ((i + 1 < rowCount && state[i+1, j] && matrix[i,j] >= matrix[i+1,j]) || (j + 1 < columnCount && state[i, j+1] && matrix[i,j] >= matrix[i, j+1]))) {
                        state[i,j] = true;
                        result = true;
                    }
            }
        }
        
        return result;
    }
}
