public class Solution_ConstantSpace {
    public void SetZeroes(int[,] matrix) {
        if (matrix == null || matrix.GetLength(0) == 0) {
            return;
        }
        
        bool firstColumnZero = false;
        for(int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i,j] == 0) {
                    if (j == 0) {
                        firstColumnZero = true;
                    } else {
                        matrix[0, j] = 0;
                    }
                    
                    matrix[i, 0] = 0;
                }
            }
        }
        
        for(int i = 1; i < matrix.GetLength(0); i++) {
            for (int j = 1; j < matrix.GetLength(1); j++) {
                if (matrix[0,j] == 0 || matrix[i, 0] == 0) {
                    matrix[i, j] = 0;
                }
            }
        }
        
        if (matrix[0, 0] == 0) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                matrix[0, j] = 0;
            }
        }
        
        if (firstColumnZero) {
            for (int j = 0; j < matrix.GetLength(0); j++) {
                matrix[j, 0] = 0;
            }
        }
    }
}

public class Solution_MoreSpace {
    public void SetZeroes(int[,] matrix) {
        if (matrix == null) {
            return;
        }
        
        var zeroRows = new bool[matrix.GetLength(0)];
        var zeroColumns = new bool[matrix.GetLength(1)];
        
        for(int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i,j] == 0) {
                    zeroRows[i] = true;
                    zeroColumns[j] = true;
                }
            }
        }
        
        for(int i = 0; i < zeroRows.Length; i++) {
            if (zeroRows[i]) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    matrix[i, j] = 0;
                }
            }
        }
        
        for(int i = 0; i < zeroColumns.Length; i++) {
            if (zeroColumns[i]) {
                for (int j = 0; j < matrix.GetLength(0); j++) {
                    matrix[j, i] = 0;
                }
            }
        }
    }
}
