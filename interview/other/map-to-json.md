# Json string output

Print out `Map<string, object>` as Json string

Clarification: what object types do we need to support? Simple one and complex one. Per [a document here](https://www.w3schools.com/js/js_json_datatypes.asp), in JSON, values must be one of the following data types:

* a string
* a number
* an object (JSON object)
* an array
* a boolean
* null

A few key things here,

1. handle different types
2. Array and complex object need special handling.
3. Record the depth when traverse the object due to indent.
4. DFS is expected. 
