public class Solution_Stack {
    public bool IsValidSerialization(string preorder) {
        if (preorder == null) {
            return false;
        }
        
        var elements = preorder.Split(',');
        var stack = new Stack<string>();
        
        foreach(var element in elements) {
            if (element == "#") {                
                while(stack.Count >= 2 && stack.Peek() == "#") {
                    stack.Pop();
                    if (stack.Pop() == "#") {
                        return false;
                    }
                }
            }
            
            stack.Push(element);            
        }
        
        return stack.Count == 1 && stack.Peek() == "#";
    }
}

public class Solution_Recursion {
    public bool IsValidSerialization(string preorder) {
        if (preorder == null) {
            return false;
        } else {
            var letters = preorder.Split(',');
            return IsValidSerialization(letters, 0, letters.Length - 1);
        }
    }
    
    public bool IsValidSerialization(string[] letters, int start, int end) {
        var length = end - start + 1;
        
        if (length == 1 && letters[start] == "#") {
            return true;
        }
        
        if (length == 3 && letters[start] != "#" && letters[start + 1] == "#" && letters[start + 2] == "#") {
            return true;
        }
        
        if (length > 3 && letters[start] != "#") {
            for (int i = start+1; i < end; i++) {
                if (IsValidSerialization(letters, start+1, i) && IsValidSerialization(letters, i + 1, end)) {
                    return true;
                }
            }
        }
        
        return false;
    }
}
