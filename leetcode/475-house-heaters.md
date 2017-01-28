#475 - Heaters
source: https://leetcode.com/problems/heaters/

Winter is coming! Your first job during the contest is to design a standard heater with fixed warm radius to warm all the houses.

Now, you are given positions of houses and heaters on a horizontal line, find out minimum radius of heaters so that all houses could be covered by those heaters.

So, your input will be the positions of houses and heaters seperately, and your expected output will be the minimum radius standard of heaters.

**Note**
* Numbers of houses and heaters you are given are non-negative and will not exceed 25000.
* Positions of houses and heaters you are given are non-negative and will not exceed 10^9.
* As long as a house is in the heaters' warm radius range, it can be warmed.
* All the heaters follow your radius standard and the **warm radius will the same**.

##Idea
Each house choose closest heater and then we choose the max radius.
* after choose the closest heater, we can skip all houses between them.

Brutal force - O(n^2). Each house compares with every heater.

We can also use binary search to find the closet heater, so it will be O(nlogm). n is house number and m is heater number. Be careful to handle when it cannot find an element.

##Naive Solution
```
public class Solution {
    public int FindRadius(int[] houses, int[] heaters) {
        int result = 0;
        
        foreach(var house in houses) {
            int minRadius = int.MaxValue;
            
            foreach(var heater in heaters) {
                minRadius = Math.Min(minRadius, Math.Abs(house - heater));
            }
            
            result = Math.Max(result, minRadius);
        }
        
        return result;
    }
}
```

##Binary Search Solution
Be careful about the edge scenarios.

```
public class Solution {
    public int FindRadius(int[] houses, int[] heaters) {
        Array.Sort(houses);
        Array.Sort(heaters);
        
        int result = 0;
        
        foreach(var house in houses) {
            int minRadius = 0;            
            int index = Array.BinarySearch(heaters, house);
            
            // if find, it returns 0
            // otherwise it returns a negative of the complement of next 
            // larger element (or length when there is no larger element)
            if (index < 0) {
                index = ~index;
                
                if (index == heaters.Length) {
                    minRadius = house - heaters[heaters.Length - 1];
                } else if (index == 0) {
                    minRadius = heaters[0] - house;
                } else {
                    minRadius = Math.Min(heaters[index] - house, house - heaters[index - 1]);
                }
            }
            
            result = Math.Max(result, minRadius);
        }
        
        return result;
    }
}
```
