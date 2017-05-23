source: https://leetcode.com/problems/encode-and-decode-strings/#/description

Design an algorithm to encode a list of strings to a string. 
The encoded string is then sent over the network and is decoded back to the original list of strings.

Machine 1 (sender) has the function:
```c++
string encode(vector<string> strs) {
  // ... your code
  return encoded_string;
}
```

Machine 2 (receiver) has the function:
```c++
vector<string> decode(string s) {
  //... your code
  return strs;
}
```

The string may contain any possible characters out of 256 valid ascii characters. 
Your algorithm should be generalized enough to work on any possible characters.

## Analysis
1. char is out of 256 letters.
2. we can do hash -> integer. Wait. hash cannot support decode.
3. use a special char say (257) as separator. very naive one. This works fine.
4. use 16-bit to do the char combination, because c# is 16-bit. how to separate then?
5. use "length" + "/" as the separator.

```c#
public class Codec {

    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs) {
        if (strs == null) return null;
        else if (strs.Count == 0) return "";
        
        var sb = new StringBuilder();
        foreach(var s in strs) {
            sb.Append(s.Length).Append("/").Append(s);
        }
        
        return sb.ToString();
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s) {
        var result = new List<string>();
        if (s == null) return null;
        else if (s == "") return result;
        
        int i = 0;
        while(i < s.Length) {
            int separator = s.IndexOf('/', i);
            int len = Convert.ToInt32(s.Substring(i, separator - i));
            result.Add(s.Substring(separator + 1, len));
            i = separator + len + 1;
        }
        
        return result;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));
```
