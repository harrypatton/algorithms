#Smallest Good Base
For an integer n, we call k>=2 a good base of n, if all digits of n base k are 1.

Now given a string representing n, you should return the smallest good base of n in string format. 

n is given as a string with base 10.

##Observation
111111 based on k is,
```
Value = K^0 + K^1 + K^2 + ... + K^(n-1)
K*Value = K^1 + K^2 + ... + K^(n-1) + K^n
1+k*Value = 1 + K^1 + K^2 + ... + K^(n-1) + K^n
1+k*Value = Value + K^n
Value = (K^n - 1) / (K - 1).
```

The question is, given a Value, find out the minimum K (and n could be any number.)

In other words,
```
1. K^n = 1 + (K-1)*Value

For K = 2 to Value - 1,
1. (value - 1) % k should be zero.
2. Get new value = (value - 1) / k; and repeat #2 until it is ZERO.

```

Here's my code

```
public class Solution {
    public string SmallestGoodBase(string n) {
        long value = Convert.ToInt64(n);
        
        for(int k = 2; k<=value-1; k ++) {
            long tempValue = value;
            
            while(tempValue != 0 && (tempValue - 1) % k == 0) {
                tempValue = (tempValue - 1) / k;
            }
            
            if (tempValue == 0) {
                return k.ToString();
            }
        }
        
        return null;
    }
}
```

The code works fine but **performance sucks**. We have to think about bit shift operator.

I give up now and will come back later.
