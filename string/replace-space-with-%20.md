#Origin
* http://algorithms.tutorialhorizon.com/replace-all-spaces-in-a-string-with/

#Overview
**Objective**: 
Replace all spaces in a given string with '%20'. Assume the char array has enough room to hold the converted string.

#Ideas
It is similar to encoding a string in URL except the latter has more escape chars.

Assume moving char is expensive so we can,

1. Calculate how many spaces we have.
2. Maintain two pointers - source and destination.
3. Move two pointers from end to start.

#Learning
