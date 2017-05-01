Source: https://leetcode.com/problems/expression-add-operators/#/description

Given a string that contains only digits 0-9 and a target value, return all possibilities to add binary operators (not unary) +, -, or * between the digits so they evaluate to the target value.

Examples: 
```
"123", 6 -> ["1+2+3", "1*2*3"] 
"232", 8 -> ["2*3+2", "2+3*2"]
"105", 5 -> ["1*0+5","10-5"]
"00", 0 -> ["0+0", "0-0", "0*0"]
"3456237490", 9191 -> []
```

# Analysis
1. Backtracking: I use BFS to calculate the result. Apparently it is wrong because it doesn't consider the case when multiple digit letter become the number.
e.g., "105", 5 -> ["1*0+5","10-5"]

```c#
    public class Solution {
        private IList<string> result = new List<string>();

        public IList<string> AddOperators(string num, int target) {
            BFS(num, target, "");
            return result;
        }

        private void BFS(string num, int target, string subResult) {
            if (num.Length == 0) return;

            int value = num[0] - '0';

            if (num.Length == 1) {
                if (target == value) result.Add(subResult + num[0].ToString());
                return;
            }
            
            // try +
            BFS(num.Substring(1), target - value, subResult + num[0].ToString() + "+");

            // try -
            BFS(num.Substring(1), value - target, subResult + num[0].ToString() + "-");

            // try * - we should try all of them.
            int sum = value;
            string prodResult = num[0].ToString();
            for (int i = 1; i < num.Length; i++) {
                sum *= num[i] - '0';
                prodResult += "*" + num[i].ToString();

                // try +
                BFS(num.Substring(i + 1), target - sum, subResult + prodResult + "+");

                // try -
                BFS(num.Substring(i + 1), sum - target, subResult + prodResult + "-");
            }

            if (sum == target) {
                result.Add(subResult + prodResult);
            }
        }
    }
```
# Update
This is a solution from discussion page. Very smart to handle zero leading, multiple digit number and the production scenarios.

```c#
    public class Solution {        
        public IList<string> AddOperators(string num, int target) {
            var result = new List<string>();
            Helper(result, path: "", num: num, target: target, pos: 0, eval: 0, multiple: 0);
            return result;
        }

        private void Helper(IList<string> result, string path, string num, int target, int pos, long eval, long multiple) {
            if (pos == num.Length) {
                if (target == eval) result.Add(path);
                return;
            }

            for(int i = pos; i < num.Length; i++) {
                // in this case, we cannot have a number with leading zero so we return it immediately.
                if (num[pos] == '0' && i != pos) break;

                string currentValueStr = num.Substring(pos, i - pos + 1);
                long currentValue = Convert.ToInt64(currentValueStr);

                if (pos == 0) {
                    Helper(result, path + currentValueStr, num, target, i + 1, eval + currentValue, currentValue);
                } else {
                    Helper(result, path + "+" + currentValueStr, num, target, i + 1, eval + currentValue, currentValue);
                    Helper(result, path + "-" + currentValueStr, num, target, i + 1, eval - currentValue, -currentValue);
                    Helper(result, path + "*" + currentValueStr, num, target, i + 1, eval - multiple + currentValue * multiple, currentValue * multiple);
                }
            }
        }        
    }
```
