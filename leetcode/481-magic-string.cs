public class Solution {
    public int MagicalString(int n) {
        if (n<=0) {
            return 0;
        }
        
        if (n <= 3) {
            return 1;
        }
        
        var magicalString = new char[n];
        magicalString[0] = '1';
        magicalString[1] = '2';
        magicalString[2] = '2';
        int result = 1;
        int count_pointer = 2;
        int index = 3;
                
        while(index < n) {
            // get next letter to add
            char letter = magicalString[index - 1] == '1' ? '2' : '1';
            
            // how many count to add
            int count = magicalString[count_pointer++] == '1' ? 1 : 2;
            
            // add to the string and update result
            for(int i = 0; i < count && index < n; i++) {
                magicalString[index++] = letter;
                
                if (letter == '1') {
                    result++;
                }
            }
        }
        
        return result;
    }
}
