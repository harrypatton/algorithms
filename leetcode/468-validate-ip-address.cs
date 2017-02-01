public class Solution {
    public string ValidIPAddress(string IP) {
        const string Neither = "Neither";
        const string IPv6 = "IPv6";
        const string IPv4 = "IPv4";
            
        if (IP == null || IP.Length < 7 || IP.Length > 39) {
            return Neither;
        } else {
            int length = IP.Length;
        
            if (length > 15 && length <= 39) {
                return IsIPv6(IP) ? IPv6 : Neither;
            } else if (length >=7 && length <15) {
                return IsIPv4(IP) ? IPv4 : Neither;
            } else {
                return IsIPv4(IP) ? IPv4 : (IsIPv6(IP) ? IPv6 : Neither);
            }
        }
    }
    
    private bool IsIPv4(string ip) {
        var groups = ip.Split('.');
        
        if (groups.Length != 4) {
            return false;
        }
        
        foreach(var group in groups) {
            if (!IsIPv4Group(group)) {
                return false;
            }
        }
        
        return true;
    }
    
    private bool IsIPv4Group(string group) {
        // invalid length
        if (group == null || group.Length == 0 || group.Length > 3) {
            return false;
        }
        
        // leading zero
        if (group[0] == '0' && group.Length > 1) {
            return false;
        }
        
        // invalid letter
        foreach(var c in group) {
            if (!IsIPv4Letter(c)) {
                return false;
            }
        }
        
        int value = int.Parse(group);
        
        // invalid range
        if (value > 255) {
            return false;
        }
        
        return true;
    }
    
    private bool IsIPv4Letter(char c) {
        return IsNumber(c);
    }
    
    private bool IsIPv6(string ip) {
        var groups = ip.Split(':');
        
        if (groups.Length != 8) {
            return false;
        }
        
        foreach(var group in groups) {
            if (!IsIPv6Group(group)) {
                return false;
            }
        }
        
        return true;
    }
    
    private bool IsIPv6Group(string group) {
        // invalid length
        if (group == null || group.Length == 0 || group.Length > 4) {
            return false;
        }
        
        // invalid letter
        foreach(var c in group) {
            if (!IsIPv6Letter(c)) {
                return false;
            }
        }
        
        return true;
    }
    
    private bool IsIPv6Letter(char c) {
        return IsNumber(c) || (c >= 'a' && c <= 'f') || (c>='A' && c<='F');
    }
    
    private bool IsNumber(char c) {
        return c >= '0' && c<='9';
    }
}
