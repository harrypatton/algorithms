public class Solution {
    public bool IsValid(string s) {
        // invalid scenario
        if (s == null || s.Length < 2) {
            return false;
        }
        
        var stack = new Stack<char>();
        
        foreach(var c in s) {
            switch(c) {
                case '{':
                case '[':
                case '(':
                    stack.Push(c);
                    break;
                case '}':
                    if (stack.Count == 0 || stack.Pop() != '{') {
                        return false;
                    }
                    break;
                case ']':
                    if (stack.Count == 0 || stack.Pop() != '[') {
                        return false;
                    }
                    break;
                case ')': 
                    if (stack.Count == 0 || stack.Pop() != '(') {
                        return false;
                    }
                    break;
            }
        }
        
        return stack.Count == 0;
    }
}
